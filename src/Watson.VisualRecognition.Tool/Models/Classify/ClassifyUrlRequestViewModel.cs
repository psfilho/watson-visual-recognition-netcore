using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Watson.VisualRecognition.Tool.Models.Classify
{
    public class ClassifyUrlRequestViewModel
    {
        public string ApiKey { get; set; }

        public string Url { get; set; }

        public string[] Classifiers { get; set; }

        public string[] Owners { get; set; }

        public double? Threshold { get; set; }
    }
}
