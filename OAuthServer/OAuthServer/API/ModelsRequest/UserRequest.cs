﻿namespace OAuthServer.API.Request;

public class UserRequest
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}
