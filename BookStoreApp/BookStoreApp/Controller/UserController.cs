using ManagerLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Controller
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserManager manager;
        private ILogger<UserController> logger;

        public UserController(IUserManager manager, ILogger<UserController> logger)
        {
            this.manager = manager;
            this.logger = logger;
        }

        [HttpPost]
        [Route("register")]

        public async Task<IActionResult> Register([FromBody] RegisterModel user)
        {
            try
            {
                var responce = await this.manager.RegisterUser(user);
                if (responce != null)
                {
                    return this.Ok(new ResponceModel<RegisterModel> { Status = true, Massage = "Rgister successfully", Data = responce });
                }
                else
                {

                    return this.BadRequest(new { Status = true, Massage = "Not Rgister successfully" });
                }
            }
            catch (Exception)
            {
                return this.NotFound(new { Status = true, Massage = "Not Rgister successfully Exception is occured" });
            }
        }
    }
}
