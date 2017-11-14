using API.Models;
using API.Utils;
using Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.JWT
{
    public class TokenService
    {
        public String createToken(TokenData data)
        {
            try
            {
                return JsonWebToken.Encode(data, Constant.SIGNATURE, JwtHashAlgorithm.HS256);
            }
            catch
            {
                throw new Exception("Create token fail !");
            }
        }
        public TokenData verifyToken(String token)
        {
            try
            {
                return JsonWebToken.DecodeToObject<TokenData>(token,Constant.SIGNATURE);
            }
            catch(Exception e )
            {
                throw new SignatureVerificationException("Token invalid");
            }
        }

    }
}