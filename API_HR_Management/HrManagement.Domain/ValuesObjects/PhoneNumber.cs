
using HrManagement.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace HrManagement.Domain.ValuesObjects
{
    public record PhoneNumber
    {
        public string? Value { get; set; }
        public static PhoneNumber Of(string? Value)
        {
            Value = Value?.Trim();

            if (Value is not null && !IsValidPhoneNumber(Value))
                throw new DomainException("Phone number is not in a valid format.");

            return new PhoneNumber { Value = Value };
        }

        private static bool IsValidPhoneNumber(string phoneNumber)
        {
            // Regex pattern to match common international phone number formats
            string pattern = @"^\+?([0-9]{1,3})?([ .-])?((\([0-9]{1,3}\))|[0-9]{1,3})?([ .-])?[0-9]{1,4}([ .-])?[0-9]{1,4}([ .-])?[0-9]{1,9}$";
            var regex = new Regex(pattern, RegexOptions.Compiled);
            return regex.IsMatch(phoneNumber);
        }
    }
}
