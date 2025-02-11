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
        private readonly IOperation _operations;
        private readonly IOperationRepository _repository;

        public OperationService(IOperationRepository repository, IOperation operation)
        {
            _repository = repository;
            _operations = operation;
        }

        public async Task<CalculationResult> CalculateAsync(CalculationRequest request)
        {
            string operation = _operations.GetOperationsAsync().Result.FirstOrDefault(o => o.Equals(request.OperationType));
            if (operation==null)
                  throw new ArgumentException("Invalid operation type", nameof(request.OperationType));

            var OperationType = request.OperationType;
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
