namespace AluraChallenge.Adopet.ApplicationQuery.ViewModels
{
    [Serializable]
    public class TutorViewModel
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public Guid UserId { get; private set; }
        public string UserName { get; private set; }
    }
}
