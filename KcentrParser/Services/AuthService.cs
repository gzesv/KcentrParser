using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace KcentrParser.Services;

public class AuthService : IAuthService
{
    private readonly string Key;

    public AuthService(IConfiguration configuration)
    {
        Key = configuration["SecurityKey"];
    }

    public string GetToken(string login)
    {
        var claims = new List<Claim> {new Claim(ClaimTypes.Name, login) };

        var jwt = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(3),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key)), 
                    SecurityAlgorithms.HmacSha256));
        
        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}