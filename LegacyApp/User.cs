using System;

namespace LegacyApp
{
    public class User
    {
        public object Client { get; internal set; }
        public DateTime DateOfBirth { get; set; }
        public string EmailAddress { get; internal set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool HasCreditLimit { get; internal set; }
        public int CreditLimit { get; internal set; }
    }
}