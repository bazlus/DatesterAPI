namespace Datester.Services
{
    using Datester.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public interface IUserService
     {
         Task<int> UploadPhotoAsync(byte[] photo, ClaimsPrincipal user);

         Task<IdentityResult> RegisterUser(ApplicationUser user, string password);

         Task<string> SignInUser(string email, string password);

     }
 }
