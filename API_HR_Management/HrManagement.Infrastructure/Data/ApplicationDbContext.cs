using HrManagement.Application.Data;
using HrManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace HrManagement.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        { }
        public DbSet<Candidate> Candidates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(AssemblyBuilder.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }

}
