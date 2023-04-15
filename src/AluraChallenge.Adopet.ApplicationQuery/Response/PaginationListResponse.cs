namespace AluraChallenge.Adopet.ApplicationQuery.Response
{
    [Serializable]
    public class PaginationListResponse<T>
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
