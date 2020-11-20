using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DicomLoaderWeb.Models;

using Microsoft.AspNetCore.Mvc;

namespace DicomLoaderWeb.Controllers
{
    public interface IUserController
    {
        public IActionResult Index();

        public Task<IActionResult> Users();

        public IActionResult Registration();

        public Task<IActionResult> Registration(User PostUser);

        public Task<IActionResult> ResetPassword(int id);

        public Task<IActionResult> UpdateRole(int id);

        public Task<IActionResult> Records();

        public IActionResult Logout();
        

    }
}
