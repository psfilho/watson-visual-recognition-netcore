using System.IO;
using Watson.VisualRecognition.SDK.Models.Base;
using Watson.VisualRecognition.SDK.Models.Classifier;
using Watson.VisualRecognition.SDK.Models.Classify;
using Watson.VisualRecognition.SDK.Models.FaceDetection;

namespace Watson.VisualRecognition.SDK.Client.Interfaces
{
    /// <summary>
    /// The Client Interface for Visual Recognition SDK
    /// </summary>
    public interface IVisualRecognitionClient
    {

        /// <summary>
        /// Client Configuration
        /// </summary>
        IVisualRecognitionConfig Configuration { get; }

        /// <summary>
        /// Retrieve a list of user-created classifiers.
        /// </summary>
        /// <returns>List of Classifiers Detail</returns>
        VisualRecognitionClassifierDetailList ListClassifiers();

        /// <summary>
        /// Retrieve information about a specific classifier.
        /// </summary>
        /// <param name="classifierId">The ID of the classifier for which you want details</param>
        /// <returns>Classifier Detail</returns>
        VisualRecognitionClassifierDetail GetClassifier(string classifierId);

        /// <summary>
        /// Train a new multi-faceted classifier on the uploaded image data.
        /// A new custom classifier can be trained by several compressed (.zip) files, including files containing positive or negative images (.jpg, or .png). 
        /// You must supply at least two compressed files, either two positive example files or one positive and one negative example file.
        /// </summary>
        /// <param name="classifier">Model for a Classifier Create Call</param>
        /// <returns>The Created Classifier Detail</returns>
        VisualRecognitionClassifierDetail CreateClassifier(VisualRecognitionClassifierCreate classifier);

        /// <summary>
        /// Update an existing classifier by adding new classes, or by adding new images to existing classes.
        /// You cannot update a custom classifier with a free API Key.To update the existing classifier, use several compressed (.zip) files, including files containing positive or negative images (.jpg, or .png).
        /// You must supply at least one compressed file, with additional positive or negative examples.
        /// </summary>
        /// <param name="classifier">Model for a Classifier Update Call</param>
        /// <returns>The Updated Classifier Detail</returns>
        VisualRecognitionClassifierDetail UpdateClassifier(VisualRecognitionClassifierUpdate classifier);

        /// <summary>
        /// Delete a custom classifier with the specified classifier ID.
        /// </summary>
        /// <param name="classifierId">The ID of the classifier you want to delete.</param>
        void DeleteClassifier(string classifierId);

        /// <summary>
        /// URL to identify classes by default.
        /// Images must be in .jpeg, or .png format.
        /// </summary>
        /// <param name="url">Url to Classify</param>
        /// <returns>Classification Result</returns>
        VisualRecognitionClassifyResponse ClassifyImageUrl(string url);

        /// <summary>
        /// URL to classify by default. 
        /// To identify custom classifiers, include the classifierIds or Owners parameters. 
        /// Images must be in .jpeg, or .png format.
        /// </summary>
        /// <param name="model">Model for a Url Classification Call</param>
        /// <returns>Classification Result</returns>
        VisualRecognitionClassifyResponse ClassifyImageUrl(VisualRecognitionClassifyUrl model);

        /// <summary>
        /// a single image or a compressed (.zip) file of multiple images to classify by default.
        /// Images must be in .jpeg, or .png format.
        /// </summary>
        /// <param name="file">File to Classify</param>
        /// <returns>Classification Result</returns>
        VisualRecognitionClassifyResponse ClassifyImageFile(VisualRecognitionFile file);

        /// <summary>
        /// a single image or a compressed (.zip) file of multiple images to classify by default.
        /// To identify custom classifiers, include the classifierIds or Owners parameters. 
        /// Images must be in .jpeg, or .png format.
        /// </summary>
        /// <param name="model">Model for a File Classification Call</param>
        /// <returns>Classification Result</returns>
        VisualRecognitionClassifyResponse ClassifyImageFile(VisualRecognitionClassifyRequestFile model);

        /// <summary>
        /// Detect faces in a single URL.
        /// </summary>
        /// <param name="url">Url to Detect</param>
        /// <returns>Detect Faces Result</returns>
        VisualRecognitionFaceDetectionResponse FaceDetectionUrl(string url);

        /// <summary>
        /// Detect faces on single image or a compressed (.zip) file of multiple images.
        /// </summary>
        /// <param name="stream">File to Detect</param>
        /// <param name="fileName">Filename of the file</param>
        /// <returns>Detect Faces Result</returns>
        VisualRecognitionFaceDetectionResponse FaceDetectionFile(Stream stream, string fileName);

    }
}
