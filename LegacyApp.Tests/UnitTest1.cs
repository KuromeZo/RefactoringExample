namespace LegacyApp.Tests;

public class UnitTest1
{
    [Fact]
    public void AddUserCheck()
    {
        var userService = new UserService();
        string firstName = "John";
        string lastName = "Doe";
        string email = "johndoe@gmail.com";
        DateTime dateOfBirth = DateTime.Parse("1982-03-21");
        int clientId = 1;
        
        bool result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        Assert.True(result);
    }
}