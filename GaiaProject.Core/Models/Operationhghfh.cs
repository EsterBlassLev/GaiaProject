using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Models
{
    public class Operationhghfh
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Func<object, object, object> Calculate { get; set; }
    }

}
