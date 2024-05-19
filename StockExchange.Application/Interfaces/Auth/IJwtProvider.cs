using StockExchange.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange.Application.Interfaces.Auth
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}
