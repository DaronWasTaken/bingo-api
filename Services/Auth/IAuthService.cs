using bingo_api.Models.Views;

namespace bingo_api.Services.Auth;

public interface IAuthService
{
    public Task<TokenDto?> Login(LoginUserDto userDto);
    public Task Register(RegisterUserDto userDto);
    public Task<TokenDto> Refresh(string refreshToken);
}