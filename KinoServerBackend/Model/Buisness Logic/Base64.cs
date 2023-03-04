using System.Text;

namespace KinoServerBackend.Model
{
    public class Base64
    {
        public static string Encode(string data) {
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            string encoded = Convert.ToBase64String(bytes);
            return encoded;
        }

        public static string Decode(string data) {
            byte[] bytes = Convert.FromBase64String(data);
            string decoded = Encoding.UTF8.GetString(bytes);
            return decoded;
        }
}
}
