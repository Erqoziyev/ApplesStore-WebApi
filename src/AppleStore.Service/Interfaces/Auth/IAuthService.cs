﻿using AppleStore.Service.Dtos.Auth;

namespace AppleStore.Service.Interfaces.Auth;

public interface IAuthService
{

    public Task<(bool Result, int CachedMinutes)> RegisterAsync(RegistorDto dto);

    public Task<(bool Result, int CachedVerificationMinutes)> SendCodeForRegisterAsync(string phone);

    public Task<(bool Result, string Token)> VerifyRegisterAsync(string phone, int code);

    public Task<(bool Result, string Token)> LoginAsync(LoginDto loginDto);
}
