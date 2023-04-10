using AluraChallenge.Adopet.Core.Exceptions;
using AluraChallenge.Adopet.Domain.Abstraction;
using AluraChallenge.Adopet.Domain.DomainEvents;
using AluraChallenge.Adopet.Domain.Enums;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace AluraChallenge.Adopet.Domain
{
    public class User : Entity
    {
        public string UserName { get; protected set; }
        public string Password { get; protected set; }
        public ProfileRole Role { get; protected set; }

        protected User() { }

        public static User Create(
                    string userName, 
                    string password, 
                    string confirmPassword,
                    ProfileRole role)
        {
            ValidatePassword(password, confirmPassword);
            var user = new User
            {
                UserName = userName,
                Password = password,
                Role = role
            };

            //user.AddDomainEvent(new CreateEntityDomainEvent<User>(user));
            return user;    
        }

        /// <summary>
        /// Método para alterar a senha do tutor
        /// </summary>
        /// <param name="password"></param>
        /// <param name="confirmPassword"></param>
        public void ChangePassword(string password, string confirmPassword)
        {
            ValidatePassword(password, confirmPassword);
            Password = password;
        }

        private static void ValidatePassword(string password, string confirmPassword)
        {
            if (string.IsNullOrEmpty(password))
                throw new InvalidPasswordException();

            //TODO implementar validacao com regex
            //A senha deve conter pelo menos uma letra maiúscula, um número e ter entre 6 e 15 caracteres

            if (password != confirmPassword)
                throw new InvalidConfirmationPasswordException();
        }

        //TODO
        private static string Encrypt(string password)
        {
            // Generate a 128-bit salt using a sequence of
            // cryptographically strong random bytes.
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes

            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
        }
    }
}
