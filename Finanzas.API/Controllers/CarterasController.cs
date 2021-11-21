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
    public class CarterasController : ControllerBase
    {
        private readonly ICarteraService _carteraService;
        private readonly IMapper _mapper;

        public CarterasController(ICarteraService carteraService, IMapper mapper)
        {
            _carteraService = carteraService;
            _mapper = mapper;
        }
        
        [SwaggerOperation(
            Summary = "Get All Carteras",
            Description = "Get All Carteras already stored",
            Tags = new[] {"Carteras"}
        )]
        [HttpGet]
        public async Task<IEnumerable<CarteraResource>> GetAllAsync()
        {
            var carteras = await _carteraService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Cartera>,IEnumerable<CarteraResource>>(carteras);
            
            return resources;
        }
        
        [SwaggerOperation(
            Summary = "Post A Cartera",
            Description = "Post A Cartera in Database",
            Tags = new[] {"Carteras"}
        )]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCarteraResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var cartera = _mapper.Map<SaveCarteraResource, Cartera>(resource);

            var result = await _carteraService.SaveAsync(cartera);

            if (!result.Success)
                return BadRequest(result.Message);

            var carteraResource = _mapper.Map<Cartera, CarteraResource>(result.Resource);

            return Ok(carteraResource);
        }
        
        [SwaggerOperation(
            Summary = "Update A Cartera",
            Description = "Update A Cartera in Database",
            Tags = new[] {"Carteras"}
        )]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCarteraResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var cartera = _mapper.Map<SaveCarteraResource, Cartera>(resource);

            var result = await _carteraService.UpdateAsync(id, cartera);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var carteraResource = _mapper.Map<Cartera, CarteraResource>(result.Resource);

            return Ok(carteraResource);
        }
        
        [SwaggerOperation(
            Summary = "Delete A Cartera",
            Description = "Delete A Cartera in Database",
            Tags = new[] {"Carteras"}
        )]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _carteraService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var carteraResource = _mapper.Map<Cartera, CarteraResource>(result.Resource);

            return Ok(carteraResource);
        }
    }
}