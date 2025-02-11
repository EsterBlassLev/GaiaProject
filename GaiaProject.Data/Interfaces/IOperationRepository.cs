using Calculator.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Data.Interfaces
{
    public interface IOperationRepository
    {
        Task SaveCalculationResultAsync(CalculationResult result);
        Task<IEnumerable<CalculationResult>> GetRecentOperationsAsync(string operationType, int count);
        Task<int> GetMonthlyOperationCountAsync(string operationType);
    }
}
