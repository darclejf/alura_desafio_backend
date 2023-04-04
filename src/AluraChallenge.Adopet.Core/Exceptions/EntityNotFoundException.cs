using AluraChallenge.Adopet.Core.Resources;

namespace AluraChallenge.Adopet.Core.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException() : base(Messages.EntityNotFoundException) { }
    }
}
