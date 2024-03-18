using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTCP1.Model.ViewModel
{
    public class CountViewModel
    {
        public int Count { get; set; } = 0;
        public int Fail { get; set; } = 0;
        public int Pass { get; set; } = 0;
        public decimal Yield { get; set; } = 0;
    }
}
