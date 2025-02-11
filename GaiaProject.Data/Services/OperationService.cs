using Calculator.Core.Interfaces;
using Calculator.Core.Models;
using Calculator.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Calculator.Data.Services
{
    public class OperationService : IOperationService
    {
        //private readonly Task<IEnumerable<Operations>> _operations;
        private readonly IOperation _operations;
        private readonly IOperationRepository _repository;
        //private readonly new Dictionary<string, Operation> _operationsDelegate;

        public OperationService(IOperationRepository repository, IOperation operation)
        {
            _repository = repository;
            _operations = operation;
            //_operationsDelegate = new Dictionary<string, Operation>
            //{
            //    ["Add"] = new Operation
            //    {
            //        Name = "Add",
            //        Description = "Adds two numbers",
            //        Calculate = (a, b) => Convert.ToDecimal(a) + Convert.ToDecimal(b)
            //    },
            //    ["Subtract"] = new Operation
            //    {
            //        Name = "Subtract",
            //        Description = "Subtracts second number from first",
            //        Calculate = (a, b) => Convert.ToDecimal(a) - Convert.ToDecimal(b)
            //    },
            //    ["Multiply"] = new Operation
            //    {
            //        Name = "Multiply",
            //        Description = "Multiplies two numbers",
            //        Calculate = (a, b) => Convert.ToDecimal(a) * Convert.ToDecimal(b)
            //    },
            //    ["Divide"] = new Operation
            //    {
            //        Name = "Divide",
            //        Description = "Divides first number by second",
            //        Calculate = (a, b) => Convert.ToDecimal(b) != 0 ? Convert.ToDecimal(a) / Convert.ToDecimal(b) : throw new DivideByZeroException()
            //    }
            //    ,
            //    ["Concat"] = new Operation
            //    {
            //        Name = "Concat",
            //        Description = "Concat two strings",
            //        Calculate = (a, b) => Convert.ToString(b).Concat(Convert.ToString(a))
            //    }
            //};
        }

        public async Task<CalculationResult> CalculateAsync(CalculationRequest request)
        {
            //_operations.ContainsKey(request.OperationType
            string operation = _operations.GetOperationsAsync().Result.FirstOrDefault(o => o.Equals(request.OperationType));
            if (operation==null)
                  throw new ArgumentException("Invalid operation type", nameof(request.OperationType));

            var OperationType = request.OperationType;
            //_operations[request.OperationType];
            OperationsList operationsList = new OperationsList();
            var result = new CalculationResult
            {
                FieldA = request.FieldA.ToString(),
                FieldB = request.FieldB.ToString(),
                Operation = OperationType,
                Result = operationsList.GetResult(OperationType,request.FieldA, request.FieldB),
                CalculationTime = DateTime.UtcNow
            };

            await _repository.SaveCalculationResultAsync(result);
            return result;
        }

        public async Task<IEnumerable<string>> GetAvailableOperationsAsync()
        {
            return _operations.GetOperationsAsync().Result;
        }

        public async Task<IEnumerable<CalculationResult>> GetRecentOperationsAsync(string operationType, int count)
        {
            return await _repository.GetRecentOperationsAsync(operationType, count);
        }

        public async Task<int> GetMonthlyOperationCountAsync(string operationType)
        {
            return await _repository.GetMonthlyOperationCountAsync(operationType);
        }
    }
}
