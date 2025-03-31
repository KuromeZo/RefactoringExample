using System;

namespace LegacyApp;

public class CreditLimitCalculator
{
    private readonly ICreditLimitService _creditLimitService;

    public CreditLimitCalculator(ICreditLimitService creditLimitService)
    {
        _creditLimitService = creditLimitService ?? throw new ArgumentNullException(nameof(creditLimitService));
    }

    public void CalculateCreditLimit(User user, Client client)
    {
        if (client.Type == "VeryImportantClient")
        {
            user.HasCreditLimit = false;
        }
        else if (client.Type == "ImportantClient")
        {
            user.HasCreditLimit = true;
            int creditLimit = _creditLimitService.GetCreditLimit(user.LastName, user.DateOfBirth);
            creditLimit = creditLimit * 2;
            user.CreditLimit = creditLimit;
        }
        else
        {
            user.HasCreditLimit = true;
            int creditLimit = _creditLimitService.GetCreditLimit(user.LastName, user.DateOfBirth);
            user.CreditLimit = creditLimit;
        }
    }
}