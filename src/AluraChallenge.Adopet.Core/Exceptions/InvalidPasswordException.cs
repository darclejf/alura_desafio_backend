using AluraChallenge.Adopet.Core.Resources;

namespace AluraChallenge.Adopet.Core.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException() : base(Messages.InvalidPasswordException) { }
    }
}
