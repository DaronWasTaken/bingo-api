using System.Net;
using System.Text.Json;
using bingo_api.Models.Views;
using bingo_api.Services;

namespace bingo_api.Models.Services.Auth;

public class AuthServiceV2 : IAuthService
{
    private readonly IUserService _userService;
    private readonly string _baseUri;

    public AuthServiceV2(IConfiguration configuration, IUserService userService)
    {
        _userService = userService;
        _baseUri = configuration.GetValue<string>("AUTH_URI");
    }

    public async Task<TokenDto> Login(LoginUserDto userDto)
    {
        var uri = _baseUri + "/login";
        var client = new HttpClient();
        var form = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
        {
            new("username", userDto.username),
            new("password", userDto.password)
        });
        var res = await client.PostAsync(uri, form);
        res.EnsureSuccessStatusCode();
        var resBody = await res.Content.ReadAsStringAsync();
        var tokenDto = JsonSerializer.Deserialize<TokenDto>(resBody);
        return tokenDto;
    }
    
    public async Task<bool> Register(RegisterUserDto userDto)
    {
        var uri = _baseUri + "/register";
        var client = new HttpClient();
        var form = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
        {
            new("username", userDto.Username),
            new("password", userDto.Password)
        });
        var res = await client.PostAsync(uri, form);

        if (res.StatusCode != HttpStatusCode.Created)
        {
            return false;
        }

        var user = new User
        {
            UserName = userDto.Username,
            PasswordHash = userDto.Password,
            LevelNumber = 1,
            Points = 0
        };
        
        await _userService.InitializeNewUserData(user);
        
        return true;
    }

    public async Task<TokenDto> Refresh(string refreshToken)
    {
        var uri = _baseUri + "/refresh";
        var client = new HttpClient();
        var form = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
        {
            new("refresh_token", refreshToken),
        });
        var res = await client.PostAsync(uri, form);
        res.EnsureSuccessStatusCode();
        var resBody = await res.Content.ReadAsStringAsync();
        var tokenDto = JsonSerializer.Deserialize<TokenDto>(resBody);
        return tokenDto;
    }
}