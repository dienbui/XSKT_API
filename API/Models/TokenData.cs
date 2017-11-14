using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class TokenData
    {
        private String userId;
        private String role;

        public string Role
        {
            get
            {
                return role;
            }

            set
            {
                role = value;
            }
        }

        public string UserId
        {
            get
            {
                return userId;
            }

            set
            {
                userId = value;
            }
        }
    }
}