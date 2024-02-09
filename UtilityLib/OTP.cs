namespace UtilityLib
{
    public class OTP
    {
        public string GetOTP(string otpType = "1", int len = 5)
        {
            string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "1234567890";
            string characters = numbers;
            if (otpType == "1")
            {
                characters += alphabets + small_alphabets + numbers;

            }
            int lenght = 5;
            string otp = string.Empty;
            for (int i = 0; i < lenght; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (otp.IndexOf(character) != -1);
                otp += character;
            }
            return otp;
        }
    }
}
