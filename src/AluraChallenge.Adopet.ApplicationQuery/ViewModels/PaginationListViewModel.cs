namespace AluraChallenge.Adopet.ApplicationQuery.ViewModels
{
    [Serializable]
    public class PaginationListViewModel<T>
    {
        public int? Page { get; set; }
        public int? Total { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
