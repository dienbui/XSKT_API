using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class UserController : ApiController
    {
        [HttpPost]
        [Route("user/login")]
        public IHttpActionResult login([FromBody]LoginRequest request)
        {
            Response response = new Response(); 
            try
            {
                if (!request.isValid())
                {
                    response.code = 1;
                    return Ok<Response>(response);
                }
                //check login

                // create token ()

                // 
                LoginResponse loginResponse = new LoginResponse();
                response.data = loginResponse;
            }
            catch
            {
                response.code = 1;
            }
            return Ok<Response>(response);
        }
    }
}
