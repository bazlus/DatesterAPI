using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datester.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatesterAPI.Controllers
{
    using AutoMapper;
    using Datester.Data.Models;
    using InputModels;
    using Microsoft.AspNetCore.Identity;


    public class UsersController : ApiController
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UsersController(IUserService userService,
                                IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(UserRegistrationInputModel userInputModel)
        {
            ApplicationUser user = mapper.Map<ApplicationUser>(userInputModel);
            return this.Ok(await this.userService.RegisterUser(user, userInputModel.Password));
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login(UserLoginInputModel userLoginInput)
        {
            try
            {
               var tokenResult = await userService.SignInUser(userLoginInput.Email, userLoginInput.Password);
               return this.Ok(new {tokenResult});
            }
            catch (InvalidOperationException ex)
            {
                return this.BadRequest(ex);
            }
        }
    }
}