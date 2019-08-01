using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatesterAPI.Controllers
{
    using System.IO;
    using System.Net.Mime;
    using AutoMapper;
    using Datester.Data.Models;
    using Datester.Services;
    using InputModels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.FileSystemGlobbing.Abstractions;

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public UsersController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IMapper mapper,
            IUserService userService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
            this.userService = userService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(UserRegistrationInputModel user)
        {
            ApplicationUser newUser = mapper.Map<ApplicationUser>(user);

            var result = await userManager.CreateAsync(newUser, user.Password);

            return this.Ok(result);
        }

        [Route("upload-image")]
        public async Task<IActionResult> UploadImage([FromBody] byte[] photo)
        {
            var result = await userService.UploadPhotoAsync(photo, this.User);

            if (result == 0)
            {
                return this.BadRequest(new InvalidOperationException("File type must be .jpeg"));
            }

            return this.Ok();
        }
    }
}