<<<<<<< HEAD
﻿namespace Datester.Services
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<int> UploadPhotoAsync(byte[] photo, ClaimsPrincipal user);
=======
﻿using System;
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

>>>>>>> 4a6d825253f225505b3c02116c9f96ffe7d94178
    }
}
