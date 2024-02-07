using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTCP1.Model
{
    public class MarkPointModel
    {
        public string Model { get; set; } = string.Empty;
        public int Position { get; set; }
        public string AreaInspection { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public float X { get; set;  }
        public float Y { get; set; }    
    }
}
