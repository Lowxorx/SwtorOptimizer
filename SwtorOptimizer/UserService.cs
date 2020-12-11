using System.Linq;
using Microsoft.Extensions.Logging;
using SwtorOptimizer.Business.Database;
using SwtorOptimizer.Models;

namespace SwtorOptimizer
{
    public class UserService : IUserService
    {
        private readonly ISwtorOptimizerDatabaseService context;

        private readonly ILogger<UserService> logger;

        public UserService(ILogger<UserService> logger, ISwtorOptimizerDatabaseService context)
        {
            this.logger = logger;
            this.context = context;
        }

        public bool IsAnExistingUser(string userName)
        {
            return this.context.UserRepository.All().FirstOrDefault(e => e.Username == userName) != null;
        }

        public bool IsValidUserCredentials(string userName, string password)
        {
            this.logger.LogInformation($"Validating user [{userName}]");
            if (string.IsNullOrWhiteSpace(userName))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            var user = this.context.UserRepository.All().FirstOrDefault(e => e.Username == userName);

            if (user == null) return false;

            return user.Password == password;
        }
    }
}