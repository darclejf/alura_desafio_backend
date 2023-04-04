using AluraChallenge.Adopet.Core.Exceptions;
using System.Net;

namespace AluraChallenge.Adopet.WebAPI.Extensions
{
    public static class ExceptionExtensions
    {
        public static HttpStatusCode GetHttpStatusCode(this Exception exception)
        {
            if (exception.GetType() == typeof(EmptyNameException) ||
                exception.GetType() == typeof(ExistsEmailException) ||
                exception.GetType() == typeof(InvalidConfirmationPasswordException) ||
                exception.GetType() == typeof(InvalidEmailException) ||
                exception.GetType() == typeof(InvalidPasswordException))
                return HttpStatusCode.BadRequest;
            else if (exception.GetType() == typeof(EntityNotFoundException))
                return HttpStatusCode.NotFound;
            return HttpStatusCode.InternalServerError;
        }
    }
}
