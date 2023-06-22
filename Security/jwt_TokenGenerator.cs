using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace tienda_electronica_api_server.Security;

public class jwt_TokenGenerator
{
    /// <summary>
    /// ESTA CLASE GENERA EL TOKEN JWT DINAMICAMENTE PARA ADJUNTARLO AL PAYLOAD DEL USUARIO EN LA AUTENTICACION
    /// </summary>
    /// <returns></returns>
    public string GenerateToken()
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("83b2d62c297f4f42677b3ae1a083e03989f9dbfdb04d1a145f436d872094c634");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "83b2d62c297f4f42677b3ae1a083e03989f9dbfdb04d1a145f436d872094c634"),
                
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);
      
        
        return "Bearer " + tokenString;
    }
}