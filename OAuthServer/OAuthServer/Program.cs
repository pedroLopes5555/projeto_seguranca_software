using OAuthServer.Repository.Models;
using Microsoft.EntityFrameworkCore;
using OAuthServer.Repository.UserRepo;
using OAuthServer.Repository.ClientRepo;
using OAuthServer.Services.UserServices;


var builder = WebApplication.CreateBuilder(args);




builder.Services.AddDbContext<OAuthContex>(options =>
    options.UseInMemoryDatabase("OAuthContex"));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IUserService, UserService>();





builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();