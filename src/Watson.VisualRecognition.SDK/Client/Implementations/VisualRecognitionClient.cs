using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using Watson.VisualRecognition.SDK.Client.Interfaces;
using Watson.VisualRecognition.SDK.Helpers;
using Watson.VisualRecognition.SDK.Models.Base;
using Watson.VisualRecognition.SDK.Models.Classifier;
using Watson.VisualRecognition.SDK.Models.Classify;
using Watson.VisualRecognition.SDK.Models.Error;
using Watson.VisualRecognition.SDK.Models.FaceDetection;

namespace Watson.VisualRecognition.SDK.Client.Implementations
{
    public class VisualRecognitionClient : IVisualRecognitionClient
    {

        /// <param name="apiKey">Your API key.</param>
        public VisualRecognitionClient(string apiKey)
        {
            Configuration = new VisualRecognitionConfig(apiKey);
        }

        /// <param name="apiKey">Your API key.</param>
        /// <param name="version">The release date of the version of the API you want to use. Specify dates in YYYY-MM-DD format. The current version is 2016-05-20.</param>
        public VisualRecognitionClient(string apiKey, string version)
        {
            Configuration = new VisualRecognitionConfig(apiKey, version);
        }

        /// <summary>
        /// Client Configuration
        /// </summary>
        public IVisualRecognitionConfig Configuration { get; }

        public VisualRecognitionClassifierDetail CreateClassifier(VisualRecognitionClassifierCreate classifier)
        {
            var client = new RestClient(Configuration.ApiUrl);
            var request = new RestRequest($"/classifiers?api_key={Configuration.ApiKey}&version={Configuration.Version}")
            {
                Method = Method.POST
            };
            request.AddHeader("Content-Type", "multipart/form-data");

            request.AddParameter("name", classifier.Name);


            // Add the positive example files to the request body
            foreach (var positiveExample in classifier.PositiveExamples)
            {
                request.AddFile($"{ positiveExample.ClassName}_positive_examples", positiveExample.ZipFile.Stream.ReadFully(), positiveExample.ZipFile.Name);
            }

            // Add the negative example files to the request body, if they exists
            if (classifier.NegativeExample != null)
            {
                request.AddFile("negative_examples", classifier.NegativeExample.ZipFile.Stream.ReadFully(), "negative_examples.zip");
            }

            // Execute the API Call
            var response = client.ExecuteSync(request);

            // Handle the Response
            return HandleRecognitionResponse<VisualRecognitionClassifierDetail>(response);
        }

        public VisualRecognitionClassifierDetail UpdateClassifier(VisualRecognitionClassifierUpdate classifier)
        {
            var client = new RestClient($"{Configuration.ApiUrl}");
            var request = new RestRequest($"/classifiers/{classifier.ClassifierId}?api_key={Configuration.ApiKey}&version={Configuration.Version}")
            {
                Method = Method.POST
            };
            request.AddHeader("Content-Type", "multipart/form-data");

            // Add the positive example files to the request body
            foreach (var positiveExample in classifier.PositiveExamples)
            {
                request.AddFile($"{ positiveExample.ClassName}_positive_examples", positiveExample.ZipFile.Stream.ReadFully(), positiveExample.ZipFile.Name);
            }

            // Add the negative example files to the request body, if they exists
            if (classifier.NegativeExample != null)
            {
                request.AddFile("negative_examples", classifier.NegativeExample.ZipFile.Stream.ReadFully(), "negative_examples.zip");
            }

            // Execute the API Call
            var response = client.ExecuteSync(request);

            // Handle the Response
            return HandleRecognitionResponse<VisualRecognitionClassifierDetail>(response);
        }

        public VisualRecognitionClassifierDetailList ListClassifiers()
        {
            var client = new RestClient(Configuration.ApiUrl);
            var request = new RestRequest($"/classifiers?api_key={Configuration.ApiKey}&version={Configuration.Version}")
            {
                Method = Method.GET
            };
            request.AddParameter("verbose", true);

            // Execute the API Call
            var response = client.ExecuteSync(request);

            // Handle the Response
            return HandleRecognitionResponse<VisualRecognitionClassifierDetailList>(response);
        }

        public VisualRecognitionClassifierDetail GetClassifier(string classifierId)
        {
            var client = new RestClient(Configuration.ApiUrl);
            var request = new RestRequest($"/classifiers/{classifierId}/?api_key={Configuration.ApiKey}&version={Configuration.Version}")
            {
                Method = Method.GET
            };

            // Execute the API Call
            var response = client.ExecuteSync(request);

            // Handle the Response
            return HandleRecognitionResponse<VisualRecognitionClassifierDetail>(response);
        }

        public void DeleteClassifier(string classifierId)
        {
            var client = new RestClient($"{Configuration.ApiUrl}");
            var request = new RestRequest($"/classifiers/{classifierId}/?api_key={Configuration.ApiKey}&version={Configuration.Version}")
            {
                Method = Method.DELETE
            };

            // Execute the API Call
            var response = client.ExecuteSync(request);

            // Handle the Response
            HandleRecognitionResponse(response);
        }

        public VisualRecognitionClassifyResponse ClassifyImageUrl(string url)
        {
            var client = new RestClient(Configuration.ApiUrl);
            var request = new RestRequest($"/classify?api_key={Configuration.ApiKey}&version={Configuration.Version}&url={url}")
            {
                Method = Method.GET
            };

            // Execute the API Call
            var response = client.ExecuteSync(request);

            // Handle the Response
            return HandleRecognitionResponse<VisualRecognitionClassifyResponse>(response);
        }

