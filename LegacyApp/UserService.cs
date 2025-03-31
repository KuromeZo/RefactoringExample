using System;

namespace LegacyApp
{
    public class UserService : IUserService
    {
        private readonly IClientRepository _clientRepository;
        private readonly ICreditLimitService _creditLimitService;
        private readonly UserValidator _userValidator;
        private readonly UserFactory _userFactory;
        
        public UserService()
        {
            _clientRepository = new ClientRepository();
            _creditLimitService = new UserCreditService();
            _userValidator = new UserValidator();
            _userFactory = new UserFactory();
        }
        
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!_userValidator.ValidateUser(firstName, lastName, email, dateOfBirth))
            {
                return false;
            }

            var client = _clientRepository.GetById(clientId);

            var user = _userFactory.CreateUser(firstName, lastName, email, dateOfBirth, client);

            var creditLimitCalculator = new CreditLimitCalculator(_creditLimitService);
            creditLimitCalculator.CalculateCreditLimit(user, client);

            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }
    }
}
