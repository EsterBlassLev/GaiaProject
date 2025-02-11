using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Data.Interfaces
{
    public interface IOperation
    {
         Task<IEnumerable<string>> GetOperationsAsync();
    }
}
