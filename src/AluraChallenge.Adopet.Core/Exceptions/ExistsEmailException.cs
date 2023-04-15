using AluraChallenge.Adopet.Core.Resources;

namespace AluraChallenge.Adopet.Core.Exceptions
{
    public class ExistsEmailException : Exception
    {
        public ExistsEmailException() : base(Messages.ExistsEmailException)
        {

        }
    }
}
