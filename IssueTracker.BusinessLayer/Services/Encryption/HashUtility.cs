namespace IssueTracker.BusinessLayer.Services.Encryption
{
    public class HashUtility
    {
        public const string SALT = "ABC123!@";

        public static string Create(string queryString, string salt)
        {
            var hash = SsplSecurity.Encrypt($"{queryString}|{salt}", salt);
            var convertedHash = hash.Replace('+', '-').Replace('/', '_');

            return convertedHash;
        }

        public static bool Validate(string queryString, string salt, string hash)
        {
            var expectedHash = HashUtility.Create(queryString, salt);

            return hash == expectedHash;
        }

        public static bool ValidateSimpleHash(string queryString, string hash)
        {
            var actualHash = hash.Replace('-', '+').Replace('_', '/');

            var convertedHash = SsplSecurity.CreateSimpleHash(queryString, SALT);

            return actualHash == convertedHash;
        }
    }
}
