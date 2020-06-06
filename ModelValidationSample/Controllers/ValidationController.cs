using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ModelValidationSample.Controllers
{
    public class ValidationController : Controller
    {
        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyEmail(string email)
        {//Mail Check
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return Json(true);
            }
            catch
            {
                return Json(false);
            }
        }
        //[AcceptVerbs("GET", "POST")]
        //public IActionResult VerifyName(string firstName, string lastName)
        //{
        //    if (!_yourservice.VerifyName(firstName, lastName))
        //    {
        //        return Json($"A user named {firstName} {lastName} already exists.");
        //    }

        //    return Json(true);
        //}
    }
}
