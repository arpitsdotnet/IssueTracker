namespace IssueTracker.BusinessLayer.Utilities.OTP
{
    public interface IOTPRandomGenerator
    {
        string Generate(int length = 5);
    }
}
