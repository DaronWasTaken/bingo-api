using bingo_api.Models.Views;

namespace bingo_api.Models.Services.Auth;

public interface IAuthService
{
    public Task<TokenDto?> Login(LoginUserDto userDto);
    public Task<bool> Register(RegisterUserDto userDto);
    public Task<TokenDto> Refresh(string refreshToken);
}