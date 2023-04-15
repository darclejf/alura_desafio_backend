using AluraChallenge.Adopet.Core.Resources;

namespace AluraChallenge.Adopet.Core.Exceptions
{
    public class EmptySizeException : Exception
    {
        public EmptySizeException() : base(Messages.EmptySizeException)
        {

        }
    }
}
