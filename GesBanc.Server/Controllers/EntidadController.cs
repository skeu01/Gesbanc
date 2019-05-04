using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gesbanc.Business.Contracts;
using Gesbanc.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GesBanc.Server.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("cors")]
    public class EntidadController : ControllerBase
    {
        private readonly IEntidadService _service;

        public EntidadController(IEntidadService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(bool? activo)
        {
            var entities = await _service.GetAllAsync(activo);

            if (entities == null)
                return BadRequest();

            return Ok(entities);
        }

        [HttpGet]
        [Route("grupo")]
        public async Task<IActionResult> GetAllGrupoEntidadAsync()
        {
            var entities = await _service.GetAllGrupoEntidadAsync();

            if (entities == null)
                return BadRequest();

            return Ok(entities);
        }


        [HttpGet]
        [Route("id/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var entities = await _service.GetByIdAsync(id);

            if (entities == null)
                return BadRequest();

            return Ok(entities);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(EntidadEntity entidad)
        {
            var entity = await _service.PostAsync(entidad);

            if (entity == null)
                return BadRequest();

            return Ok(entity);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(EntidadEntity entidad)
        {
            var entity = await _service.PutAsync(entidad);

            if (entity == null)
                return BadRequest();

            return Ok(entity);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var entity = await _service.DeleteAsync(id);

            if (entity == false)
                return BadRequest();

            return Ok(true);
        }
    }
}
