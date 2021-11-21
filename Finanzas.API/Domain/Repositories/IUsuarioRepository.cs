using System.Collections.Generic;
using System.Threading.Tasks;
using Finanzas.API.Domain.Models;

namespace Finanzas.API.Domain.Respositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> ListAsync();
        Task AddAsync(Usuario usuario);
        Task<Usuario> FindByIdAsync(int id);
        Task<Usuario> FindByNameAsync(string name);
        
        void Update(Usuario usuario);
        void Remove(Usuario usuario);
    }
}