using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace NextLua.Business.Token;
public class InvalidatedTokenMethod
{
    public class InvalidatedTokens
    {
         public static List<string> Tokens { get; set; }= new List<string>();
    }

    public static void InvalidateToken(string token) {
        InvalidatedTokens.Tokens.Add(token);
    }

// Check if a token is invalid
    public static bool IsTokenInvalid(string token) {
        return InvalidatedTokens.Tokens.Contains(token);
    }

//Validate the token
    public static bool ValidateToken(string token) {
        try {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
            var jti = jsonToken.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
            if (IsTokenInvalid(jti)) {
                return false;
            }
        } catch (Exception) {
            return false;
        }
        return true;
    }
    public static bool IsTokenExpired(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
        var expiration = jsonToken.ValidTo;
        if (expiration < DateTime.UtcNow)
        {
            return true;
        }
        return false;
    }
}