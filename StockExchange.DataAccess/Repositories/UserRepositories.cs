using Microsoft.EntityFrameworkCore;
using StockExchange.Core.Interfaces;
using StockExchange.Core.Models;
using StockExchange.DataAccess.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.DataAccess.Repositories
{
    public class UserRepositories : IUserRpository
    {
        private readonly DataExchangeDbContext _dbContext;
        public UserRepositories(DataExchangeDbContext context) 
        {
            _dbContext = context;
        }

        public async Task Add(User user)
        {
            var userEntity = new UserEntity
            {
                Id = user.Id,
                Name = user.Name,
                PasswordHash = user.PasswordHash,
                Email = user.Email
            };

            await _dbContext.Users.AddAsync(userEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            var userEntity = await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email) ?? throw new Exception();
            return User.Creater(userEntity.Id, userEntity.Name,
                userEntity.PasswordHash, userEntity.Email); 
        }
    }
}
