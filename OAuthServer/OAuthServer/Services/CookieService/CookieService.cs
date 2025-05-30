﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using OAuthServer.Exeptions;

namespace OAuthServer.Services.CookieService
{
    public class CookieService : ICookieService
    {
        public async Task CreateAuthenticationCookieAsync(HttpContext httpContext, Guid userId, string username)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Name, username)
            };

            var claimsIdentity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
            };

            await httpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties
            );
        }

        public bool IsUserLoggedIn(HttpContext httpContext)
        {
            return httpContext.User.Identity?.IsAuthenticated ?? false;
        }

        public string GetUserIdFromCookie(HttpContext httpContext)
        {
            var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if(userId == null)
            {
                throw new NotFoundException("User is not logged in");
            }
            return userId;
        }
    }
}
