using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace core.Domain.Entities.User
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }  
    }
}