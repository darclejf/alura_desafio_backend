using AluraChallenge.Adopet.Core.Resources;

namespace AluraChallenge.Adopet.Core.Exceptions
{
    public class EmptyUFException : Exception
    {
        public EmptyUFException() : base(Messages.EmptyUFException)
        { }
    }
}
