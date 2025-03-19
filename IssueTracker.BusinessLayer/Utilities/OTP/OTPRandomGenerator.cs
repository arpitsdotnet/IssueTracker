using System;

namespace IssueTracker.BusinessLayer.Utilities.OTP
{
    public class OTPRandomGenerator : IOTPRandomGenerator
    {
        private readonly Random _random = new Random();

        public string Generate(int length = 5)
        {
            string characters = "1234567890";
            string otp = string.Empty;
            for (int i = 0; i <= length - 1; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = _random.Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                }
                while (otp.IndexOf(character) != -1);
                otp += character;
            }

            return otp;
        }
    }
}
