using AluraChallenge.Adopet.Domain.Abstraction;

namespace AluraChallenge.Adopet.Domain.Extensions
{
    public static class PersonEntityExtensions
    {
        public static string GetFullAddress(this Person person)
        {
            return $"{person.AddressDescription}; {person.City?.Name} - {person.City?.UF}";
        }
    }
}
