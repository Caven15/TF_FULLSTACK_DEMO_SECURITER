using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DemoSecurityAPI.Infrasctructure
{
    public class TokenManager
    {
        private readonly IConfiguration _configuration;
        public readonly string _secret;
        public readonly string _issuer;
        public readonly string _audiance;

        public TokenManager(IConfiguration cofiguration)
        {
            // Initialisation de mon instance d'objets avec la configuration fournie
            _configuration = cofiguration;
            _secret = _configuration["jwt:key"];
            _issuer = _configuration["jwt:issuer"];
            _audiance = _configuration["jwt:audiance"];
        }


        public string GenerateJwt(dynamic user, int expirationDate = 1)
        {
            // Création de mes crédentials pour signer le token
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            DateTime now = DateTime.Now;

            // Création des revendications pour les stocker dans le token
            Claim[] myClaims = new Claim[]
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.GivenName, user.Nom),
                new Claim(ClaimTypes.Expiration, now.AddHours(expirationDate).ToString(), ClaimValueTypes.DateTime),
                new Claim(ClaimTypes.Role, user.RoleId.ToString())
            };

            JwtSecurityToken token = new JwtSecurityToken(
                claims: myClaims,
                expires: now.AddHours(expirationDate),
                signingCredentials: credentials,
                audience: _audiance,
                issuer: _issuer
            );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
    }
}
