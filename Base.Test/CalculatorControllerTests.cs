using Base;
using Base.Model;
using Base.Service;
using Base.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Base.Test;

public class CalculatorControllerTests
{
    private IArithmeticService _arithmeticService;

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

    public CalculatorControllerTests()
    {
        _arithmeticService = new ArithmeticService();
    }


    [Theory]
    [MemberData(nameof(AdditionTestData))]
    public void Test_Addition(decimal firstOperand, decimal secondOperand, decimal expected)
    {
        // Arrange
        CalculatorController controller = new CalculatorController(_arithmeticService);

        // Act 
        var result = controller.Get(Model.OperationType.Add, firstOperand, secondOperand);
        var okResult = result as OkObjectResult;

        // Assert
        Assert.NotNull(okResult);
        Assert.Equal(200, okResult.StatusCode);

        var operationResultModel = okResult.Value as OperationResultModel;
        Assert.NotNull(operationResultModel);
        Assert.True(operationResultModel.Success);
        Assert.Null(operationResultModel.Message);
        Assert.Equal(expected, operationResultModel.Data.Result);
    }


    [Theory]
    [MemberData(nameof(SubtractionTestData))]
    public void Test_Subtraction(decimal firstOperand, decimal secondOperand, decimal expected)
    {
        // Arrange
        CalculatorController controller = new CalculatorController(_arithmeticService);

        // Act 
        var result = controller.Get(Model.OperationType.Substract, firstOperand, secondOperand);
        var okResult = result as OkObjectResult;

        // Assert
        Assert.NotNull(okResult);
        Assert.Equal(200, okResult.StatusCode);

        var operationResultModel = okResult.Value as OperationResultModel;
        Assert.NotNull(operationResultModel);
        Assert.True(operationResultModel.Success);
        Assert.Null(operationResultModel.Message);
        Assert.Equal(expected, operationResultModel.Data.Result);
    }

    [Theory]
    [MemberData(nameof(DivitionTestData))]
    public void Test_Divition(decimal firstOperand, decimal secondOperand, decimal expected)
    {
        // Arrange
        CalculatorController controller = new CalculatorController(_arithmeticService);

        // Act 
        var result = controller.Get(Model.OperationType.Devide, firstOperand, secondOperand);
        var okResult = result as OkObjectResult;

        // Assert
        Assert.NotNull(okResult);
        Assert.Equal(200, okResult.StatusCode);

        var operationResultModel = okResult.Value as OperationResultModel;
        Assert.NotNull(operationResultModel);
        Assert.True(operationResultModel.Success);
        Assert.Null(operationResultModel.Message);
        Assert.Equal(expected, operationResultModel.Data.Result);
    }

    [Theory]
    [MemberData(nameof(MultiplyTestData))]
    public void Test_Multiplication(decimal firstOperand, decimal secondOperand, decimal expected)
    {
        // Arrange
        CalculatorController controller = new CalculatorController(_arithmeticService);

        // Act 
        var result = controller.Get(Model.OperationType.Multiply, firstOperand, secondOperand);
        var okResult = result as OkObjectResult;

        // Assert
        Assert.NotNull(okResult);
        Assert.Equal(200, okResult.StatusCode);

        var operationResultModel = okResult.Value as OperationResultModel;
        Assert.NotNull(operationResultModel);
        Assert.True(operationResultModel.Success);
        Assert.Null(operationResultModel.Message);
        Assert.Equal(expected, operationResultModel.Data.Result);
    }

    [Fact]
    public void Test_BadRequest_Devidion_By_Zero()
    {
        // Arrange
        CalculatorController controller = new CalculatorController(_arithmeticService);

        // Act 
        var result = controller.Get(OperationType.Devide, 1, 0);
        var badRequestReslut = result as BadRequestObjectResult;

        // Assert
        Assert.NotNull(badRequestReslut);
        Assert.Equal(400, badRequestReslut.StatusCode);

        var operationResultModel = badRequestReslut.Value as OperationResultModel;
        Assert.NotNull(operationResultModel);
        Assert.False(operationResultModel.Success);
        Assert.Equal("Cannot devide by zero", operationResultModel.Message);
    }
}
