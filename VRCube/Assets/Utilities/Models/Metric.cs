using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Utilities.Models
{
    public class Metric
    {
        public string Action { get; set; }
        public float Timestamp { get; set; }
        public string Description { get; set; }
        public string PlayerId { get; set; }
        public string Keyboard { get; set; }

        public float RightControllerX { get; set; }
        public float RightControllerY { get; set; }
        public float RightControllerZ { get; set; }

        public float LeftControllerX { get; set; }
        public float LeftControllerY { get; set; }
        public float LeftControllerZ { get; set; }
    }
}
