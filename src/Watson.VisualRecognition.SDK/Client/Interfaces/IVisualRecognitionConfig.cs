namespace Watson.VisualRecognition.SDK.Client.Interfaces
{
    /// <summary>
    /// Client Configuration
    /// </summary>
    public interface IVisualRecognitionConfig
    {
        /// <summary>
        /// Visual Recognition API Key
        /// </summary>
        string ApiKey { get; }

        /// <summary>
        /// Visual Recognition API Url
        /// </summary>
        string ApiUrl { get; }

        /// <summary>
        /// The release date of the version of the API you want to use. Specify dates in YYYY-MM-DD format. The default version is 2016-05-20.
        /// </summary>
        string Version { get; set; }



    }
}
