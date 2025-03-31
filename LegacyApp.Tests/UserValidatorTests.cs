namespace LegacyApp.Tests;
using Xunit;

public class UserValidatorTests
{
    private UserValidator _validator;

    public UserValidatorTests()
    {
        _validator = new UserValidator();
    }

    [Fact]
    public void ValidateUser_WithValidData_ReturnsTrue()
    {
        string firstName = "Mart";
        string lastName = "Zan";
        string email = "zanmart@test.com";
        DateTime dateOfBirth = DateTime.Today.AddYears(-30);
        
        bool result = _validator.ValidateUser(firstName, lastName, email, dateOfBirth);
        
        Assert.True(result);
    }

    [Fact]
    public void ValidateUser_WithEmptyFirstName_ReturnsFalse()
    {
        string firstName = "";
        string lastName = "Zan";
        string email = "zanmart@test.com";
        DateTime dateOfBirth = DateTime.Today.AddYears(-30);
        
        bool result = _validator.ValidateUser(firstName, lastName, email, dateOfBirth);
        
        Assert.False(result);
    }

    [Fact]
    public void ValidateUser_WithInvalidEmail_ReturnsFalse()
    {
        string firstName = "Mart";
        string lastName = "Zan";
        string email = "invalidemail";
        DateTime dateOfBirth = DateTime.Today.AddYears(-30);
        
        bool result = _validator.ValidateUser(firstName, lastName, email, dateOfBirth);
        
        Assert.False(result);
    }
    
    [Fact]
    public void ValidateUser_WithAgeLessThan21_ReturnsTrue()
    {
        string firstName = "Mart";
        string lastName = "Zan";
        string email = "zanmart@test.com";
        DateTime dateOfBirth = DateTime.Today.AddYears(-18);
        
        bool result = _validator.ValidateUser(firstName, lastName, email, dateOfBirth);
        
        Assert.False(result);
    }
}