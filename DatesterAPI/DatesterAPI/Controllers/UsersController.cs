using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatesterAPI.Controllers
{
    using AutoMapper;
    using Datester.Data.Models;
    using InputModels;
    using Microsoft.AspNetCore.Identity;

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IMapper mapper;

        public UsersController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("register")]
        public async Task<object> Register(UserRegistrationInputModel user)
        {
            ApplicationUser newUser = mapper.Map<ApplicationUser>(user);

            await userManager.AddPasswordAsync(newUser, user.Password);

            return Task.CompletedTask;
        }
    }
}