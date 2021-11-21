using System.Collections.Generic;
using System.Threading.Tasks;
using Finanzas.API.Domain.Models;
using Finanzas.API.Domain.Services.Communication;

namespace Finanzas.API.Domain.Services
{
    public interface IHistorialService
    {
        Task<IEnumerable<Historial>> ListAsync();
        Task<IEnumerable<Historial>> ListByCarteraIdAsync(int cartera);
        Task<HistorialResponse> SaveAsync(Historial historial);
        Task<HistorialResponse> UpdateAsync(int id, Historial historial);
        Task<HistorialResponse> DeleteAsync(int id);
    }
}