using Microsoft.EntityFrameworkCore;
using StockExchange.API.Endpoints;
using StockExchange.API.Filters;
using StockExchange.Application.Interfaces.Auth;
using StockExchange.Application.Services;
using StockExchange.Core.Interfaces;
using StockExchange.DataAccess;
using StockExchange.DataAccess.Repositories;
using StockExchange.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddDbContext<DataExchangeDbContext>(
    option =>
    {
        option.UseSqlServer(builder.Configuration.GetConnectionString(nameof(DataExchangeDbContext)));
    });

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository, BookRepositories>();

builder.Services.AddScoped<IUserRpository, UserRepositories>();

builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();

builder.Services.AddScoped<MyActionAttribute>();
builder.Services.AddScoped<UserService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapUsersEndpoint();
app.UseAuthorization();

app.MapControllers();

app.Run();
