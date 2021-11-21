using AutoMapper;
using Finanzas.API.Domain.Models;
using Finanzas.API.Resources;

namespace Finanzas.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveUsuarioResource, Usuario>();
            CreateMap<SaveCarteraResource, Cartera>();
            CreateMap<SaveHistorialResource, Historial>();
            CreateMap<SaveReciboResource,Recibo>();
        }
    }
}