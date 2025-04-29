using OAuthServer.Repository.ModelsDB;
using Microsoft.EntityFrameworkCore;
using OAuthServer.Midleware;
using OAuthServer.Repository.UserRepo;
using OAuthServer.Repository.ClientRepo;
using OAuthServer.Repository.Grant;
using OAuthServer.Services.UserService;
using OAuthServer.Services.ClientService;
using OAuthServer.Services.OAuthService;
using OAuthServer.Services.GrantService;
using OAuthServer.Services.Hash;
using OAuthServer.Services.AuthorizationService;
using Microsoft.AspNetCore.Authentication.Cookies;
using OAuthServer.Repository.GrantIdRepository;
using OAuthServer.Repository.JWT;
using OAuthServer.Repository.Key;
using OAuthServer.Services.CookieService;
using OAuthServer.Services.JwtService;
using OAuthServer.Services.Key;
using OAuthServer.Repository.GrantIdRepository;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()  // Allow any origin for development or trusted frontend apps
            .AllowAnyHeader()  // Allow all headers (important for APIs with dynamic headers)
            .AllowAnyMethod(); // Allow all HTTP methods
    });
});


builder.Services.AddDbContext<OAuthContex>(options =>
    options.UseInMemoryDatabase("OAuthContex"));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddSingleton<IGrantRepository, GrantRepositoryMem>();
builder.Services.AddSingleton<IKeyRepository, KeyRepository>();
builder.Services.AddScoped<IJwtRepository, JwtRepository>();
builder.Services.AddSingleton<IGrantIdRepository, GrantIdMemRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IOAuthService, OAuthService>(); 
builder.Services.AddScoped<IGrantService, GrantService>();
builder.Services.AddScoped<IKeyService, KeyService>();
builder.Services.AddScoped<IHasher, Hasher>();
builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();
builder.Services.AddScoped<ICookieService, CookieService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IJwtService, JwtService>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "OAuthAuthenticationCookie";
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(65); //can change
    });



builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();



var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();
// Configure the HTTP request pipeline.

app.UseCors("AllowAll");


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
