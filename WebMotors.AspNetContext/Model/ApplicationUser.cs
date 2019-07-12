using System;
using Microsoft.AspNetCore.Identity;
using WebMotors.AspNetContext.Identity;

namespace WebMotors.AspNetContext.Model
{
    public class ApplicationUser : IdentityUser, IApplicationUser
    {
        public string FullName { get; set; }
    }
}
