using System.Net;
using System.Text.Json;
using bingo_api.Models.Entities;
using bingo_api.Models.Views;
using bingo_api.Services;
using bingo_api.Services.Auth;
using BadHttpRequestException = Microsoft.AspNetCore.Server.Kestrel.Core.BadHttpRequestException;

namespace bingo_api.Models.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IUserService _userService;
    private readonly string _baseUri;
    private readonly HttpClient _httpClient;

    public AuthService(IConfiguration configuration, IUserService userService, HttpClient httpClient)
    {
        _userService = userService;
        _httpClient = httpClient;
        _baseUri = configuration.GetValue<string>("AUTH_URI");
    }

    public async Task<TokenDto> Login(LoginUserDto userDto)
    {
        var uri = _baseUri + "/login";
        var form = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
        {
            new("username", userDto.username),
            new("password", userDto.password)
        });
        var res = await _httpClient.PostAsync(uri, form);
        res.EnsureSuccessStatusCode();
        var resBody = await res.Content.ReadAsStringAsync();
        var tokenDto = JsonSerializer.Deserialize<TokenDto>(resBody);
        return tokenDto;
    }
    
    public async Task Register(RegisterUserDto userDto)
    {
        var uri = _baseUri + "/register";
        
        var res = await _httpClient.PostAsJsonAsync(uri, userDto);

        if (res.StatusCode == HttpStatusCode.BadRequest)
        {
            throw new Microsoft.AspNetCore.Http.BadHttpRequestException("Username already exists");
        }

        if (res.StatusCode != HttpStatusCode.OK)
        {
            throw new HttpRequestException("Could not register the user");
        }

        var user = new User
        {
            Id = await res.Content.ReadAsStringAsync(),
            Username = userDto.Username,
            PasswordHash = userDto.Password,
            LevelId = 1,
            Points = 0
        };
        
        await _userService.InitializeNewUserData(user);
    }

    public async Task<TokenDto> Refresh(string refreshToken)
    {
        var uri = _baseUri + "/refresh";
        var form = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
        {
            new("refresh_token", refreshToken),
        });
        var res = await _httpClient.PostAsync(uri, form);
        res.EnsureSuccessStatusCode();
        var resBody = await res.Content.ReadAsStringAsync();
        var tokenDto = JsonSerializer.Deserialize<TokenDto>(resBody);
        return tokenDto;
    }
}