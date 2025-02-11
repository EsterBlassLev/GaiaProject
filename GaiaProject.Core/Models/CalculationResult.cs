using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Models
{
    public class CalculationResult
    {
        public string Result { get; set; }
        public string Operation { get; set; }
        public string FieldA { get; set; }
        public string FieldB { get; set; }
        public DateTime CalculationTime { get; set; }
    }
}
