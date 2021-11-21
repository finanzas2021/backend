using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Finanzas.API.Domain.Models;
using Finanzas.API.Domain.Repositories;
using Finanzas.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.API.Persistence.Repositories
{
    public class ReciboRepository : BaseRepository, IReciboRepository
    {
        public ReciboRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Recibo>> ListAsync()
        {
            return await _context.Recibos
                .Include(p => p.Usuario).ToListAsync();
        }

        public async Task AddAsync(Recibo recibo)
        {
            await _context.Recibos.AddAsync(recibo);
        }

        public async Task<Recibo> FindByIdAsync(int id)
        {
            return await _context.Recibos
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Recibo>> FindByUsuarioId(int usuarioId)
        {
            return await _context.Recibos
                .Where(p => p.UsuarioId == usuarioId)
                .Include(p => p.Usuario)
                .ToListAsync();
        }

        public void Update(Recibo recibo)
        {
            _context.Recibos.Update(recibo);
        }

        public void Remove(Recibo recibo)
        {
            _context.Recibos.Remove(recibo);
        }
    }
}