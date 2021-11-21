using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Finanzas.API.Domain.Models;
using Finanzas.API.Domain.Respositories;
using Finanzas.API.Persistence.Contexts;
using Finanzas.API.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.API.Persistence.Repositories
{
    public class CarteraRepository : BaseRepository, ICarteraRepository
    {
        public CarteraRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Cartera>> ListAsync()
        {
            return await _context.Carteras
                .Include(p => p.Usuario).ToListAsync();
        }

        public async Task AddAsync(Cartera cartera)
        {
            await _context.Carteras.AddAsync(cartera);
        }

        public async Task<Cartera> FindByIdAsync(int id)
        {
            return await _context.Carteras
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Cartera>> FindByUsuarioId(int usuarioId)
        {
            return await _context.Carteras
                .Where(p => p.UsuarioId == usuarioId)
                .Include(p => p.Usuario)
                .ToListAsync();
        }

        public void Update(Cartera cartera)
        {
            _context.Carteras.Update(cartera);
        }

        public void Remove(Cartera cartera)
        {
            _context.Carteras.Remove(cartera);
        }
    }
}