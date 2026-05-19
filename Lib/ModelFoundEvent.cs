using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouchUI.Model;

namespace TouchUI.Lib
{
    public class ModelFoundEvent : EventArgs
    {
        public List<PositionModel>? Positions { get; set; }
    }
}
