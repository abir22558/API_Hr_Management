using HrManagement.Domain.Abstractions;
using HrManagement.Domain.ValuesObjects;

namespace HrManagement.Domain.Models
{
    public class Candidat : Entity<Email>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public PhoneNumber? PhoneNumber { get; set; }
        public CallTimeInterval? CallTimeInterval { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? GitHubUrl { get; set; }
        public string Comments { get; set; }

        //  factory method with all initialization logic
        public static Candidat Create(Email email, string firstName, string lastName, string comments,
            PhoneNumber? phoneNumber = null, CallTimeInterval? callTimeInterval = null,
            string? linkedInUrl = null, string? gitHubUrl = null)
        {
            var candidate = new Candidat
            {
                Id = Email.Of(email.Value),
                FirstName = firstName,
                LastName = lastName,
                Comments = comments,
                PhoneNumber = string.IsNullOrEmpty(phoneNumber?.Value) ? null : PhoneNumber.Of(phoneNumber.Value),
                LinkedInUrl = linkedInUrl,
                GitHubUrl = gitHubUrl,
                CreatedAt = DateTime.UtcNow,
            };

            if (callTimeInterval != null)
            {
                candidate.CallTimeInterval = CallTimeInterval.Of(callTimeInterval);
            }

            return candidate;
        }

        // Methods to update properties
        public void Update(Email email, string firstName, string lastName, string comments,
            PhoneNumber? phoneNumber = null, CallTimeInterval? callTimeInterval = null,
            string? linkedInUrl = null, string? gitHubUrl = null)
        {
            Id = Email.Of(email.Value);
            FirstName = firstName;
            LastName = lastName;
            Comments = comments;
            PhoneNumber = string.IsNullOrEmpty(phoneNumber?.Value) ? null : PhoneNumber.Of(phoneNumber.Value);
            LinkedInUrl = linkedInUrl;
            GitHubUrl = gitHubUrl;
            LastModified = DateTime.UtcNow;

            if (callTimeInterval != null)
            {
                CallTimeInterval = CallTimeInterval.Of(callTimeInterval);
            }
        }
    }
}
