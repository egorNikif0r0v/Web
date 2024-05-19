using StockExchange.Application.Interfaces;
using StockExchange.Application.Interfaces.Auth;
using StockExchange.Core.Interfaces;
using StockExchange.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Application.Services
{
    public class UserService 
    {
        private readonly IUserRpository _userRpository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;

        public UserService(
            IUserRpository userRpository,
            IPasswordHasher passwordHasher,
            IJwtProvider jwtProvider)
        {
            _userRpository = userRpository;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
        }

        public async Task Register(string name, 
            string email, string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);
            var user = User.Creater(Guid.NewGuid(), name,
                password, email);
            await _userRpository.Add(user);
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _userRpository.GetByEmail(email);

            var result = _passwordHasher.Verify(password, user.PasswordHash);

            if (!result)
                throw new Exception("Password Not Found");


            var token = _jwtProvider.GenerateToken(user);
            return token;


            // проверить email password
            // создать токен
            // сохранить куки
        }
    }
}
