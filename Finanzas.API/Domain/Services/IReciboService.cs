using System.Collections.Generic;
using System.Threading.Tasks;
using Finanzas.API.Domain.Models;
using Finanzas.API.Domain.Services.Communication;

namespace Finanzas.API.Domain.Services
{
    public interface IReciboService
    {
        Task<IEnumerable<Recibo>> ListAsync();
        Task<IEnumerable<Recibo>> ListByUsuarioIdAsync(int usuario);
        Task<ReciboResponse> SaveAsync(Recibo recibo);
        Task<ReciboResponse> UpdateAsync(int id, Recibo recibo);
        Task<ReciboResponse> DeleteAsync(int id);
    }
}