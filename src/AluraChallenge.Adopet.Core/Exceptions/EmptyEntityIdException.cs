using AluraChallenge.Adopet.Core.Resources;

namespace AluraChallenge.Adopet.Core.Exceptions
{
    public class EmptyEntityIdException : Exception
    {
        public EmptyEntityIdException() : base(Messages.EmptyEntityIdException)
        {

        }
    }
}
