namespace IssueTracker.ModelLayer.Base
{
    public sealed class Error
    {
        public ErrorType ErrorType { get; set; }
        public string Code { get; set; }
        public string Description { get; set; } = null;

        public static readonly Error None = new Error(ErrorType.None, string.Empty);

        public Error(ErrorType errorType, string code, string description = null)
        {
            ErrorType = errorType;
            Code = code;
            Description = description;
        }
    }

    public enum ErrorType
    {
        None = 0,
        Validation = 1,
        Failure = 2
    }
}
