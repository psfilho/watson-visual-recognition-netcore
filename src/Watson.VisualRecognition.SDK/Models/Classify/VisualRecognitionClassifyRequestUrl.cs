namespace Watson.VisualRecognition.SDK.Models.Classify
{
    /// <summary>
    /// Model for a classify call by Url
    /// </summary>
    public class VisualRecognitionClassifyUrl : VisualRecognitionClassifyRequestBase
    {
  
        /// <param name="url">Url of the image to classify</param>
        public VisualRecognitionClassifyUrl(string url)
        {
            Url = url;
        }

        /// <summary>
        /// Url of the image to classify
        /// </summary>
        public string Url { get; set; }

    }
}
