using Finanzas.API.Domain.Models;

namespace Finanzas.API.Domain.Services.Communication
{
    public class CarteraResponse : BaseResponse<Cartera>
    {
        public CarteraResponse(string message) : base(message)
        {
        }

        public CarteraResponse(Cartera resource) : base(resource)
        {
        }
    }
}