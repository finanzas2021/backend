using Finanzas.API.Domain.Models;

namespace Finanzas.API.Domain.Services.Communication
{
    public class UsuarioResponse : BaseResponse<Usuario>
    {
        public UsuarioResponse(string message) : base(message)
        {
        }

        public UsuarioResponse(Usuario resource) : base(resource)
        {
        }
    }
}