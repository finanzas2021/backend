using Finanzas.API.Domain.Models;

namespace Finanzas.API.Domain.Services.Communication
{
    public class HistorialResponse : BaseResponse<Historial>
    {
        public HistorialResponse(string message) : base(message)
        {
        }

        public HistorialResponse(Historial resource) : base(resource)
        {
        }
    }
}