namespace Base.Service
{
    public class ArithmeticService : IArithmeticService
    {
        public decimal Add(decimal firstOperand, decimal secondOperand)
        {
            return firstOperand + secondOperand;
        }

        public decimal Devide(decimal firstOperand, decimal secondOperand)
        {
            if(secondOperand == 0)
            {
                throw new DivideByZeroException();
            }
            return firstOperand / secondOperand;
        }

        public decimal Multiply(decimal firstOperand, decimal secondOperand)
        {
            return firstOperand * secondOperand;
        }

        public decimal Subtract(decimal firstOperand, decimal secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }
}
