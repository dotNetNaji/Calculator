using Base.Model;

namespace Base.Service
{
    public interface IArithmeticService
    {
        decimal Add( decimal firstOperand, decimal secondOperand);

        decimal Subtract(decimal firstOperand, decimal secondOperand);

        decimal Devide(decimal firstOperand, decimal secondOperand);

        decimal Multiply(decimal firstOperand, decimal secondOperand);
    }
}
