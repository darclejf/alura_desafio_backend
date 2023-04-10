namespace AluraChallenge.Adopet.Core.Models
{
    [Serializable]
    public class PaginationListResponse<T>
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
