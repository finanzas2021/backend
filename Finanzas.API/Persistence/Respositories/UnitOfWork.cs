using System.Threading.Tasks;
using Finanzas.API.Domain.Respositories;
using Finanzas.API.Persistence.Contexts;

namespace Finanzas.API.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}