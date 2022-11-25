﻿using delivery_backend_module3.Models.Dtos;

namespace delivery_backend_module3.Services.Interfaces;

public interface IUsersService
{
    public Task<TokenDto> RegisterUser(UserRegisterModel userRegisterDto);
    
    public Task<TokenDto> LoginUser(LoginCredentials loginCredentials);
    
    public Task<Response> LogoutUser(HttpContext httpContext);
    
    public Task<UserDto> GetProfile(string email);

    public Task EditProfile(EditUserDto editedUserDto, string email);
}