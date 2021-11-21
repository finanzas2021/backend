using System.Collections.Generic;
using System.Threading.Tasks;
using Finanzas.API.Domain.Models;

namespace Finanzas.API.Domain.Repositories
{
    public interface IReciboRepository
    {
        Task<IEnumerable<Recibo>> ListAsync();
        Task AddAsync(Recibo recibo);
        Task<Recibo> FindByIdAsync(int id);
        
        Task<IEnumerable<Recibo>> FindByUsuarioId(int usuarioId);
        void Update(Recibo recibo);
        void Remove(Recibo recibo);
    }
}