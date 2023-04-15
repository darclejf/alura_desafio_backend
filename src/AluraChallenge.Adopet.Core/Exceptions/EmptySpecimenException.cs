using AluraChallenge.Adopet.Core.Resources;

namespace AluraChallenge.Adopet.Core.Exceptions
{
    public class EmptySpecimenException : Exception
    {
        public EmptySpecimenException() : base(Messages.EmptySpecimenException)
        {

        }
    }
}
