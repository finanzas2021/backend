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
    public class RecibosController : ControllerBase
    {
        private readonly IReciboService _reciboService;
        private readonly IMapper _mapper;

        public RecibosController(IReciboService reciboService, IMapper mapper)
        {
            _reciboService = reciboService;
            _mapper = mapper;
        }
        
        [SwaggerOperation(
            Summary = "Get All Recibos",
            Description = "Get All Recibos already stored",
            Tags = new[] {"Recibos"}
        )]
        [HttpGet]
        public async Task<IEnumerable<ReciboResource>> GetAllAsync()
        {
            var recibos = await _reciboService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Recibo>,IEnumerable<ReciboResource>>(recibos);
            
            return resources;
        }
        
        [SwaggerOperation(
            Summary = "Post A Recibo",
            Description = "Post A Recibo in Database",
            Tags = new[] {"Recibos"}
        )]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveReciboResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var recibo = _mapper.Map<SaveReciboResource, Recibo>(resource);

            var result = await _reciboService.SaveAsync(recibo);

            if (!result.Success)
                return BadRequest(result.Message);

            var reciboResource = _mapper.Map<Recibo, ReciboResource>(result.Resource);

            return Ok(reciboResource);
        }
        
        [SwaggerOperation(
            Summary = "Update A Recibo",
            Description = "Update A Recibo in Database",
            Tags = new[] {"Recibos"}
        )]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveReciboResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var recibo = _mapper.Map<SaveReciboResource, Recibo>(resource);

            var result = await _reciboService.UpdateAsync(id, recibo);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var reciboResource = _mapper.Map<Recibo, ReciboResource>(result.Resource);

            return Ok(reciboResource);
        }
        
        [SwaggerOperation(
            Summary = "Delete A Recibo",
            Description = "Delete A Recibo in Database",
            Tags = new[] {"Recibos"}
        )]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _reciboService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var reciboResource = _mapper.Map<Recibo, ReciboResource>(result.Resource);

            return Ok(reciboResource);
        }
        
    }
}