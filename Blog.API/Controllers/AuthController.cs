using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application;
using Blog.Application.Commands.UserCommand;
using Blog.Application.DTO.User;
using Blog.Application.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly Encription _enc;
        private readonly ILoginCommand _login;

        public AuthController(Encription enc, ILoginCommand login)
        {
            _enc = enc;
            _login = login;
        }


        // POST: api/Auth
        [HttpPost]
        public ActionResult Post([FromBody] UserLogDto dto)
        {
            try
            {
                var user = _login.Execute(dto);

                var stringObjekat = JsonConvert.SerializeObject(user);

                var encrypted = _enc.EncryptString(stringObjekat);

                return Ok(new { token = encrypted });
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet("decode")]
        public IActionResult Decode(string value)
        {
            var decodedString = _enc.DecryptString(value);
            decodedString = decodedString.Substring(0, decodedString.LastIndexOf("}") + 1);
            var user = JsonConvert.DeserializeObject<LoggedUser>(decodedString);

            return null;
        }
    }
}
