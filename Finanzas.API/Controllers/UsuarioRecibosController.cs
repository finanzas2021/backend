using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Finanzas.API.Domain.Models;
using Finanzas.API.Domain.Services;
using Finanzas.API.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Finanzas.API.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("/api/v1/usuarios/{usuarioId}/recibos")]
    public class UsuarioRecibosController : ControllerBase
    {
        private readonly IReciboService _reciboService;
        private readonly IMapper _mapper;

        public UsuarioRecibosController(IReciboService reciboService, IMapper mapper)
        {
            _reciboService = reciboService;
            _mapper = mapper;
        }
        
        [SwaggerOperation(
            Summary = "Get All Recibos By Usuario",
            Description = "Get All Recibos for a given UserId",
            Tags = new[] {"Recibos"}
        )]
        [HttpGet]
        public async Task<IEnumerable<ReciboResource>> GetAllByCategoryIdAsync(int usuarioId)
        {
            var recibos = await _reciboService.ListByUsuarioIdAsync(usuarioId);
            var resources = _mapper.Map<IEnumerable<Recibo>, IEnumerable<ReciboResource>>(recibos);

            return resources;
        }
    }
}