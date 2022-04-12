
using Microsoft.AspNetCore.Mvc;

using back_WebAPP_Amundi.JsonManager;

namespace back_WebAPP_Amundi.Controllers
{
   


    [Route("api/[controller]")]
    [ApiController]
    public class RequeteController : ControllerBase
    {
       
        private readonly jsonManager _configManager;

        public RequeteController ( jsonManager _config)
        {
            
            this._configManager = _config;
            
        }
       

        [HttpGet("GetAllRequests")]
        public IActionResult test2()
        {
             return Ok(_configManager.getAllRequetes());
        }

        [HttpGet("startRequest/{id}")]
        public IActionResult test2(int id)
        {
            return Ok(_configManager.startRequest(id));
        }
    }

}