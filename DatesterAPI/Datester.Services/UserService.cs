namespace Datester.Services
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class UserService : IUserService
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
        }
    }
}
