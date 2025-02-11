using Calculator.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Data.Entities
{
    public class CalculationHistory
    {
        //public CalculationHistory()
        //{
        //    operation = new Operations();
        //}

        [Key]
        public int? HistoryId { get; set; }
        //[ForeignKey("Operations")]
        public int OperationId { get; set; }  
        public string? FieldA { get; set; }
        public string? FieldB { get; set; }
        public string? Result { get; set; }
        public DateTime CalculationTime { get; set; }

        public virtual Operations Ooperation { get; set; }

    }
}
