//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using OnlineShop.Domain.Entities;
//using System.Security.Claims;
//using System.IdentityModel.Tokens.Jwt;
//using Microsoft.IdentityModel.Tokens;
//using System.Text;
//using System.Net.Http.Headers;
//using System.Text.Json;
//using System.Text.Json.Serialization;
//using System.Threading.Tasks;

//namespace OnlineShop.API.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class AuthController : ControllerBase
//    {
//        private readonly UserManager<ApplicationUser> _userManager;
//        private readonly IConfiguration _configuration;

//        public AuthController(
//            UserManager<ApplicationUser> userManager,
//            IConfiguration configuration)
//        {
//            _userManager = userManager;
//            _configuration = configuration;
//        }

//        [HttpPost("google")]
//        public async Task<IActionResult> GoogleLogin([FromBody] GoogleAuthRequest request)
//        {
//            try
//            {
//                var tokenResponse = await ExchangeCodeForTokens(request.Code);
//                var userInfo = await GetGoogleUserInfo(tokenResponse.AccessToken);
//                var user = await _userManager.FindByEmailAsync(userInfo.Email);

//                if (user == null)
//                {
//                    user = new User
//                    {
//                        UserName = userInfo.Email,
//                        Email = userInfo.Email,
//                        EmailConfirmed = true,
//                        FirstName = userInfo.Name?.Split(' ').FirstOrDefault(),
//                        LastName = userInfo.Name?.Split(' ').Skip(1).FirstOrDefault()
//                    };

//                    var result = await _userManager.CreateAsync(user);
//                    if (!result.Succeeded)
//                    {
//                        return BadRequest(new { message = "Failed to create user" });
//                    }
//                }

//                var jwtToken = await GenerateJwtToken(user);

//                return Ok(new {
//                    AccessToken = jwtToken,
//                    TokenType = "Bearer"
//                });
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(new { message = "Google authentication failed", error = ex.Message });
//            }
//        }

//        private async Task<GoogleTokenResponse> ExchangeCodeForTokens(string code)
//        {
//            var clientId = _configuration["Google:ClientId"];
//            var clientSecret = _configuration["Google:ClientSecret"];
//            var redirectUri = "http://localhost:3000/signin-google";

//            using var client = new HttpClient();
//            var tokenRequest = new Dictionary<string, string>
//            {
//                ["code"] = code,
//                ["client_id"] = clientId,
//                ["client_secret"] = clientSecret,
//                ["redirect_uri"] = redirectUri,
//                ["grant_type"] = "authorization_code"
//            };

//            var response = await client.PostAsync(
//                "https://oauth2.googleapis.com/token",
//                new FormUrlEncodedContent(tokenRequest)
//            );

//            if (!response.IsSuccessStatusCode)
//            {
//                throw new Exception($"Failed to exchange code: {await response.Content.ReadAsStringAsync()}");
//            }

//            var responseContent = await response.Content.ReadAsStringAsync();
//            return JsonSerializer.Deserialize<GoogleTokenResponse>(responseContent);
//        }

//        private async Task<GoogleUserInfo> GetGoogleUserInfo(string accessToken)
//        {
//            using var client = new HttpClient();
//            client.DefaultRequestHeaders.Authorization = 
//                new AuthenticationHeaderValue("Bearer", accessToken);

//            var response = await client.GetAsync(
//                "https://www.googleapis.com/oauth2/v2/userinfo"
//            );

//            if (!response.IsSuccessStatusCode)
//            {
//                throw new Exception($"Failed to get user info: {await response.Content.ReadAsStringAsync()}");
//            }

//            var content = await response.Content.ReadAsStringAsync();
//            return JsonSerializer.Deserialize<GoogleUserInfo>(content);
//        }

//        private async Task<string> GenerateJwtToken(User user)
//        {
//            var claims = new List<Claim>
//            {
//                new Claim(ClaimTypes.NameIdentifier, user.Id),
//                new Claim(ClaimTypes.Email, user.Email),
//                new Claim(ClaimTypes.Name, user.UserName)
//            };

//            var roles = await _userManager.GetRolesAsync(user);
//            foreach (var role in roles)
//            {
//                claims.Add(new Claim(ClaimTypes.Role, role));
//            }

//            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
//            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
//            var expires = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpiryMinutes"]));

//            var token = new JwtSecurityToken(
//                _configuration["Jwt:Issuer"],
//                _configuration["Jwt:Audience"],
//                claims,
//                expires: expires,
//                signingCredentials: creds
//            );

//            return new JwtSecurityTokenHandler().WriteToken(token);
//        }
//    }

//    public class GoogleAuthRequest
//    {
//        public string Code { get; set; }
//    }

//    public class GoogleTokenResponse
//    {
//        [JsonPropertyName("access_token")]
//        public string AccessToken { get; set; }

//        [JsonPropertyName("id_token")] 
//        public string IdToken { get; set; }
//    }

//    public class GoogleUserInfo
//    {
//        public string Id { get; set; }
//        public string Email { get; set; }
//        public string Name { get; set; }
//        public string Picture { get; set; }
//    }
//} 