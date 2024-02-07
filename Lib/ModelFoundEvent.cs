using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTCP1.Model;

namespace TestTCP1.Lib
{
    public class ModelFoundEvent : EventArgs
    {
        public List<PositionModel>? Positions { get; set; }
    }
}
