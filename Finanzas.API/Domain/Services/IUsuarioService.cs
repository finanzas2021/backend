using System.Collections.Generic;
using System.Threading.Tasks;
using Finanzas.API.Domain.Models;
using Finanzas.API.Domain.Services.Communication;

namespace Finanzas.API.Domain.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> ListAsync();
        Task<UsuarioResponse> SaveAsync(Usuario usuario);
        Task<UsuarioResponse> UpdateAsync(int id, Usuario usuario);
        Task<UsuarioResponse> DeleteAsync(int id);
    }
}