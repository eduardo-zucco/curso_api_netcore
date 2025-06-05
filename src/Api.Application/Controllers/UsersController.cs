using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAll([FromServices] IUserService service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 codigo de solicitacao invalida
            }
            try
            {
                return Ok(await service.GetAll()); // 200 codigo de sucesso
                
                
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message); // 500 codigo de erro interno
            }
        
        }

    }
}
