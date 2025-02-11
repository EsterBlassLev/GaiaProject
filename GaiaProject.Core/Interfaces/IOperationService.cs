using Calculator.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Interfaces
{
    public interface IOperationService
    {
        Task<CalculationResult> CalculateAsync(CalculationRequest request);
        Task<IEnumerable<string>> GetAvailableOperationsAsync();
        Task<IEnumerable<CalculationResult>> GetRecentOperationsAsync(string operationType, int count);
        Task<int> GetMonthlyOperationCountAsync(string operationType);
    }
}
