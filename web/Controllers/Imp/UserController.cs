using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using DicomLoaderWeb.DBContext;
using DicomLoaderWeb.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DicomLoaderWeb.Controllers
{
    public class UserController : Controller, IUserController
    {
        private readonly EFContext _Context = new EFContext();

        public IActionResult Index()
        {           
            return View();
        }

        /// <summary>
        /// List the registered users if the requester is an admin
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Users()
        {
            if(HttpContext.Session.GetString("_User") == UserRole.USER.ToString())
            {
                return Redirect("index");
            }
            var users = await _Context.Users.ToArrayAsync();
            return View(users);
        }
        /// <summary>
        /// Load registration page
        /// </summary>
        /// <returns></returns>
        public IActionResult Registration()
        {
            User user = new User();
            return View(user);
        }
        /// <summary>
        /// Handles post request of the registration
        /// </summary>
        /// <param name="PostUser">user to be registered</param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Registration(User PostUser)
        {
            if(PostUser.LastName == null || PostUser.FirstName == null || PostUser.Password == null || PostUser.Email == null)
            {
                return RedirectToAction("Error", new Error { ErrorMessage = "Üresek a bevitt adatok" });
            }
            if(_Context.Users.Where(x => x.Email == PostUser.Email).Any())
            {
                return RedirectToAction("Error", new Error { ErrorMessage = "A megadott email címmel már regisztráltak" });
            }

            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            string hashed = HashPassword(salt, PostUser.Password);
            PostUser.Password = hashed;
            PostUser.RegDate = DateTime.Today;
            PostUser.Salt = Convert.ToBase64String(salt);
            PostUser.Role = UserRole.USER;
            PostUser.Status = UserStatus.DISABLED;

            if (ModelState.IsValid)
            {
                _Context.Add(PostUser);
                await _Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        /// <summary>
        /// Reset the password of the user to "321"
        /// </summary>
        /// <param name="id">users's id, whose password should be reseted</param>
        /// <returns></returns>
        [HttpGet]
        [Route("/ResetPassword/{id:int}")]
        public async Task<IActionResult> ResetPassword(int id)
        {
            try
            {
                var users = await _Context.Users.Where(x => x.ID == id).ToArrayAsync();
                var user = users[0];
                user.Password = HashPassword(Convert.FromBase64String(user.Salt), "321");
                _Context.Add(user);
                _Context.Entry(user).State = EntityState.Modified;
                _Context.SaveChanges();
            
                return RedirectToAction("Users");
            }
            catch (Exception)
            {
                return RedirectToAction("Error", new Error { ErrorMessage = "Hiba a jelszó visszaállíta közben" });
            }

        }

        /// <summary>
        /// Change to role of the user to admin or user
        /// </summary>
        /// <param name="id">user whose role needs to be updated</param>
        /// <returns></returns>
        [HttpGet]
        [Route("/UpdateRole/{id:int}")]
        public async Task<IActionResult> UpdateRole(int id)
        {
            try
            {
                var users = await _Context.Users.Where(x => x.ID == id).ToArrayAsync();
                var user = users[0];
                user.Role = user.Role == UserRole.ADMIN ? UserRole.USER : UserRole.ADMIN;
                _Context.Add(user);
                _Context.Entry(user).State = EntityState.Modified;
                _Context.SaveChanges();
                return RedirectToAction("Users");
            }
            catch (Exception)
            {
                return RedirectToAction("Error", new Error { ErrorMessage = "Hiba a jelszó visszaállítása közben" });
            }
        }

        /// <summary>
        /// Change the state of the user between ACTIVE and DISABLED
        /// </summary>
        /// <param name="id">user whose state needs to be updated</param>
        /// <returns></returns>
        [HttpGet]
        [Route("/UpdateState/{id:int}")]
        public async Task<IActionResult> UpdateState(int id)
        {
            try
            {
                var users = await _Context.Users.Where(x => x.ID == id).ToArrayAsync();
                var user = users[0];
                user.Status = user.Status == UserStatus.ACTIVE ? UserStatus.DISABLED : UserStatus.ACTIVE;
                _Context.Add(user);
                _Context.Entry(user).State = EntityState.Modified;
                _Context.SaveChanges();
                return RedirectToAction("Users");
            }
            catch (Exception)
            {
                return RedirectToAction("Error", new Error { ErrorMessage = "Hiba státusz változása közben" });
            }
        }
        /// <summary>
        /// Load the license page
        /// </summary>
        /// <param name="user">user whose license state is displayed</param>
        /// <returns></returns>
        public IActionResult License(User user)
        {
            return View(user);
        }

        /// <summary>
        /// Load sign in window
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> SignIn()
        {
            if(HttpContext.Session.GetString("_UId") != null)
            {
                try
                {
                    var Users = await _Context.Users.Where(x => x.ID == int.Parse(HttpContext.Session.GetString("_UId"))).ToArrayAsync();
                    return RedirectToAction("License", Users[0]);
                }
                catch (Exception)
                {
                    return RedirectToAction("Error", new Error { ErrorMessage = "Adatbázis hiba" });
                }
                
            }
            return View();
        }

        /// <summary>
        /// Handles sign in post request
        /// </summary>
        /// <param name="Email">user's email</param>
        /// <param name="Password">user's password</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SignIn(String Email, String Password)
        {
            User user = null;
            try
            {
                var users = await _Context.Users.Where(x => x.Email == Email).ToArrayAsync();
                user = users[0];    
            }
            catch (ArgumentNullException)
            {
                var Experror = new Error { ErrorMessage = "Hiányzó jelszó" };
                return RedirectToAction("Error", Experror);
            }
            catch (IndexOutOfRangeException)
            {
                var Experror = new Error { ErrorMessage = "Hibás jelszó" };
                return RedirectToAction("Error", Experror);
            }
            
            if(CheckPassword(user.Salt, user.Password, Password))
            {
                if (user.Status == UserStatus.DISABLED) {
                    return RedirectToAction("Error", new Error { ErrorMessage = "A felhasználó még nincs aktiválva" });
                }
                user.RegDate = user.RegDate.AddDays(90);

                if ((user.RegDate > DateTime.Today))
                {
                    HttpContext.Session.SetString("_User", user.Role.ToString());
                    HttpContext.Session.SetString("_UId", user.ID.ToString());
                    return RedirectToAction("License", user);
                }
                else
                {
                    var EndOfLicense = user.RegDate.Year + "/" + user.RegDate.Month + "/" + user.RegDate.Day;
                    var LicenseError = new Error { ErrorMessage = "Lejárt license: " + EndOfLicense  };
                    return RedirectToAction("Error", LicenseError);
                }
               
            }
            var error = new Error { ErrorMessage = "Hibás bejelentkezési adatok" };
            return RedirectToAction("Error", error);
        }

        /// <summary>
        /// Handles logout request
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/logout")]
        public  IActionResult Logout() {
            HttpContext.Session.Remove("_User");
            HttpContext.Session.Remove("_UId");
            return RedirectToAction("index");
        }

        /// <summary>
        /// Hash the password
        /// </summary>
        /// <param name="Salt">the salt which is used during hash</param>
        /// <param name="Password">password to be hashed</param>
        /// <returns>Hashed password</returns>
        static private String HashPassword(byte[] Salt, String Password)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: Password,
                salt: Salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hashed;
        }
        /// <summary>
        /// Check if the password match with the hashed password
        /// </summary>
        /// <param name="Salt">the salt which is used during hash</param>
        /// <param name="PasswordStored">hashed password</param>
        /// <param name="PasswordInput">password needs to be checked</param>
        /// <returns></returns>
        public static Boolean CheckPassword(String Salt, String PasswordStored, String PasswordInput)
        {
            String hashed = HashPassword(Convert.FromBase64String(Salt), PasswordInput);
            if (PasswordStored.Equals(hashed)) return true;
            return false;
        }

        /// <summary>
        /// Load error page
        /// </summary>
        /// <param name="error">Erros message</param>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(Error error)
        {
            return View(error);
        }
        /// <summary>
        /// List the records of the users
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Records()
        {
            var Id = int.Parse(HttpContext.Session.GetString("_UId"));
            if (Id == 0) return RedirectToAction("Error", new Error { ErrorMessage = "Nem létező felhasználó" });

            try
            {
                var Users = await _Context.Users.Where(x => x.ID == Id).ToArrayAsync();
                if (Users.Length == 0) return RedirectToAction("Error", new Error { ErrorMessage = "Nem létező felhasználó" });

                var User = Users[0];

                var Records = await _Context.Records.Where(x => x.User == User).ToArrayAsync();
                if(Records.Length == 0) return RedirectToAction("Error", new Error { ErrorMessage = "A felhasználóhoz nem tartozik rekord" });

                return View(Records);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", new Error { ErrorMessage = "Hibás bejelentkezési adatok" });
            }
        }
    }
}
