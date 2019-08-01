namespace Datester.Services
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<int> UploadPhotoAsync(byte[] photo, ClaimsPrincipal user);
    }
}
