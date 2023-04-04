using AluraChallenge.Adopet.Core.Resources;

namespace AluraChallenge.Adopet.Core.Exceptions
{
    public class EmptyNameException : Exception
    {
        public EmptyNameException() : base(Messages.EmptyNameException) { }
    }
}
