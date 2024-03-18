using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTCP1.Model
{
    public class PositionModel
    {
        public int Pos { get; set; } = 1;
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal Z { get; set; }
        public string CameraCheckpoint { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string AreaInspection { get; set; } = string.Empty;
        public object[] GetValues()
        {
            return new object[] { Pos, Model, X, Y, Z, CameraCheckpoint };
        }
        public PositionModel() { }
        public PositionModel(PositionModel other)
        {
            Pos = other.Pos;
            X = other.X;
            Y = other.Y;
            Z = other.Z;
            CameraCheckpoint = other.CameraCheckpoint;
            Model = other.Model;
            AreaInspection = other.AreaInspection;
        }
    }
}
