using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Finanzas.API.Domain.Models;
using Finanzas.API.Domain.Repositories;
using Finanzas.API.Persistence.Contexts;
using Finanzas.API.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.API.Persistence.Repositories
{
    public class HistorialRepository : BaseRepository,IHistorialRepository
    {
        public HistorialRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Historial>> ListAsync()
        {
            return await _context.Historiales
                .Include(p => p.Cartera).ToListAsync();
        }

        public async Task AddAsync(Historial historial)
        {
            await _context.Historiales.AddAsync(historial);
        }

        public async Task<Historial> FindByIdAsync(int id)
        {
            return await _context.Historiales
                .Include(p => p.Cartera)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Historial>> FindByCarteraId(int carteraId)
        {
            return await _context.Historiales
                .Where(p => p.CarteraId == carteraId)
                .Include(p => p.Cartera)
                .ToListAsync();
        }

        public void Update(Historial historial)
        {
            _context.Historiales.Update(historial);
        }

        public void Remove(Historial historial)
        {
            _context.Historiales.Remove(historial);
        }
    }
}