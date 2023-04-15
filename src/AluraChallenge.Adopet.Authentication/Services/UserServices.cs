using AluraChallenge.Adopet.Authentication.Interfaces;
using AluraChallenge.Adopet.Authentication.Models;
using AluraChallenge.Adopet.Authentication.Request;
using AluraChallenge.Adopet.Authentication.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AluraChallenge.Adopet.Authentication.Services
{
    public class UserServices : IUserServices
    {
        private UserManager<IdentityUser<Guid>> _userManager;
        private IdentityUser<Guid>? _user;

        public UserServices(UserManager<IdentityUser<Guid>> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityUser<Guid>> CreateUserAsync(CreateUserDto create)
        {
            var userIdentity = new IdentityUser<Guid>
            {
                Email = create.Email,
                UserName = create.Email,
            };

            var resultIdentity = await _userManager.CreateAsync(userIdentity, create.Password);
            await _userManager.AddToRoleAsync(userIdentity, create.Role);

            if (resultIdentity.Succeeded)
                return userIdentity;

            throw new NotImplementedException();
        }

        public async Task<bool> ValidateUserAsync(LoginRequest request)
        {
            _user = await _userManager.FindByNameAsync(request.Username);
            var result = _user != null && await _userManager.CheckPasswordAsync(_user, request.Password);
            return result;
        }

        public async Task<TokenResponse> CreateTokenAsync()
        {
            var role = (await _userManager.GetRolesAsync(_user)).FirstOrDefault();
            var claims = new Claim[]
            {
                new Claim("username", _user.UserName),
                new Claim("id", _user.Id.ToString()),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("akldaklds#45lsadjdsa%67ajkdsakjdsajkasdksakdsajlaskhldakhskajhda"));
            var credenciais = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: credenciais,
                expires: DateTime.UtcNow.AddHours(24));

            return new TokenResponse { Token = new JwtSecurityTokenHandler().WriteToken(token) };
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null) 
                return false;
            
            await _userManager.DeleteAsync(user);
            return true;
        }
    }
}
