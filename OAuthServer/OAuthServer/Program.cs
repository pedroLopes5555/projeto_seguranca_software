using OAuthServer.Repository.ModelsDB;
using Microsoft.EntityFrameworkCore;
using OAuthServer.Midleware;
using OAuthServer.Repository.UserRepo;
using OAuthServer.Repository.ClientRepo;
using OAuthServer.Repository.Grant;
using OAuthServer.Services.UserServices;
using OAuthServer.Services.ClientService;
using OAuthServer.Services.OAuthService;
using OAuthServer.Services.GrantService;
using OAuthServer.Services.Hash;
using OAuthServer.Services.AuthorizationService;


var builder = WebApplication.CreateBuilder(args);




builder.Services.AddDbContext<OAuthContex>(options =>
    options.UseInMemoryDatabase("OAuthContex"));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddSingleton<IGrantRepository, GrantRepositoryMem>();


builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IOAuthService, OAuthService>(); 
builder.Services.AddScoped<IGrantService, GrantService>();
builder.Services.AddScoped<IHasher, Hasher>();
builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();




builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();



var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();