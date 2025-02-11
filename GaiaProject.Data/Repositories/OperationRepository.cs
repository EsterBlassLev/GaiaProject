using Calculator.Core.Models;
using Calculator.Data.CalculationDbContext;
using Calculator.Data.Entities;
using Calculator.Data.Interfaces;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Data.Repositories
{
    public class OperationRepository : IOperationRepository
    {
        private readonly CalcDbContext _context;

        public OperationRepository(CalcDbContext context)
        {
            _context = context;
        }

        public async Task SaveCalculationResultAsync(CalculationResult result)
        {
            int op = _context.Operations.Where(o => o.Name == result.Operation).Select(op => op.OperationId).FirstOrDefault();
            var history = new CalculationHistory
            {

                FieldA = result.FieldA,
                FieldB = result.FieldB,
                OperationId = op,
                Result = result.Result,
                CalculationTime = result.CalculationTime
            };

            _context.OperationHistory.Add(history);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CalculationResult>> GetRecentOperationsAsync(string operationType, int count)
        {
            int op = _context.Operations.Where(o => o.Name == operationType).Select(op => op.OperationId).FirstOrDefault();
            return await _context.OperationHistory
                .Where(h => h.OperationId == op)
                .OrderByDescending(h => h.CalculationTime)
                .Take(count)
                .Select(h => new CalculationResult
                {
                    FieldA = h.FieldA,
                    FieldB = h.FieldB,
                    Operation = operationType,
                    Result = h.Result,
                    CalculationTime = h.CalculationTime
                })
                .ToListAsync();
        }

        public async Task<int> GetMonthlyOperationCountAsync(string operationType)
        {
            int op = _context.Operations.Where(o => o.Name == operationType).Select(op => op.OperationId).FirstOrDefault();
            var startOfMonth = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);
            return await _context.OperationHistory
                .CountAsync(h => h.OperationId == op && h.CalculationTime >= startOfMonth);
        }
    }
}
