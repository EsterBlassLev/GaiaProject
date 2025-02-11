using Calculator.Core.Interfaces;
using Calculator.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly IOperationService _operationService;

        public CalculatorController(IOperationService operationService)
        {
            _operationService = operationService;
        }

        [HttpGet("operations")]
        public async Task<ActionResult<IEnumerable<string>>> GetOperations()
        {
            var operations = await _operationService.GetAvailableOperationsAsync();
            return Ok(operations);
        }

        [HttpPost("calculate")]
        public async Task<ActionResult<CalculationResult>> Calculate(CalculationRequest request)
        {
            try
            {
                var result = await _operationService.CalculateAsync(request);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DivideByZeroException)
            {
                return BadRequest("Division by zero is not allowed");
            }
        }

        [HttpGet("history/{operationType}")]
        public async Task<ActionResult<IEnumerable<CalculationResult>>> GetHistory(string operationType)
        {
            var history = await _operationService.GetRecentOperationsAsync(operationType, 3);
            return Ok(history);
        }

        [HttpGet("monthly-count/{operationType}")]
        public async Task<ActionResult<int>> GetMonthlyCount(string operationType)
        {
            var count = await _operationService.GetMonthlyOperationCountAsync(operationType);
            return Ok(count);
        }
    }
}
