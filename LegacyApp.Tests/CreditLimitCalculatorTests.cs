using Moq;
namespace LegacyApp.Tests;


public class CreditLimitCalculatorTests
{
    private Mock<ICreditLimitService> _mockCreditService;
    private CreditLimitCalculator _calculator;
    private User _user;

    public CreditLimitCalculatorTests()
    {
        _mockCreditService = new Mock<ICreditLimitService>();
        _calculator = new CreditLimitCalculator(_mockCreditService.Object);
        _user = new User
        { 
            FirstName = "John", 
            LastName = "Doe", 
            DateOfBirth = DateTime.Parse("1980-01-01") 
        };
    }

    [Fact]
    public void CalculateCreditLimit_ForVeryImportantClient_NoCreditLimit()
    {
        var client = new Client { Type = "VeryImportantClient"};
        
        _calculator.CalculateCreditLimit(_user, client);
        
        Assert.False(_user.HasCreditLimit);
    }

    [Fact]
    public void CalculateCreditLimit_ForNormalClient_SetsRegularLimit()
    {
        var client = new Client { Type = "NormalClient" };
        
        _mockCreditService.Setup(s => s.GetCreditLimit(It.IsAny<string>(), It.IsAny<DateTime>())).Returns(300);
        
        _calculator.CalculateCreditLimit(_user, client);
        
        Assert.True(_user.HasCreditLimit);
        Assert.Equal(300, _user.CreditLimit);
        
        _mockCreditService.Verify(s => s.GetCreditLimit(It.IsAny<string>(), It.IsAny<DateTime>()), Times.Once);
    }
    
    [Fact]
    public void CalculateCreditLimit_ForImportantClient_DoublesLimit()
    {
        var client = new Client { Type = "ImportantClient" };
        
        _mockCreditService.Setup(s => s.GetCreditLimit(It.IsAny<string>(), It.IsAny<DateTime>())).Returns(500);

        _calculator.CalculateCreditLimit(_user, client);

        Assert.True(_user.HasCreditLimit);
        Assert.Equal(1000, _user.CreditLimit);
        
        _mockCreditService.Verify(s => s.GetCreditLimit(It.IsAny<string>(), It.IsAny<DateTime>()), Times.Once);
    }
}