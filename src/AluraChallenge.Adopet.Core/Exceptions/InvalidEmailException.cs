using AluraChallenge.Adopet.Core.Resources;

namespace AluraChallenge.Adopet.Core.Exceptions
{
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException() : base(Messages.InvalidEmailException) { }
    }
}
