using AluraChallenge.Adopet.Core.Resources;

namespace AluraChallenge.Adopet.Core.Exceptions
{
    public class EmptyBehaviorException : Exception
    {
        public EmptyBehaviorException() : base(Messages.EmptyBehaviorException)
        {

        }
    }
}