        public VisualRecognitionClassifyResponse ClassifyImageUrl(VisualRecognitionClassifyUrl model)
        {
            var client = new RestClient(Configuration.ApiUrl);

            var requestUrl = new StringBuilder();
            requestUrl.Append($"/classify?api_key={Configuration.ApiKey}&version={Configuration.Version}&url={model.Url}");

            if (model.Threshold.HasValue)
            {
                requestUrl.Append($"&threshold={model.Threshold}");
            }

            if (model.Classifiers != null && model.Classifiers.Any())
            {
                requestUrl.Append($"&classifier_ids={string.Join(",", model.Classifiers)}");
            }

            if (model.Owners != null && model.Owners.Any())
            {
                requestUrl.Append($"&owners={string.Join(",", model.Owners)}");
            }


            // Create a RestRequest and set ContentType to multipart/form-data
            var request = new RestRequest(requestUrl.ToString())
            {
                Method = Method.GET
            };
            request.AddHeader("Content-Type", "multipart/form-data");

            // Execute the API Call
            var response = client.ExecuteSync(request);

            // Handle the Response
            return HandleRecognitionResponse<VisualRecognitionClassifyResponse>(response);
        }

        public VisualRecognitionClassifyResponse ClassifyImageFile(VisualRecognitionFile file)
        {
            var client = new RestClient(Configuration.ApiUrl);

            // Create a RestRequest and set ContentType to multipart/form-data
            var request = new RestRequest($"/classify?api_key={Configuration.ApiKey}&version={Configuration.Version}")
            {
                Method = Method.POST
            };
            request.AddFile("image_file", file.Stream.ReadFully(), file.Name);

            // Execute the API Call
            var response = client.ExecuteSync(request);

            // Handle the Response
            return HandleRecognitionResponse<VisualRecognitionClassifyResponse>(response);
        }

        public VisualRecognitionClassifyResponse ClassifyImageFile(VisualRecognitionClassifyRequestFile model)
        {
            var client = new RestClient(Configuration.ApiUrl);

            var requestUrl = new StringBuilder();
            requestUrl.Append($"/classify?api_key={Configuration.ApiKey}&version={Configuration.Version}");

            if (model.Threshold.HasValue)
            {
                requestUrl.Append($"&threshold={model.Threshold}");
            }

            if (model.Classifiers != null && model.Classifiers.Any())
            {
                requestUrl.Append($"&classifier_ids={string.Join(",", model.Classifiers)}");
            }

            if (model.Owners != null && model.Owners.Any())
            {
                requestUrl.Append($"&owners={string.Join(",", model.Owners)}");
            }

            var request = new RestRequest(requestUrl.ToString())
            {
                Method = Method.POST
            };
            request.AddHeader("Content-Type", "multipart/form-data");

            request.AddFile("image_file", model.File.Stream.ReadFully(), model.File.Name);

            // Execute the API Call
            var response = client.ExecuteSync(request);

            // Handle the Response
            return HandleRecognitionResponse<VisualRecognitionClassifyResponse>(response);
        }

        public VisualRecognitionFaceDetectionResponse FaceDetectionUrl(string url)
        {
            var client = new RestClient(Configuration.ApiUrl);
            var request = new RestRequest($"/detect_faces?api_key={Configuration.ApiKey}&version={Configuration.Version}&url={url}")
            {
                Method = Method.GET
            };

            // Execute the API Call
            var response = client.ExecuteSync(request);

            // Handle the Response
            return HandleRecognitionResponse<VisualRecognitionFaceDetectionResponse>(response);
        }

        public VisualRecognitionFaceDetectionResponse FaceDetectionFile(Stream stream, string fileName)
        {

            var client = new RestClient(Configuration.ApiUrl);

            // Create a RestRequest and set ContentType to multipart/form-data
            var request = new RestRequest($"/detect_faces?api_key={Configuration.ApiKey}&version={Configuration.Version}")
            {
                Method = Method.POST
            };
            request.AddFile("image_file", stream.ReadFully(), fileName);

            // Execute the API Call
            var response = client.ExecuteSync(request);

            // Handle the Response
            return HandleRecognitionResponse<VisualRecognitionFaceDetectionResponse>(response);
        }

        private void HandleRecognitionResponse(IRestResponse response)
        {
            // Handle the API Call Response
            if (response.StatusCode == HttpStatusCode.OK)
                return;
            HandleRecognitionErrorResponse(response);
            throw new Exception("Unknown Error");
        }

        private T HandleRecognitionResponse<T>(IRestResponse response)
        {
            // Handle the API Call Response
            if (response.StatusCode == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<T>(response.Content);
            HandleRecognitionErrorResponse(response);
            throw new Exception("Unknown Error");
        }

        private void HandleRecognitionErrorResponse(IRestResponse response)
        {
            // Handle the API Call Error Response
            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                var error = JsonConvert.DeserializeObject<VisualRecognitionForbidden>(response.Content);
                throw new Exception($"Classifier Create Request Failed. Status {error.Status}: {error.StatusInfo}");
            }
            else
            {
                var error = JsonConvert.DeserializeObject<VisualRecognitionError>(response.Content);
                throw new Exception($"Classifier Create Request Failed. Code {error.Code}: {error.Error}");
            }
        }

    }
}
