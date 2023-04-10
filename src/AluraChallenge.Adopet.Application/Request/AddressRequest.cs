namespace AluraChallenge.Adopet.Application.Request
{
    public class AddressRequest
    {
        public string? AddressDescription { get; set; }
        public Guid? CityId { get; set; }
        public string? CityName { get; set; }
        public string? Uf { get; set; }
    }
}
