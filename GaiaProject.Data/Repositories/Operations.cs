using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Data.CalculationDbContext;
using Calculator.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Calculator.Data.Repositories
{
    public class Operations:IOperation
    {
        private readonly CalcDbContext _context;

        public Operations(CalcDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<string>> GetOperationsAsync()
        {
            return await _context.Operations.Select(o=>o.Name).ToListAsync();
        }
    }
}
