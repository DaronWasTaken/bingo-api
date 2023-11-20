using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using bingo_api.Models.Views;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace bingo_api.Models.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<User> _userManager;

    public AuthService(UserManager<User> userManager, IConfiguration configuration)
    {
        _configuration = configuration;
        _userManager = userManager;
    }

    public async Task<TokenDto> Login(LoginUserDto loginUserDto)
    {
        var user = await _userManager.FindByNameAsync(loginUserDto.username);
        
        if (user == null)
            throw new Exception("Incorrect password or username");

        var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, loginUserDto.password);

        if (!isPasswordCorrect)
        {
            throw new UnauthorizedAccessException("Incorrect password or username");
        }

        var token = GenerateTokenString(user);

        if (token == null)
        {
            throw new Exception("GenerateTokenException");
        }

        return token;
    }

    public Task Register(LoginUserDto userDto)
    {
        throw new NotImplementedException();
    }

    private TokenDto GenerateTokenString(User user)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Iat, DateTimeOffset.Now.ToUnixTimeSeconds().ToString())
        };

        var keyString = _configuration.GetValue<string>("Jwt:Key");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //TODO: Parametrize the fuck out of it
        SecurityToken securityToken = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(60),
            issuer: _configuration.GetValue<string>("Jwt:Issuer"),
            audience: _configuration.GetValue<string>("Jwt:Audience"),
            signingCredentials: cred
        );
        var tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);

        var tokenResponse = new TokenDto
        {
            access_token = tokenString,
            expires_in = (int)TimeSpan.FromHours(1).TotalSeconds
        };

    return tokenResponse;
    }
}