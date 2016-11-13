using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Watson.VisualRecognition.SDK.Client;
using Watson.VisualRecognition.SDK.Client.Implementations;
using Watson.VisualRecognition.SDK.Models.Base;
using Watson.VisualRecognition.SDK.Models.Classifier;
using Watson.VisualRecognition.SDK.Models.Classify;
using Watson.VisualRecognition.Tool.Models.Classify;

namespace Watson.VisualRecognition.Tool.Controllers
{
    [Route("api/[controller]/[action]")]
    public class FaceDetectionController : BaseController
    {

        [HttpPost]
        public JsonResult File([FromForm]string apiKey, IFormFile file)
        {
            try
            {
                var client = new VisualRecognitionClient(apiKey);
                using (var stream = file.OpenReadStream())
                {
                    var response = client.FaceDetectionFile(stream, file.FileName);
                    return Json(response);
                }
            }
            catch (Exception exc)
            {
                return JsonError(exc);
            }
        }

        [HttpPost]
        public JsonResult Url([FromBody]ClassifyUrlRequestViewModel model)
        {
            try
            {
                var client = new VisualRecognitionClient(model.ApiKey);
                var response = client.FaceDetectionUrl(model.Url);
                return Json(response);
            }
            catch (Exception exc)
            {
                return JsonError(exc);
            }
        }

    }
}
