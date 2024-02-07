using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTCP1.Model;

namespace TestTCP1.Lib
{
    public class TouchUITemp
    {
        public decimal COEFFICIENCE { get; set; } = 108.2m;
        public string TargetPos { get; set; } = "Y";
        public int Multiplier { get; set; } = 0;

        public PositionModel Setup(PositionModel data)
        {
            switch (TargetPos)
            {
                case "Y":
                    data.Y = data.Y + (COEFFICIENCE*Multiplier);
                    break;
                case "X":
                    data.X = data.X +(COEFFICIENCE*Multiplier);
                    break;
                case "Z":
                    data.Z = data.Z + (COEFFICIENCE * Multiplier);
                    break;
            }
            return data;
        }
    }
}
