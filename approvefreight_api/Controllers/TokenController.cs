using approvefreight_api.Helper.TokenManager;
using approvefreight_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace approvefreight_api.Controllers
{
    [Route("v1/generatetoken")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ResponseTokenVM>>  GenerateToken(LoginTokenVM objVM)
        {
            int userStatus = 1;
            //check if the user is valid
            using (TMSWORKANAContext _context = new TMSWORKANAContext())
            {
                var UserValid = (from user in _context.Usuarios
                                   where user.EndEmail == objVM.UserEmail
                                   select user).Count();
                if (UserValid <= 0)
                    userStatus = -1;
            }

            if (userStatus == -1) 
                return Ok(new ResponseTokenVM
                {
                    Status = "Invalid",
                    Message = "Invalid User."
                });
            if (userStatus == 0) 
                return Ok( new ResponseTokenVM
                {
                    Status = "Inactive",
                    Message = "User Inactive."
                });
            else 
                return Ok(new ResponseTokenVM
                {
                    Status = "Success",
                    Message= "",
                    token_type = "Bearer",
                    access_token = TokenManager.GenerateToken(objVM.UserEmail),
                    expires_in = 1800
                });
        }
    }
}
