using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicomLoader.Controller
{
    interface IWebController
    {
        Task<Boolean> SignIn(String Email, String password);
    }
}
