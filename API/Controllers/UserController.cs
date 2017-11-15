using API.JWT;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XSKTDB;

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
                using (var db = new XSKTDBDataContext())
                {
                    db.DeferredLoadingEnabled = false;
                    var result = db.LottezyUsers.Where(x => x.userName == request.UserName).Where(x => x.password == request.Password).FirstOrDefault();
                    if (result != null)
                    {
                        TokenService tokenService = new TokenService();
                        string token = tokenService.createToken(new TokenData
                        {
                            Role = result.Role,
                            UserId = result.Id.ToString()
                        });
                        LoginResponse responseToken = new LoginResponse
                        {
                            Token = token,
                            UserName = result.userName
                        };
                        response.data = responseToken;
                        response.code = 0;
                    }
                }

                // 
                
               
            }
            catch
            {
                response.code = 1;
            }
            return Ok<Response>(response);
        }
    }
}
