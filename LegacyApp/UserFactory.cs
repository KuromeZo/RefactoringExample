using System;

namespace LegacyApp;

public class UserFactory
{
    public User CreateUser(string firstName, string lastName, string email, DateTime dateOfBirth, Client client)
    {
        return new User
        {
            Client = client,
            DateOfBirth = dateOfBirth,
            EmailAddress = email,
            FirstName = firstName,
            LastName = lastName
        };
    }
}