namespace DatesterAPI.Controllers
{
    using AutoMapper;
    using Datester.Data.Models;
    using Datester.Services;
    using InputModels;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

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
        [Route("register")]
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