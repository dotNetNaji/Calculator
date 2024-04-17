using Base.Model;
using Base.Service;
using Microsoft.AspNetCore.Mvc;

namespace Base.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly IArithmeticService _arithmeticService;
        public CalculatorController(IArithmeticService arithmeticService)
        {
            _arithmeticService = arithmeticService;
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        [HttpGet]
        public IActionResult Get([FromQuery] OperationType operationType, decimal firstOperand, decimal secondOperand)
        {
            var operationResultModel = new OperationResultModel();
            try
            {
                switch (operationType)
                {
                    case OperationType.Add:
                        operationResultModel.Data = new Data
                        {
                            Result = _arithmeticService.Add(firstOperand, secondOperand),
                        };
                        break;
                    case OperationType.Substract:
                        operationResultModel.Data = new Data
                        {
                            Result = _arithmeticService.Subtract(firstOperand, secondOperand),
                        };
                        break;
                    case OperationType.Multiply:
                        operationResultModel.Data = new Data
                        {
                            Result = _arithmeticService.Multiply(firstOperand, secondOperand),
                        };
                        break;

                    case OperationType.Devide:
                        operationResultModel.Data = new Data
                        {
                            Result = _arithmeticService.Devide(firstOperand, secondOperand),
                        };
                        break;

                    default:
                        operationResultModel.Success = false;
                        operationResultModel.Message = "Unvaid OperationType";
                        return BadRequest(operationResultModel);
                }
            }
            catch (DivideByZeroException)
            {
                operationResultModel.Success = false;
                operationResultModel.Message = "Cannot devide by zero";
                return BadRequest(operationResultModel);
            }
            operationResultModel.Success = true;
            return Ok(operationResultModel);

        }
    }
}
