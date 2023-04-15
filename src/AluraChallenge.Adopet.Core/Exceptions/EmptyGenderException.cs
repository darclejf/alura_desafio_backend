using AluraChallenge.Adopet.Core.Resources;

namespace AluraChallenge.Adopet.Core.Exceptions
{
    public class EmptyGenderException : Exception
    {
        public EmptyGenderException() : base(Messages.EmptyGenderException)
        {

        }
    }
}
