using AluraChallenge.Adopet.Core.Resources;

namespace AluraChallenge.Adopet.Core.Exceptions
{
    public class EmptyPetAgeException : Exception
    {
        public EmptyPetAgeException() : base(Messages.EmptyPetAgeException)
        {

        }
    }
}
