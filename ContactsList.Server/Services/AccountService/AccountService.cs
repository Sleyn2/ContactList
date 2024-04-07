using ContactsList.Server.Core;
using ContactsList.Server.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ContactsList.Server.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher _passwordHasher;
        private IConfiguration _config;

        public AccountService(ApplicationDbContext context, IPasswordHasher passwordHasher, IConfiguration config)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _config = config;
        }

        public async Task<UserDto> LoginAsync(LoginRequest loginRequest)
        {
            var user = await _context.Users.SingleOrDefaultAsync(user => user.Email == loginRequest.Email);
            if (user == null)
                return null;

            var result = _passwordHasher.Verify(user.PasswordHash, loginRequest.Password);

            if (!result)
                return null;

            var token = GenerateJSONWebToken(loginRequest);

            return new UserDto
            {
                Name = user.Name,
                Surname = user.Surname,
                Token = token
            };
        }

        private string GenerateJSONWebToken(LoginRequest userInfo)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Email, userInfo.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<List<ApplicationUser>> AddUser(ApplicationUser user)
        {
            var passwordHash = _passwordHasher.Hash(user.PasswordHash);
            user.PasswordHash = passwordHash;

            user.Category = await _context.Categories.FindAsync(user.CategoryId);
            user.Subcategory = await _context.Subcategories.FindAsync(user.SubcategoryId);

            user.Id = Guid.NewGuid().ToString();

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return await _context.Users.ToListAsync();
        }

        public async Task<List<ApplicationUser>> DeleteUser(ApplicationUser user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return await _context.Users.ToListAsync();
        }

        public async Task<List<ApplicationUser>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<ApplicationUser> GetUser(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<List<ApplicationUser>> UpdateUser(ApplicationUser request)
        {
            var user = await _context.Users.FindAsync(request.Id);
            if (user is null)
                return null;

            user.Name = request.Name;
            user.Surname = request.Surname;
            user.CategoryId = request.CategoryId;
            user.SubcategoryId = request.SubcategoryId;
            user.BirthDate = request.BirthDate;
            user.PhoneNumber = request.PhoneNumber;
            user.UserName = request.UserName;
            user.Email = request.Email;
            user.PasswordHash = _passwordHasher.Hash(request.PasswordHash);

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return await _context.Users.ToListAsync();
        }
    }
}
