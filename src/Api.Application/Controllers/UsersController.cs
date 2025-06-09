using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class UsersController : ControllerBase
    {
        private IUserService _service;
        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 codigo de solicitacao invalida
            }
            try
            {
                return Ok(await _service.GetAll()); // 200 codigo de sucesso


            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message); // 500 codigo de erro interno
            }

        }
        //localhost:5000/api/users/1133345
        [HttpGet]
        [Route("{id}", Name = "GetWithId")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 codigo de solicitacao invalida
            }
            try
            {
                return Ok(await _service.Get(id)); // 200 codigo de sucesso
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message); // 500 codigo de erro interno
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserEntity user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 codigo de solicitacao invalida
            }
            try
            {
                var result = await _service.Post(user);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetWithId", new { id = result.Id })), result); // 201 codigo de criado
                }
                else
                {
                    return BadRequest(); // 400 codigo de solicitacao invalida
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message); // 500 codigo de erro interno
            }
        }
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UserEntity user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 codigo de solicitacao invalida
            }

            try
            {
                var result = await _service.Put(user);
                if (result != null)
                {
                    return Ok(result); // 201 codigo de criado
                }
                else
                {
                    return BadRequest(); // 400 codigo de solicitacao invalida
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message); // 500 codigo de erro interno
            }

        }
        [HttpDelete ("{id}")]
         public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 codigo de solicitacao invalida
            }
            try
            {
                return Ok(await _service.Delete(id)); // 200 codigo de sucesso
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message); // 500 codigo de erro interno
            }
        }

    }
}
