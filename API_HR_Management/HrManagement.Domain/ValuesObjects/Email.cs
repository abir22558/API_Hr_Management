
using HrManagement.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace HrManagement.Domain.ValuesObjects
{
    // ID would be of Email Type
    public record Email
    {
        public string Value { get; set; }

        public Email(string value) => Value = value.ToLowerInvariant(); 

        public static Email Of(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainException("Email cannot be null or empty.");

            value = value.Trim().ToLowerInvariant(); 

            if (!IsValidEmail(value))
                throw new DomainException("Email is not in a valid format.");

            return new Email(value);
        }

        private static bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            var regex = new Regex(pattern, RegexOptions.Compiled);
            return regex.IsMatch(email);
        }
    }
}
