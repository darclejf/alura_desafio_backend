namespace AluraChallenge.Adopet.Core.Models
{
    [Serializable]
    public class ErrorResponse
    {
        public List<string>? Messages { get; set; }

        public ErrorResponse() { }

        public ErrorResponse(List<string>? messages)
        {
            Messages = messages;
        }
    }
}
