using System.Collections.Generic;
using System.Threading.Tasks;
using Finanzas.API.Domain.Models;

namespace Finanzas.API.Domain.Respositories
{
    public interface ICarteraRepository
    {
        Task<IEnumerable<Cartera>> ListAsync();
        Task AddAsync(Cartera cartera);
        Task<Cartera> FindByIdAsync(int id);
        
        Task<IEnumerable<Cartera>> FindByUsuarioId(int usuarioId);
        void Update(Cartera cartera);
        void Remove(Cartera cartera);
    }
}