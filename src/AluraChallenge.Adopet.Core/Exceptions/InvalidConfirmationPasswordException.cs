using AluraChallenge.Adopet.Core.Resources;

namespace AluraChallenge.Adopet.Core.Exceptions
{
    public class InvalidConfirmationPasswordException : Exception
    {
        public InvalidConfirmationPasswordException() : base(Messages.InvalidConfirmationPasswordException) { }
    }
}
