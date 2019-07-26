using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Datester.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Datester.Services
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterUser(ApplicationUser user, string password);

        Task<string> SignInUser(string email, string password);

    }
}
