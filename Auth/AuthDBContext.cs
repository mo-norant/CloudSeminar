using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth
{
    public class AuthDBContext : IdentityDbContext<Player>
    {
        public AuthDBContext(DbContextOptions<AuthDBContext> options)
         : base(options)
        {
        }
        
    }


}
