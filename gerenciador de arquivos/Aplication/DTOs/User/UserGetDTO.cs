using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication.DTOs.User
{
    public class UserGetDTO
    {
         public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
    }
}