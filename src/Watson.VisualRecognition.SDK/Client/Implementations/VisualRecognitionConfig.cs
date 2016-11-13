using Watson.VisualRecognition.SDK.Client.Interfaces;

namespace Watson.VisualRecognition.SDK.Client.Implementations
{
    public class VisualRecognitionConfig : IVisualRecognitionConfig
    {

        public VisualRecognitionConfig(string apiKey)
        {
            ApiKey = apiKey;
        }

        public VisualRecognitionConfig(string apiKey, string version) : this(apiKey)
        {
            Version = version;
        }

        public string ApiKey { get; }

        public string Version { get; set; } = "2016-05-20";

        public string ApiUrl { get; set; } = "https://gateway-a.watsonplatform.net/visual-recognition/api/v3";
        
    }
}
