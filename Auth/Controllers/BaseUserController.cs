using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseUserController : Controller
    {
        private readonly UserManager<Player> usermanager;

        public BaseUserController(UserManager<Player> usermanager)
        {
            this.usermanager = usermanager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGameUser([FromQuery] int countplayers)
        {
            List<Player> players = new List<Player>();
            List<IdentityResult> results = new List<IdentityResult>();

            for (int i = 0; i < countplayers; i++)
            {
                var p = GeneratePlayer();
                players.Add(p);
                var result = await usermanager.CreateAsync(p, "Password23");
                results.Add(result);
            }

            if (results.Any(r => r.Succeeded))
            {
            //  await AddToRole(model.email, "user");
                foreach (var p in players)
                {
                    await AddClaims(p.Email);
                }
                return Ok(players);
            }
            return BadRequest();
        }

        private async Task AddToRole(string userName, string roleName)
        {
            var user = await usermanager.FindByNameAsync(userName);
            await usermanager.AddToRoleAsync(user, roleName);
        }
        
        private Player GeneratePlayer()
        {
            string username = GenerateName(10);
            username += "@test.com";

            var user = new Player
            {
                AccessFailedCount = 0,
                Email = username,
                EmailConfirmed = false,
                LockoutEnabled = false,
                NormalizedEmail = username.ToUpper(),
                NormalizedUserName = username.ToUpper(),
                TwoFactorEnabled = false,
                UserName = username,          
            };

            return user;
        }

        private async Task AddClaims(string userName)
        {
            var user = await usermanager.FindByNameAsync(userName);
            var claims = new List<Claim> {
                new Claim(type: JwtClaimTypes.Name, value: user.UserName)
            };
            await usermanager.AddClaimsAsync(user, claims);
        }

        private string GenerateName(int len)
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;
        }

    }

}

