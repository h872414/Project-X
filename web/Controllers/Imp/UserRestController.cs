using System;
using System.Linq;
using System.Threading.Tasks;
using DicomLoaderWeb.Models;
using DicomLoaderWeb.DBContext;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DicomLoaderWeb.Controllers.Imp
{
    public class UserRestController : Controller, IUserRestController
    {
        private readonly EFContext _Context = new EFContext();

        [HttpPost]
        [Route("/Upload")]
        public async Task<ActionResult> Update(string Email, string DicomImage, string PatientName, string Description, string Date)
        {
            if(Email == null || DicomImage == null || PatientName == null || Description == null)
            {
                return UnprocessableEntity();
            }
            User SendingUser = null;
            try
            {
                var Users = await _Context.Users.Where(x => x.Email == Email).ToArrayAsync();

                if(Users.Length == 0 ) return UnprocessableEntity();

                SendingUser = Users[0];
                Record InputRecord = new Record {
                    User = SendingUser,
                    PatientName = PatientName,
                    Image = DicomImage,
                    Description = Description,
                    RecordDate = DateTime.Parse(Date)
                };

                _Context.Add(InputRecord);
                await _Context.SaveChangesAsync();
                return Ok();
          
            }
            catch(Exception)
            {
                return StatusCode(500);
            }

        }

        //Handle HTTP request from desktop App
        [HttpPost]
        [Route("/SignIn")]
        public async Task<ActionResult> GetData(String Email, String Password)
        {
            User user = null;

            try
            {
                var users = await _Context.Users.Where(x => x.Email == Email).ToArrayAsync();
                user = users[0];
            }
            catch (ArgumentNullException)
            {
                return Ok(new { accepted = false, error = "Hibás email/jelszó" });
            }
            catch (IndexOutOfRangeException)
            {
                return Ok(new { accepted = false, error = "Az email cím nincs regisztrálva" });
            }

            if (UserController.CheckPassword(user.Salt, user.Password, Password))
            {
                if (user.Status != UserStatus.ACTIVE)
                {
                    return Ok(new { accepted = false, error = user.Status.ToString() });
                }
                user.RegDate = user.RegDate.AddDays(90);

                if ((user.RegDate > DateTime.Today))
                {
                    var EndOfLicense = user.RegDate.Year + "," + user.RegDate.Month + "," + user.RegDate.Day;
                    return Ok(new
                    {
                        accepted = true,
                        error = "none",
                        user = new
                        {
                            firstname = user.FirstName,
                            lastname = user.LastName,
                            licenseDate = EndOfLicense
                        }
                    });
                }
                else
                {
                    var EndOfLicense = user.RegDate.Year + "/" + user.RegDate.Month + "/" + user.RegDate.Day;
                    return Ok(new { accepted = false, error = "Lejárt license" });
                }
            }



            return Ok(new { accepted = false, error = "Hibás jelszó" });

        }
    }
}
