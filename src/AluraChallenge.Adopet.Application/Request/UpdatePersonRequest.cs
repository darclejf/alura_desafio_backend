namespace AluraChallenge.Adopet.Application.Request
{
    public class UpdatePersonRequest
    {
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? UrlImage { get; set; }
        public string? AddressDescription { get; set; }
        public Guid? CityId { get; set; }
        public string? CityName { get; set; }
        public string? Uf { get; set; }
        public string? About { get; set; }
    }
}
