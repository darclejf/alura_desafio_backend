namespace AluraChallenge.Adopet.Application.Response
{
    [Serializable]
    public class ShelterResponse : BaseEntityResponse
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public Guid UserId { get; set; }
        public string? AddressDescription { get; set; }
        public Guid? CityId { get; set; }
        public string? CityName { get; set; }
        public string? UrlImage { get; set; }
        public string? About { get; set; }
    }
}
