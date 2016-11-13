using System;
using Newtonsoft.Json;

namespace Watson.VisualRecognition.SDK.Models.Classifier
{
    /// <summary>
    /// Model for a List of user-created classifiers API Call.
    /// </summary>
    [Serializable]
    public class VisualRecognitionClassifierDetailList
    {

        /// <summary>
        /// The list of classifiers
        /// </summary>
        [JsonProperty("classifiers")]
        public VisualRecognitionClassifierDetail[] Classifiers { get; internal set; } = { };

    }

    /// <summary>
    /// Classifier Detail
    /// </summary>
    [Serializable]
    public class VisualRecognitionClassifierDetail
    {
        /// <summary>
        /// The ID of the classifier.
        /// </summary>
        [JsonProperty("classifier_id")]
        public string ClassifierId { get; internal set; }

        /// <summary>
        /// The name of the classifier.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; internal set; }

        /// <summary>
        /// The API key of the user who created the classifier
        /// </summary>
        [JsonProperty("owner")]
        public string Owner { get; internal set; }

        /// <summary>
        /// The training status of classifier.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; internal set; }

        /// <summary>
        /// The time and date when classifier was created.
        /// </summary>
        [JsonProperty("created")]
        public DateTime CreatedAt { get; internal set; }

        /// <summary>
        /// An array of classes that define a classifier.
        /// </summary>
        [JsonProperty("classes")]
        public VisualRecognitionClassifierCreateClassResponse[] Classes { get; internal set; } = { };

    }

    /// <summary>
    /// Classifier Class
    /// </summary>
    public class VisualRecognitionClassifierCreateClassResponse
    {

        /// <summary>
        /// The name of the class.
        /// </summary>
        [JsonProperty("class")]
        public string Class { get; internal set; }

    }
}
