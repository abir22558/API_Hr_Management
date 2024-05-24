using HrManagement.Domain.ValuesObjects;

namespace HrManagement.Application.Dtos
{
    public class CandidateDto
    {
        public Email Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public PhoneNumber? PhoneNumber { get; set; }
        public CallTimeInterval? CallTimeInterval { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? GitHubUrl { get; set; }
        public string Comments { get; set; }
    }
}
