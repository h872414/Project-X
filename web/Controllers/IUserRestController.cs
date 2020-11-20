using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace DicomLoaderWeb.Controllers
{
    interface IUserRestController
    {

        public Task<ActionResult> Update(String Email, String DicomImage, String PatientName, String Description, String Date);

        public Task<ActionResult> GetData(String Email, String Password);
    }
}
