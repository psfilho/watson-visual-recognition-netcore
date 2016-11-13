using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Watson.VisualRecognition.Tool.Controllers
{
    public class BaseController : Controller
    {

        protected JsonResult JsonError(Exception exc = null)
        {
            if (exc != null)
            {
                ModelState.AddModelError("DefaultErrorMessage", exc.Message);
            }

            var errors = new List<string>();
            foreach (var value in ModelState.Values.Where(x => x.Errors.Any()))
            {
                errors.AddRange(value.Errors.Select(error => error.ErrorMessage));
            }
            Response.StatusCode = 500;
            return Json(errors);
        }
    }
}
