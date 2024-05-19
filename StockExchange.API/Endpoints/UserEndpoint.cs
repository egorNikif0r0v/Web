using StockExchange.API.Contracts.Request;
using StockExchange.Application.Services;

namespace StockExchange.API.Endpoints
{
    public static class UserEndpoint
    {

        public static IEndpointRouteBuilder MapUsersEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapPost("registr", Registr);
            app.MapPost("ligin", Login);

            return app;
        }

        private static async Task<IResult> Registr(
            UserService usesrService,
            UserRegisterRequest request)
        {
            await usesrService.Register(
               request.Name,
               request.Email,
               request.Password);
            return Results.Ok();
        }
        private static async Task<IResult> Login(
            UserService usesrService,
            UserLoginRequest request)
        {
            var token = usesrService.Login(request.Email, request.Password);

            return Results.Ok(token);
        }
    }
}
