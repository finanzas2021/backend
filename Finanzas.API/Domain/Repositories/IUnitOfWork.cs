using System.Threading.Tasks;

namespace Finanzas.API.Domain.Respositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}