using System.Collections.Generic;
using System.Threading.Tasks;
using Finanzas.API.Domain.Models;

namespace Finanzas.API.Domain.Repositories
{
    public interface IHistorialRepository
    {
        Task<IEnumerable<Historial>> ListAsync();
        Task AddAsync(Historial historial);
        Task<Historial> FindByIdAsync(int id);
        
        Task<IEnumerable<Historial>> FindByCarteraId(int carteraId);
        void Update(Historial historial);
        void Remove(Historial historial);
    }
}