namespace AluraChallenge.Adopet.ApplicationQuery.Response
{
    public class ShelterQueryResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public Guid UserId { get; set; }
        public string? AddressDescription { get; set; }
        public Guid? CityId { get; set; }
        public string? CityName { get; set; }
        public string? UrlImage { get; set; }
    }
}
