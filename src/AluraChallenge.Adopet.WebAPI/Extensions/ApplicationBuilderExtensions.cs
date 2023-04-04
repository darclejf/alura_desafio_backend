using AluraChallenge.Adopet.WebAPI.Middlewares;

namespace AluraChallenge.Adopet.WebAPI.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddGlobalErrorHandler(this IApplicationBuilder applicationBuilder)
            => applicationBuilder.UseMiddleware<GlobalErrorHandlingMiddleware>();
    }
}
