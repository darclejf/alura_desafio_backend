using FluentValidation.Results;

namespace AluraChallenge.Adopet.Application.Extensions
{
    public static class ValidationExtensions
    {
        public static List<string>? ToErrorResponse(this ValidationResult validationResult)
        {
            return validationResult.Errors?.Select(x => x.ErrorMessage).ToList();
        }
    }
}
