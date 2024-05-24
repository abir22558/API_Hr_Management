using HrManagement.Domain.Models;
using HrManagement.Domain.ValuesObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HrManagement.Infrastructure.Data.Configurations
{
    public class ApplicationContextConfiguration : IEntityTypeConfiguration<Candidate>
    {
        //configure the email as a primary key
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Email").HasConversion(
                email => email.Value,
                dbId => Email.Of(dbId));


            builder.Property(c => c.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.LastName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Comments).IsRequired().HasMaxLength(150);

            // Configure the optional CallTimeInterval as a complex type
            builder.OwnsOne(c => c.CallTimeInterval, callTimeIntervalBuilder =>
            {
                callTimeIntervalBuilder.Property(t => t.StartTime).HasColumnName("StartTime").HasColumnType("datetime2").IsRequired(false).IsSparse();
                callTimeIntervalBuilder.Property(t => t.EndTime).HasColumnName("EndTime").HasColumnType("datetime2").IsRequired(false).IsSparse();
            });

            builder.OwnsOne(c => c.PhoneNumber, phoneNumberBuilder =>
            {
                // Configure the PhoneNumber value Type as optional complex type
                phoneNumberBuilder.Property(p => p.Value)
                    .HasColumnName("PhoneNumber")
                    .HasColumnType("varchar(20)")
                    .IsRequired(false).IsSparse();  // Marks the property as optional
            });

            // Seed data
            builder.HasData(
                new Candidate
                {
                    Id = Email.Of("john.doe@example.com"),
                    FirstName = "John",
                    LastName = "Doe",
                    Comments = "Sample comment",
                    LinkedInUrl = "https://www.linkedin.com/in/johndoe",
                    GitHubUrl = "https://github.com/johndoe",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "admin",
                    LastModified = DateTime.UtcNow,
                    LastModifiedBy = "admin"
                },
                new Candidate
                {
                    Id = Email.Of("jane.doe@example.com"),
                    FirstName = "Jane",
                    LastName = "Doe",
                    Comments = "Another comment",
                    LinkedInUrl = "https://www.linkedin.com/in/janedoe",
                    GitHubUrl = "https://github.com/janedoe",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "admin",
                    LastModified = DateTime.UtcNow,
                    LastModifiedBy = "admin"
                }
            );

        }
    }
}
