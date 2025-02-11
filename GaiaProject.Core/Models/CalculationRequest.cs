using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Models
{
    public class CalculationRequest
    {
        public string FieldA { get; set; }
        public string FieldB { get; set; }
        public string OperationType { get; set; }

    }
}
