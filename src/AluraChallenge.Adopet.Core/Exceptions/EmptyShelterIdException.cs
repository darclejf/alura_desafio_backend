using AluraChallenge.Adopet.Core.Resources;

namespace AluraChallenge.Adopet.Core.Exceptions
{
    public class EmptyShelterIdException : Exception
    {
        public EmptyShelterIdException() : base(Messages.EmptyShelterIdException)
        {

        }
    }
}
