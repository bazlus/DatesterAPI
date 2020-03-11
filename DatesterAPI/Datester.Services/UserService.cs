using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DatesterAPI.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using System.Threading.Tasks;
using Datester.Data;
using Datester.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Datester.Services
{

    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly DatesterDbContext dbContext;
        private readonly IOptions<JwtSettings> jwtSettings;
        private readonly ICloudinaryMediaService cloudinary;

        public UserService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            DatesterDbContext dbContext,
            IOptions<JwtSettings> jwtSettings,
            ICloudinaryMediaService cloudinary)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.dbContext = dbContext;
            this.jwtSettings = jwtSettings;
            this.cloudinary = cloudinary;
        }


        public async Task<int> UploadPhotoAsync(byte[] photo, ClaimsPrincipal userClaims)
        {
            var user = await userManager.GetUserAsync(userClaims);
            var photoUrl = await this.cloudinary.UploadPhoto(photo);
            user.Photos.Add(new UsersPhotos() { PhotoUrl = photoUrl });
            return await dbContext.SaveChangesAsync();
        }

        public async Task<IdentityResult> RegisterUser(ApplicationUser user, string password)
        {
            var result = await userManager.CreateAsync(user, password);
            return result;
        }

        public async Task<string> SignInUser(string email, string password)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user != null && await userManager.CheckPasswordAsync(user, password))
            {
                var jwtToken = this.GetJwtToken(user);
                return jwtToken;
            }

            throw new InvalidOperationException("Invalid email or password");
        }

        public async Task<ApplicationUser> GetCurrentUser(ClaimsPrincipal userClaims)
        {
            var userId = userManager.GetUserId(userClaims);
            var currentUser = await dbContext.Users
                .Include(u => u.Photos)
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();
               
            return currentUser;
        }

        private string GetJwtToken(ApplicationUser user)
        {
            var secret = this.jwtSettings.Value.Secret;
            var key = Encoding.UTF8.GetBytes(secret);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Expires = DateTime.UtcNow.AddDays(7),
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.FirstName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                }),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
