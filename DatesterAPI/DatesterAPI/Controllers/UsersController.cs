namespace DatesterAPI.Controllers
{
    using AutoMapper;
    using Datester.Data.Models;
    using Datester.Services;
    using InputModels;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using ViewModels;

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
            var result = await this.userService.RegisterUser(user, userInputModel.Password);

            if (result.Succeeded)
            {
                return this.Ok(result);
            }

            return this.BadRequest(result);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(UserLoginInputModel userLoginInput)
        {
            try
            {
                var tokenResult = await userService.SignInUser(userLoginInput.Email, userLoginInput.Password);
                return this.Ok(new {token = tokenResult});
            }
            catch (InvalidOperationException ex)
            {
                return this.BadRequest(ex);
            }
        }

        [HttpPost]
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

        [Route("profile")]
        [HttpGet]
        public async Task<UserViewModel> GetUser()
        {
            var user = await this.userService.GetCurrentUser(this.User);
            return this.mapper.Map<UserViewModel>(user);
        }
    }
}