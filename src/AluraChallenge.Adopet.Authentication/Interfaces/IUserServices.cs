using AluraChallenge.Adopet.Authentication.Models;
using AluraChallenge.Adopet.Authentication.Request;
using AluraChallenge.Adopet.Authentication.Response;
using Microsoft.AspNetCore.Identity;

namespace AluraChallenge.Adopet.Authentication.Interfaces
{
    public interface IUserServices
    {
        Task<IdentityUser<Guid>> CreateUserAsync(CreateUserDto create);
        Task<bool> ValidateUserAsync(LoginRequest request);
        Task<TokenResponse> CreateTokenAsync();
        Task<bool> DeleteUserAsync(Guid id);
    }
}
