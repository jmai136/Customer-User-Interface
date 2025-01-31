using GourmetShop.DataAccess.Entities;
using GourmetShop.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GourmetShop.DataAccess.Services
{
    public class AuthService
    {
        // FIXME: Pass in a connection string
        AuthRepository _authRepository;

        public AuthService(string connectionString)
        {
            _authRepository = new AuthRepository(connectionString);
        }

        public string GetPassword(string username)
        {
            return _authRepository.GetPassword(username);
        }

        // CHECKME: Do we need a separate email parameter? Because in the form you have username/email as a field, how does the email validator work?
        public int Register(User user, Authentication authentication)
        {
            authentication.Password = PasswordHasher.HashPassword(authentication.Password);

            return _authRepository.Register(user, authentication);
        }

        public int Login(string username, string password)
        {
            if (!PasswordHasher.VerifyPassword(password, GetPassword(username)))
                return -1;
                
            return _authRepository.GetUserId(username);
        }
    }
}
