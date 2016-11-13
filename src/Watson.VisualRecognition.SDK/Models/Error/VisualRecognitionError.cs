using System;
using Newtonsoft.Json;

namespace Watson.VisualRecognition.SDK.Models.Error
{
    /// <summary>
    /// The forbidden message returned of a visual recognition api call
    /// </summary>
    [Serializable]
    public class VisualRecognitionForbidden
    {

        /// <summary>
        /// The request status
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// The request status information
        /// </summary>
        [JsonProperty("statusInfo")]
        public string StatusInfo { get; set; }

    }

    /// <summary>
    /// The error message returned of a visual recognition api call
    /// </summary>
    [Serializable]
    public class VisualRecognitionError
    {

        /// <summary>
        /// The request error code
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// The request error
        /// </summary>
        [JsonProperty("error")]
        public string Error { get; set; }

    }
}
