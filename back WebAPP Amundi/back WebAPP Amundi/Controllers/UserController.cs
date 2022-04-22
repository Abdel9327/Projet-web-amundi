using back_WebAPP_Amundi.JsonManager;
using back_WebAPP_Amundi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace back_WebAPP_Amundi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly jsonRipositorie _configManager;

        public UserController(jsonRipositorie _config)
        {
            this._configManager = _config;
        }


        [HttpPost("login/")]
        public IActionResult createRequest([FromBody] Object loginSettings)
        {

           User? user = JsonConvert.DeserializeObject<User>(loginSettings.ToString());
            System.Diagnostics.Debug.WriteLine(_configManager.login(user));
            return Ok(_configManager.login(user));

        }
    }
}
