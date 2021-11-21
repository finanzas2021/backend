using AutoMapper;
using Finanzas.API.Domain.Models;
using Finanzas.API.Resources;

namespace Finanzas.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Usuario, UsuarioResource>();
            CreateMap<Cartera, CarteraResource>();
            CreateMap<Historial, HistorialResource>();
            CreateMap<Recibo, ReciboResource>();
        }
    }
}