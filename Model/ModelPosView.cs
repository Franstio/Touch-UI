using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTCP1.Model
{
    public class ModelPosView
    {
        public int Pos { get; set; } 
        public string CameraCheckpoint { get; set; } = string.Empty;
        public string Axis { get; set; } = string.Empty;
    }
}
