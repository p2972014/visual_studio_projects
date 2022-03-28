using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace WinFormsAppOAuth
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string
                user_Id = "1",
                Secret = "thisismycustomSecretkeyforauthentication"
                ,
                //securityAlgorithmSignature = SecurityAlgorithms.RsaSha256Signature,
                //securityAlgorithm = SecurityAlgorithms.RsaSha256,

                securityAlgorithmSignature = SecurityAlgorithms.HmacSha256Signature,
                securityAlgorithm = SecurityAlgorithms.HmacSha256,

                Issuer = "https://ssotest.ingos.ru",
                Audience = "https://ssotest.ingos.ru"
                ;
            DateTime valid_to_utc = DateTime.UtcNow.AddDays(7);
            Claim[] claims =
                new[]
                {
                    new Claim("id", user_Id),
                    new Claim("mykey1", "myval1")
                };
            var secret_bytes = Encoding.
                //ASCII
                UTF8
                .GetBytes(Secret);

            var securityKey = new SymmetricSecurityKey(secret_bytes);

            //byte[] PublicKey = { 214, 46, 220, 83 };
            //byte[] PublicKey2 = { 214, 46 };
            //var securityKey = new RsaSecurityKey(new RSAParameters() { Modulus = PublicKey, Exponent = PublicKey2 });

            var token = GenerateToken(securityKey, securityAlgorithmSignature, valid_to_utc, claims, Issuer, Audience);
            var tmp = ValidateToken(token, securityKey, securityAlgorithm, Issuer, Audience);

            var qqq = 0;
        }

        public string GenerateToken(
            SecurityKey securityKey,
            string securityAlgorithmSignature, // SecurityAlgorithms.HmacSha256Signature
            DateTime valid_to_utc,
            Claim[] claims,
            string Issuer,
            string Audience
            )
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var signingCredentials = new SigningCredentials(securityKey, securityAlgorithmSignature);
            var valid_from_utc = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                IssuedAt = valid_from_utc,
                Expires = valid_to_utc,
                SigningCredentials = signingCredentials,
                Issuer = Issuer,
                Audience = Audience
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public JwtSecurityToken ValidateToken(
            string token,
            SecurityKey securityKey,
            string securityAlgorithm,
            string Issuer,
            string Audience
            )
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = securityKey,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = Issuer,
                    ValidAudience = Audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidAlgorithms = new[] { securityAlgorithm }
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                return jwtToken;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}