using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchUI.Model
{
    public class InspectionView
    {
        public string Area { get; set; } = string.Empty;
        public string Judgement { get; set; } = string.Empty;
        public string Image { get;set; } = string.Empty;
        public string? Reason { get; set; } = null;
    }
}
