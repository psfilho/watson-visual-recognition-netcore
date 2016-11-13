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
    public class ClassifierController : BaseController
    {

        [HttpGet]
        public JsonResult List(string apiKey)
        {
            try
            {
                var client = new VisualRecognitionClient(apiKey);
                var data = client.ListClassifiers();
                return Json(data);
            }
            catch (Exception exc)
            {
                return JsonError(exc);
            }
        }

        [HttpDelete]
        public JsonResult Delete(string apiKey, string classifierId)
        {
            try
            {
                var client = new VisualRecognitionClient(apiKey);
                client.DeleteClassifier(classifierId);
                return Json("OK");
            }
            catch (Exception exc)
            {
                return JsonError(exc);
            }
        }

        [HttpPost]
        public JsonResult Update([FromForm]string apiKey, string classifierId, IFormCollection files)
        {
            try
            {
                List<VisualRecognitionClassifierPositiveClass> positiveExamples = new List<VisualRecognitionClassifierPositiveClass>();
                VisualRecognitionClassifierNegativeClass negativeExamples = null;

                foreach (var file in files.Files)
                {
                    if (file.Name == "files[negative]")
                    {
                        negativeExamples = new VisualRecognitionClassifierNegativeClass(file.OpenReadStream(), file.FileName);
                    }
                    else
                    {
                        var className = Regex.Match(file.Name, @"files\[([a-zA-Z]+)*\]").Groups[1].Value;
                        positiveExamples.Add(new VisualRecognitionClassifierPositiveClass(className, file.OpenReadStream(), file.FileName));
                    }
                }


                var client = new VisualRecognitionClient(apiKey);
                var response = client.UpdateClassifier(new VisualRecognitionClassifierUpdate(classifierId)
                {
                    NegativeExample = negativeExamples,
                    PositiveExamples = positiveExamples
                });
                return Json(response);

            }
            catch (Exception exc)
            {
                return JsonError(exc);
            }
        }


        [HttpPost]
        public JsonResult Create([FromForm]string apiKey, string name, IFormCollection files)
        {
            try
            {
                List<VisualRecognitionClassifierPositiveClass> positiveExamples = new List<VisualRecognitionClassifierPositiveClass>();
                VisualRecognitionClassifierNegativeClass negativeExamples = null;

                foreach (var file in files.Files)
                {
                    if (file.Name == "files[negative]")
                    {
                        negativeExamples = new VisualRecognitionClassifierNegativeClass(file.OpenReadStream(), file.FileName);
                    }
                    else
                    {
                        var className = Regex.Match(file.Name, @"files\[([a-zA-Z]+)*\]").Groups[1].Value;
                        positiveExamples.Add(new VisualRecognitionClassifierPositiveClass(className, file.OpenReadStream(), file.FileName));
                    }
                }


                var client = new VisualRecognitionClient(apiKey);
                var response = client.CreateClassifier(new VisualRecognitionClassifierCreate(name)
                {
                    NegativeExample = negativeExamples,
                    PositiveExamples = positiveExamples
                });
                return Json(response);

            }
            catch (Exception exc)
            {
                return JsonError(exc);
            }
        }

        [HttpPost]
        public JsonResult ClassifyFile([FromForm]string apiKey, string[] classifiers, string[] owners, double? threshold, IFormFile file)
        {
            try
            {
                var client = new VisualRecognitionClient(apiKey);
                using (var stream = file.OpenReadStream())
                {
                    var request = new VisualRecognitionClassifyRequestFile(stream, file.FileName)
                    {
                        Classifiers = classifiers,
                        Owners = owners,
                        Threshold = threshold
                    };

                    var response = client.ClassifyImageFile(request);
                    return Json(response);
                }
            }
            catch (Exception exc)
            {
                return JsonError(exc);
            }
        }

        [HttpPost]
        public JsonResult ClassifyUrl([FromBody]ClassifyUrlRequestViewModel model)
        {
            try
            {
                var client = new VisualRecognitionClient(model.ApiKey);
                var request = new VisualRecognitionClassifyUrl(model.Url)
                {
                    Classifiers = model.Classifiers,
                    Owners = model.Owners,
                    Threshold = model.Threshold
                };

                var response = client.ClassifyImageUrl(request);
                return Json(response);
            }
            catch (Exception exc)
            {
                return JsonError(exc);
            }
        }

    }
}
