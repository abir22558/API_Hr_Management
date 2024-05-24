using HrManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HrManagement.Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Candidate> Candidates { get; }
    }
}
