using System;
using Newtonsoft.Json;

namespace Watson.VisualRecognition.SDK.Models.FaceDetection
{
    /// <summary>
    /// Model for a detect faces call response
    /// </summary>
    [Serializable]
    public class VisualRecognitionFaceDetectionResponse
    {

        /// <summary>
        /// The array of images.
        /// </summary>
        [JsonProperty("images")]
        public VisualRecognitionFaceDetectionResponseImage[] Images { get; set; } = { };

        [JsonProperty("images_processed")]
        public int ImagesProcessed { get; set; }

    }

    /// <summary>
    /// Model for a detect faces call response image
    /// </summary>
    [Serializable]
    public class VisualRecognitionFaceDetectionResponseImage
    {
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
        /// An array of the faces detected in the images.
        /// </summary>
        [JsonProperty("faces")]
        public VisualRecognitionFaceDetectionResponseFace[] Faces { get; set; } = { };
    }

    /// <summary>
    /// Model for a detect faces call response face
    /// </summary>
    [Serializable]
    public class VisualRecognitionFaceDetectionResponseFace
    {

        /// <summary>
        /// An array of age information about a detected face. If there are greater than 10 faces in an image, age confidence scores may return a score of 0.
        /// </summary>
        [JsonProperty("age")]
        public VisualRecognitionFaceDetectionResponseAge Age { get; set; }

        /// <summary>
        /// An array of information that defines the location of bounding box around a detected face.
        /// </summary>
        [JsonProperty("face_location")]
        public VisualRecognitionFaceDetectionResponseFaceLocation FaceLocation { get; set; }

        /// <summary>
        /// An array of information containing the gender of the detected face. For example, "MALE" or "FEMALE". If there are greater than 10 faces in an image, gender confidence scores may return a score of 0.
        /// </summary>
        [JsonProperty("gender")]
        public VisualRecognitionFaceDetectionResponseGender Gender { get; set; }

        /// <summary>
        /// The identity of a celebrity detected in the image. If no celebrity is detected, the parameter returns empty.
        /// </summary>
        [JsonProperty("identity")]
        public VisualRecognitionFaceDetectionResponseIdentity Identity { get; set; }


    }

    /// <summary>
    /// Model for a detect faces call response age
    /// </summary>
    [Serializable]
    public class VisualRecognitionFaceDetectionResponseAge
    {

        /// <summary>
        /// The maximum estimated age for a detected face.
        /// </summary>
        [JsonProperty("max")]
        public int Max { get; set; }

        /// <summary>
        /// The minimum estimated age for a detected face.
        /// </summary>
        [JsonProperty("min")]
        public int Min { get; set; }

        /// <summary>
        /// The confidence score of the ages, gender, or celebrity indentity identified for a detected face.
        /// </summary>
        [JsonProperty("score")]
        public double Score { get; set; }

    }

    /// <summary>
    /// Model for a detect faces call response face location
    /// </summary>
    [Serializable]
    public class VisualRecognitionFaceDetectionResponseFaceLocation
    {

        /// <summary>
        /// Vertical distance in pixels from one edge of the bounding box around a face to the other.
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; }

        /// <summary>
        /// Horizontal distance in pixels from one edge of the bounding box around a face to the other.
        /// </summary>
        [JsonProperty("width")]
        public int Width { get; set; }

        /// <summary>
        /// Y-position of the top-left pixel of the face bounding box.
        /// </summary>
        [JsonProperty("top")]
        public int Top { get; set; }

        /// <summary>
        /// X-position of the top-left pixel of the face bounding box.
        /// </summary>
        [JsonProperty("left")]
        public int Left { get; set; }

    }

    /// <summary>
    /// Model for a detect faces call response gender
    /// </summary>
    [Serializable]
    public class VisualRecognitionFaceDetectionResponseGender
    {

        /// <summary>
        /// Information containing the gender of the detected face. For example, "MALE" or "FEMALE"
        /// </summary>
        [JsonProperty("gender")]
        public string Gender { get; set; }

        /// <summary>
        /// The confidence score of the ages, gender, or celebrity indentity identified for a detected face.
        /// </summary>
        [JsonProperty("score")]
        public double Score { get; set; }

    }

    /// <summary>
    /// Model for a detect faces call response identity
    /// </summary>
    [Serializable]
    public class VisualRecognitionFaceDetectionResponseIdentity
    {
        /// <summary>
        /// The name of the detected celebrity.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The confidence score of the ages, gender, or celebrity indentity identified for a detected face.
        /// </summary>
        [JsonProperty("score")]
        public double Score { get; set; }

        /// <summary>
        /// A knowledge graph of the celebrity identity. Only return if a type hierarchy is found.
        /// </summary>
        [JsonProperty("type_hierarchy")]
        public string TypeHierarchy { get; set; }

    }

}
