using Calculator.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Data.Entities
{
    public class Operations
    {
        public Operations()
        {
            CalculationHistories = new HashSet<CalculationHistory>();
        }
        [Key]
        public int OperationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ParameterAType { get; set; }
        public string ParameterBType { get; set; }

        public virtual ICollection<CalculationHistory> CalculationHistories { get; set; }

    }

}
