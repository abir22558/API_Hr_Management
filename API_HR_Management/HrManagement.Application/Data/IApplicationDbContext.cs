using HrManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HrManagement.Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Domain.Models.Candidate> Candidates { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
