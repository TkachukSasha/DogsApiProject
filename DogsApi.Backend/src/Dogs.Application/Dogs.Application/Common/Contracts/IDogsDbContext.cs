using Dogs.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Dogs.Application.Common.Contracts
{
    public interface IDogsDbContext
    {
        DbSet<Dog> Dogs { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
