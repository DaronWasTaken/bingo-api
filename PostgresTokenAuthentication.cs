using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using bingo_api.Models.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace bingo_api;

public class PostgresTokenAuthentication : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly PostgresContext _dbContext;
    private readonly IConfiguration _configuration;

    public PostgresTokenAuthentication(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock,
        PostgresContext dbContext, IConfiguration configuration) : base(options, logger, encoder, clock)
    {
        _dbContext = dbContext;
        _configuration = configuration;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        if (string.IsNullOrEmpty(token))
        {
            return AuthenticateResult.Fail("No token provided.");
        }

        var handler = new JwtSecurityTokenHandler();
        if (!handler.CanReadToken(token))
        {
            return AuthenticateResult.Fail("Invalid token format.");
        }

        var jwtToken = handler.ReadJwtToken(token);
        var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "sub");
        var tokenTypeClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "token_type");
        
        if (userIdClaim == null || tokenTypeClaim is not { Value: "access_token" })
        {
            return AuthenticateResult.Fail("Invalid or inappropriate token type.");
        }
        
        var keyString = _configuration.GetValue<string>("Jwt:Key");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateAudience = false,
            ValidateIssuer = false,
            RequireExpirationTime = true,
            ValidateLifetime = true,
            IssuerSigningKey = key,
            ClockSkew = TimeSpan.FromMinutes(1)
        };
        
        try
        {
            handler.ValidateToken(token, tokenValidationParameters, out _);
        }
        catch (Exception ex)
        {
            return AuthenticateResult.Fail("Invalid token");
        }
        
        var tokenRecord = await _dbContext.Tokens
                                         .FirstOrDefaultAsync(t => t.UserId == userIdClaim.Value);

        if (tokenRecord == null || tokenRecord.AccessToken != token)
        {
            return AuthenticateResult.Fail("Invalid token or token does not match the current active session.");
        }

        var claims = new List<Claim> {
            new(ClaimTypes.NameIdentifier, userIdClaim.Value),
            new("token_type", "access_token")
        };
        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);

        return AuthenticateResult.Success(ticket);
    }
}
