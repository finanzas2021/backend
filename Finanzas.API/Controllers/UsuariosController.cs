using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Finanzas.API.Domain.Models;
using Finanzas.API.Domain.Services;
using Finanzas.API.Domain.Services.Communication;
using Finanzas.API.Extensions;
using Finanzas.API.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Finanzas.API.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuariosController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }
        
        [SwaggerOperation(
            Summary = "Get All Usuarios",
            Description = "Get All Usuarios already stored",
            Tags = new[] {"Usuarios"}
        )]
        [HttpGet]
        public async Task<IEnumerable<UsuarioResource>> GetAllAsync()
        {
            var usuarios = await _usuarioService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Usuario>,IEnumerable<UsuarioResource>>(usuarios);
            
            return resources;
        }
        
        [SwaggerOperation(
            Summary = "Post A Usuario",
            Description = "Post A Usuario in Database",
            Tags = new[] {"Usuarios"}
        )]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUsuarioResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var usuario = _mapper.Map<SaveUsuarioResource, Usuario>(resource);

            var result = await _usuarioService.SaveAsync(usuario);

            if (!result.Success)
                return BadRequest(result.Message);

            var usuarioResource = _mapper.Map<Usuario, UsuarioResource>(result.Resource);

            return Ok(usuarioResource);
        }
        
        [SwaggerOperation(
            Summary = "Update A Usuario",
            Description = "Update A Usuario in Database",
            Tags = new[] {"Usuarios"}
        )]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUsuarioResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var usuario = _mapper.Map<SaveUsuarioResource, Usuario>(resource);

            var result = await _usuarioService.UpdateAsync(id, usuario);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var usuarioResource = _mapper.Map<Usuario, UsuarioResource>(result.Resource);

            return Ok(usuarioResource);
        }
        
        [SwaggerOperation(
            Summary = "Delete A Usuario",
            Description = "Delete A Usuario in Database",
            Tags = new[] {"Usuarios"}
        )]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _usuarioService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var usuarioResource = _mapper.Map<Usuario, UsuarioResource>(result.Resource);

            return Ok(usuarioResource);
        }
    }
}