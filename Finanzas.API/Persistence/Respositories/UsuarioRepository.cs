using System.Collections.Generic;
using System.Threading.Tasks;
using Finanzas.API.Domain.Models;
using Finanzas.API.Domain.Respositories;
using Finanzas.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.API.Persistence.Repositories
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Usuario>> ListAsync()
        {
            return await _context.Usuarios
                .ToListAsync();
        }

        public async Task AddAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
        }

        public async Task<Usuario> FindByIdAsync(int id)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Usuario> FindByNameAsync(string name)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(p => p.Name == name);
        }

        public void Update(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
        }

        public void Remove(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
        }
    }
}