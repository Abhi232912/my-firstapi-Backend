using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace MyFirstWebApi.Services
{
    public class AuthService: IAuthService
    {
        public IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJWTToken(string username)
        {
            // User authentication logic here (e.g., validate username and password against a database)

            // If authentication is successful, generate a JWT token
            // Define claims for the token (e.g., username, roles)
            // In a real application, you would retrieve user roles and other claims from your database
            // For demonstration purposes, we'll just create a simple claim with the username and a role
            // In a real application, you would also include claims for user ID, email, etc., as needed
            // You can also include custom claims based on your application's requirements
            // For example, if the user has an "Admin" role, you can add that as a claim
            // Note: In a real application, you should not hardcode roles or claims. Instead, retrieve them from your user management system.
            // Example claims for demonstration purposes
     
            var claims = new[]
            { 
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "Admin") 
            };

            // Generate a symmetric security key using the secret key from configuration
            // The secret key should be a long, random string stored securely (e.g., in appsettings.json or environment variables)
            var key =new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            // Create signing credentials using the security key and a hashing algorithm
            // The signing credentials are used to sign the JWT token, ensuring its integrity and authenticity

            var creds= new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var token= new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(15), // Set token expiration time (e.g., 1 hour)
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
