using Base.Service;

namespace Base.Services.Tests
{
    public class ArithmeticServiceTests
    {
        private IArithmeticService sut;

        public static TheoryData<decimal, decimal, decimal> AdditionTestData =>
        new()
        {
            { 1.6m, 9.2m, 10.8m},
            { 3.1m, -0.1m, 3m},
            { 5.2m, 6m, 11.2m},
        };

        public static TheoryData<decimal, decimal, decimal> SubtractionTestData =>
        new()
        {
            { 1.6m, 9.2m, -7.6m},
            { 3.1m, -0.1m, 3.2m},
            { 5.2m, 6m, -0.8m},
        };

        public static TheoryData<decimal, decimal, decimal> DivitionTestData =>
        new()
        {
            { 7m, 2m, 3.5m},
            { 1m, 20m, 0.05m},
            { 0m, 6m, 0m},
        };
        public static TheoryData<decimal, decimal, decimal> MultiplyTestData =>
        new()
        {
            { 7m, 2m, 14m},
            { 1m, -20m, -20m},
            { 0m, 6m, 0m},
        };

        public ArithmeticServiceTests()
        {
            sut = new ArithmeticService();
        }

        [Theory]
        [MemberData(nameof(AdditionTestData))]
        public void Test_Addition(decimal firstOperand, decimal secondOperand, decimal expected)
        {
            // Act 
            var result = sut.Add(firstOperand, secondOperand);

            // Assert
            Assert.Equal(expected, result);
        }


        [Theory]
        [MemberData(nameof(SubtractionTestData))]
        public void Test_Subtraction(decimal firstOperand, decimal secondOperand, decimal expected)
        {
            // Act 
            var result = sut.Subtract(firstOperand, secondOperand);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(MultiplyTestData))]
        public void Test_Multiplation(decimal firstOperand, decimal secondOperand, decimal expected)
        {
            // Act 
            var result = sut.Multiply(firstOperand, secondOperand);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(DivitionTestData))]
        public void Test_Divition(decimal firstOperand, decimal secondOperand, decimal expected)
        {
            // Act 
            var result = sut.Devide(firstOperand, secondOperand);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test_Divition_Zero_Divition()
        {
            // Act && Assert
            Assert.Throws<DivideByZeroException>(() => sut.Devide(1, 0));
        }

    }
}