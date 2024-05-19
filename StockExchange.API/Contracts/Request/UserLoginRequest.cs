using System.ComponentModel.DataAnnotations;

namespace StockExchange.API.Contracts.Request
{
    public record UserLoginRequest(
        [Required] string Password,
        [Required] string Email);
}
