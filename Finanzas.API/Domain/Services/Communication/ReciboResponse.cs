using Finanzas.API.Domain.Models;

namespace Finanzas.API.Domain.Services.Communication
{
    public class ReciboResponse : BaseResponse<Recibo>
    {
        public ReciboResponse(string message) : base(message)
        {
        }

        public ReciboResponse(Recibo resource) : base(resource)
        {
        }
    }
}