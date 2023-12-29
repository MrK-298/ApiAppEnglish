using ApiAppEnglish.Data.EF;
using ApiAppEnglish.Data.ViewModel;
using HutechDriverApp.Function;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiAppEnglish.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly SymmetricSecurityKey _secretKey;
        private readonly UserRepository _userRepository;

        public AuthController(MyDbContext context, UserRepository userRepository)
        {
            _context = context;
            _secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ntqbqhrychczumzisfmojgjtpvpsfgwm"));
            _userRepository = userRepository;
        }
        [HttpPost("Login")]
        public IActionResult Login(LoginViewModel model)
        {
            var user = _context.users.SingleOrDefault(p => p.userName == model.userName);
            if (user != null)
            {
                var passwordHasher = new PasswordHasher<User>();
                var passwordVerificationResult = passwordHasher.VerifyHashedPassword(user, user.passWord, model.passWord);
                if (passwordVerificationResult == PasswordVerificationResult.Success)
                {                 
                    _context.SaveChanges();
                    var claims = new List<Claim>
                    {
                        new Claim("Fullname", user.fullName),
                        new Claim("Id", user.Id.ToString()),
                        new Claim("Email", user.Email),                    
                    };
                    var token = new JwtSecurityToken(
                        issuer: "https://localhost:7142/swagger",
                        audience: "api", // Hoặc "api/login" tùy theo cấu hình
                        claims: claims,
                        expires: DateTime.UtcNow.AddHours(12),
                        signingCredentials: new SigningCredentials(_secretKey, SecurityAlgorithms.HmacSha256)
                    );

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                    return Ok(new { Token = tokenString, Message = "Login success" });
                }
                else
                {
                    return Ok(new { Message = "Login fail ! try again" });
                }
            }
            else
            {
                return Ok(new { Message = "Login fail ! try again" });
            }
        }
        [HttpPost("Register")]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!_context.users.Any(u => u.userName == model.userName))
            {
                var user = new User
                {
                    userName = model.userName,
                    passWord = new PasswordHasher<User>().HashPassword(null, model.passWord),
                    Email = model.Email,
                    fullName = model.fullName,
                };
                SendMail.SendEmail(model.Email, "Xác nhận tài khoản", "Bạn đã xác nhận thành công", "");
                _context.users.Add(user);
                _context.SaveChanges();             
                return Ok("Registration successful");
            }

            return BadRequest("Username is already taken");
        }
        [HttpPost("DecodeToken")]
        public IActionResult DecodeToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("ntqbqhrychczumzisfmojgjtpvpsfgwm");

                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidIssuer = "https://localhost:7142/swagger",
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = "api",
                    ValidateLifetime = true, // Kiểm tra xem Token còn hiệu lực không
                    ClockSkew = TimeSpan.Zero
                };


                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;

                // Extract information from the token as needed
                var fullname = jwtToken.Claims.First(x => x.Type == "Fullname").Value;
                var userId = jwtToken.Claims.First(x => x.Type == "Id").Value;
                var email = jwtToken.Claims.First(x => x.Type == "Email").Value;
                return Ok(new
                {
                    FullName = fullname,
                    UserId = userId,
                    Email = email,
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(new { message = "Invalid token" });
            }
        }
    }
}
