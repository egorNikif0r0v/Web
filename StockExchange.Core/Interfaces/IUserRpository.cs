using StockExchange.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Core.Interfaces
{
    public interface IUserRpository
    {
        Task Add(User user);
        Task<User> GetByEmail(string email);
    }
}
