using AluraChallenge.Adopet.Core.Exceptions;
using System.Text.RegularExpressions;

namespace AluraChallenge.Adopet.Core.ValueObjects
{
    public class Email
    {
        public string Address { get; } = string.Empty;

        protected Email() { }

        public Email(string address)
        {
            if (string.IsNullOrEmpty(address))
                throw new InvalidEmailException();

            Address = address.ToLower().Trim();
            const string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

            if (!Regex.IsMatch(address, pattern))
                throw new InvalidEmailException();
        }
    }
}
