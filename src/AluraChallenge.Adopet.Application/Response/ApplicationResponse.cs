namespace AluraChallenge.Adopet.Application.Response
{
    [Serializable]
    public class ApplicationResponse<T>
    {
        public bool IsValid { get; set; }
        public List<string>? Messages { get; set; }
        public T? Result { get; set; }

        public ApplicationResponse() { }

        public ApplicationResponse(bool isValid, List<string>? messages, T? result)
        {
            IsValid = isValid;
            Messages = messages;
            Result = result;
        }

        public ApplicationResponse(bool isValid, T? result)
        {
            IsValid = isValid;
            Result = result;
        }

        public ApplicationResponse(bool isValid, List<string>? messages)
        {
            IsValid = isValid;
            Messages = messages;
        }
    }
}
