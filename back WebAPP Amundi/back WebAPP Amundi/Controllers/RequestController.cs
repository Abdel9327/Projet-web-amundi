
using Microsoft.AspNetCore.Mvc;

using back_WebAPP_Amundi.JsonManager;
using back_WebAPP_Amundi.Models;
using Newtonsoft.Json;
using back_WebAPP_Amundi.DataBaseManager;

namespace back_WebAPP_Amundi.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {

        private readonly jsonRipositorie _configManager;

        public RequestController(jsonRipositorie _config, RequeteRepositorie _context)
        {
            this._configManager = _config;
        }


        [HttpGet("GetAllRequests/{compte}")]
        public IActionResult getAllRequest(String compte)
        {
            return Ok(_configManager.getAllRequetes(compte));
        }


        [HttpGet("startRequest/{id}")]
        public IActionResult startRequest(int id)
        {
            return Ok(_configManager.startRequest(id));
        }


        [HttpPost("createRequest/")]
        public IActionResult createRequest([FromBody] Object RequestSettings)
        {
            RequeteSettings? newRequest = JsonConvert.DeserializeObject<RequeteSettings>(RequestSettings.ToString());
            return Ok(_configManager.addRequest(newRequest));
        }


        [HttpPost("modifyRequest/{id}")]
        public IActionResult modifyRequest([FromBody] Object RequestSettings, int id)
        {
            RequeteSettings? newRequest = JsonConvert.DeserializeObject<RequeteSettings>(RequestSettings.ToString());
            return Ok(_configManager.modifyRequest(newRequest,id));
        }


        [HttpGet("testConditions/{compte}")]
        public IActionResult testConditions(String compte)
        {
            return Ok(_configManager.testConditions(compte));
        }
    }

}
