namespace utils.apifinport
{
    public class PasswordHash
    {
        public static string Hash(string input)
        {
            return BCrypt.Net.BCrypt.HashPassword(input);
        }
        public static bool IsPasswordValid(string hashed, string input)
        {
            return BCrypt.Net.BCrypt.Verify(input, hashed);
        }
    }
}