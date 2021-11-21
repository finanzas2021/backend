using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Finanzas.API.Domain.Models;
using Finanzas.API.Domain.Services;
using Finanzas.API.Extensions;
using Finanzas.API.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Finanzas.API.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class HistorialesCrontoller : ControllerBase
    {
        private readonly IHistorialService _historialService;
        private readonly IMapper _mapper;

        public HistorialesCrontoller(IHistorialService historialService, IMapper mapper)
        {
            _historialService = historialService;
            _mapper = mapper;
        }
        
        [SwaggerOperation(
            Summary = "Get All Historiales",
            Description = "Get All Historiales already stored",
            Tags = new[] {"Historiales"}
        )]
        [HttpGet]
        public async Task<IEnumerable<HistorialResource>> GetAllAsync()
        {
            var historiales = await _historialService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Historial>,IEnumerable<HistorialResource>>(historiales);
            
            return resources;
        }
        
        [SwaggerOperation(
            Summary = "Post A Historial",
            Description = "Post A Historial in Database",
            Tags = new[] {"Historiales"}
        )]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveHistorialResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var historial = _mapper.Map<SaveHistorialResource, Historial>(resource);

            var result = await _historialService.SaveAsync(historial);

            if (!result.Success)
                return BadRequest(result.Message);

            var historialResource = _mapper.Map<Historial, HistorialResource>(result.Resource);

            return Ok(historialResource);
        }
        
        [SwaggerOperation(
            Summary = "Update A Historial",
            Description = "Update A Historial in Database",
            Tags = new[] {"Historiales"}
        )]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveHistorialResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var historial = _mapper.Map<SaveHistorialResource, Historial>(resource);

            var result = await _historialService.UpdateAsync(id, historial);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var historialResource = _mapper.Map<Historial, HistorialResource>(result.Resource);

            return Ok(historialResource);
        }
        
        [SwaggerOperation(
            Summary = "Delete A Historial",
            Description = "Delete A Historial in Database",
            Tags = new[] {"Historiales"}
        )]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _historialService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var historialResource = _mapper.Map<Historial, HistorialResource>(result.Resource);

            return Ok(historialResource);
        }
    }
}