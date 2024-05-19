using System.ComponentModel.DataAnnotations;

namespace StockExchange.API.Contracts.Request
{
    public record UserRegisterRequest(
        [Required] string Name,
        [Required] string Password,
        [Required] string Email);
}
