using System.Collections.Generic;
using System.Threading.Tasks;
using Finanzas.API.Domain.Models;
using Finanzas.API.Domain.Services.Communication;

namespace Finanzas.API.Domain.Services
{
    public interface ICarteraService
    {
        Task<IEnumerable<Cartera>> ListAsync();
        Task<IEnumerable<Cartera>> ListByUsuarioIdAsync(int usuario);
        Task<CarteraResponse> SaveAsync(Cartera cartera);
        Task<CarteraResponse> UpdateAsync(int id, Cartera cartera);
        Task<CarteraResponse> DeleteAsync(int id);
    }
}