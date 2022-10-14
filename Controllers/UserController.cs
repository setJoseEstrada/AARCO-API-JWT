﻿using AARCOAPI.Models.Request;
using AARCOAPI.Models.Response;
using AARCOAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AARCOAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Autentificar([FromBody] AuthRequest model)
        {
            Respuesta respuesta = new Respuesta();
            var userresponse = _userService.Auth(model);
            if (userresponse == null)
            {
                respuesta.Exito = 0;
                respuesta.Mensaje = "Usuario o Contraseña Incorrecta";
                return BadRequest(respuesta);
            }
            respuesta.Exito = 1;
            respuesta.Data = userresponse;
            return Ok(respuesta);
        }
    }
}
