﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DatesterAPI.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Datester.Services
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class UserService : IUserService
<<<<<<< HEAD
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly DatesterDbContext dbContext;

        public UserService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            DatesterDbContext dbContext)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.dbContext = dbContext;
        }


        public async Task<int> UploadPhotoAsync(byte[] photo, ClaimsPrincipal userClaims)
        {
            var user = await userManager.GetUserAsync(userClaims);
            user.Photos.Add(new UsersPhotos() {Photo = photo});
            return await dbContext.SaveChangesAsync();
=======

    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IOptions<JwtSettings> jwtSettings;

        public UserService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IOptions<JwtSettings> jwtSettings
            )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.jwtSettings = jwtSettings;
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

        public static string GetUsernameFromEmail(string email)
        {
            return email.Replace("@", ".").Replace(".", "-");
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
>>>>>>> 4a6d825253f225505b3c02116c9f96ffe7d94178
        }
    }
}
