namespace AluraChallenge.Adopet.Core.Models
{
    public class PersonListItemResponse : BaseEntityResponse
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
    }
}
