﻿using bingo_api.Models.Views;

namespace bingo_api.Models.Services.Auth;

public interface IAuthService
{
    public Task<string> Login(LoginUserDto userDto);
    public Task Register(LoginUserDto userDto);
}