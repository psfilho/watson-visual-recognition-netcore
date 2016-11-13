using System;
using Newtonsoft.Json;

namespace Watson.VisualRecognition.SDK.Models.Classify
{
    /// <summary>
    /// Model for a classify call response
    /// </summary>
    [Serializable]
    public class VisualRecognitionClassifyResponse
    {

        /// <summary>
        /// The array of images classified.
        /// </summary>
        [JsonProperty("images")]
        public VisualRecognitionClassifyImage[] Images { get; internal set; } = { };

        /// <summary>
        /// The number of images processed by the API call.
        /// </summary>
        [JsonProperty("images_processed")]
        public int ImagesProcessed { get; set; }

    }

    /// <summary>
    /// Model for a classify call response image
    /// </summary>
    [Serializable]
    public class VisualRecognitionClassifyImage
    {

        /// <summary>
        /// The relative path of the image file. This is omitted if the image was passed by URL.
        /// </summary>
        [JsonProperty("image")]
        public string Image { get; set; }

        /// <summary>
        /// The fully-resolved URL of the image, after redirects are followed. This is omitted if the image was uploaded.
        /// </summary>
        [JsonProperty("resolved_url")]
        public string ResolvedUrl { get; set; }

        /// <summary>
        /// The source URL of the image, before any redirects. This is omitted if the image was uploaded.
        /// </summary>
        [JsonProperty("source_url")]
        public string SourceUrl { get; set; }

        /// <summary>
        /// An array of the classifiers detected in the images.
        /// </summary>
        [JsonProperty("classifiers")]
        public VisualRecognitionClassifyClassifier[] Classifiers { get; internal set; } = { };

    }

    /// <summary>
    /// Model for a classify call response classifier
    /// </summary>
    [Serializable]
    public class VisualRecognitionClassifyClassifier
    {

        /// <summary>
        /// The ID of a classifier identified in the image.
        /// </summary>
        [JsonProperty("classifier_id")]
        public string Id { get; set; }

        /// <summary>
        /// The name of the classifier identified in the image.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// An array of classes within a classifier.
        /// </summary>
        [JsonProperty("classes")]
        public VisualRecognitionClassifyClassifierClass[] Classes { get; set; } = { };

    }

    /// <summary>
    /// Model for a classify call response classifier class
    /// </summary>
    [Serializable]
    public class VisualRecognitionClassifyClassifierClass
    {
        /// <summary>
        /// The name of the class identified in the image.
        /// </summary>
        [JsonProperty("class")]
        public string Class { get; set; }

        /// <summary>
        /// The score of a class identified in the image. Scores range from 0-1, with a higher score indicating greater correlation.
        /// </summary>
        [JsonProperty("score")]
        public double Score { get; set; }

    }

}
