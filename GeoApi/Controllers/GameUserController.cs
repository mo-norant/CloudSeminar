using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoGame.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace GeoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameUserController : Controller
    {
        RestClient client = new RestClient("https://localhost:44330");
        private IAreaService areaService;

        public GameUserController(IAreaService areaService) {
            this.areaService = areaService;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateUsers([FromQuery] int count)
        {
            var request = new RestRequest("api/BaseUser", Method.POST);
            request.AddQueryParameter("countplayers", count.ToString());
            request.AddHeader("Accept", "application/json");
            IRestResponse<List<IdentityUser>> response = client.Execute<List<IdentityUser>>(request);
                if (!response.IsSuccessful) return BadRequest();
            
            foreach(var p in response.Data)
            {
                await areaService.CreateUser(p);
            }

            return Ok();
        }
        
    }
}