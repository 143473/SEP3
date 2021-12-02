using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessLayer.Data;
using BusinessLayer.Middlepoint;
using Microsoft.AspNetCore.Mvc;

namespace REST.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : Controller
    {
        private IUserWebService UserWebService;
        private IUserMiddlepoint UserMiddlepoint;

        public UserController(IUserWebService userWebService, IUserMiddlepoint userMiddlepoint)
        {
            UserWebService = userWebService;
            UserMiddlepoint = userMiddlepoint;
        }
        
        [HttpPost]
        [Route("/User")]
        public async Task<ActionResult> ValidateUserAsync([FromBody] User user)
        {
            try
            {
                //call validation class
                User validateUser = await UserMiddlepoint.ValidateUserAsync(user);
                return Ok(validateUser);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        [Route("/User/CreateAccount")]
        public async Task<ActionResult> CreateAccountAsync([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await UserMiddlepoint.CreateAccountAsync(user);
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        // [HttpGet]
        // [Route("/User/Validate")]
        // public async Task<ActionResult<User>> GetValidatedUserAsync()
        // {
        //     try
        //     {
        //         User user = await UserMiddlepoint.GetValidatedUser();
        //         Console.WriteLine("controller: "+user.role);
        //         return Ok(user);
        //     }
        //     catch (Exception e)
        //     {
        //         Console.WriteLine(e);
        //         return StatusCode(500, e.Message);
        //     }
        // }

        [HttpGet]
        [Route("/User/{username}")]
        public async Task<ActionResult<User>> GetUserByUsernameAsync([FromRoute] string username)
        {
            try
            {
                User user = await UserMiddlepoint.GetUserByUsernameAsync(username);
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("/User/RequestPromotion")]
        public async Task<ActionResult> RequestPromotionToOrganizer()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await UserMiddlepoint.RequestPromotionToOrganizer();
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteAccountAsync([FromQuery] string username)
        {
            try
            {
                await UserWebService.DeleteAccountAsync(username);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}