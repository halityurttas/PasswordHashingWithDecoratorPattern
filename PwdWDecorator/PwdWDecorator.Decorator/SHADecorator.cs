using System.Security.Cryptography;
using System.Text;

namespace PwdWDecorator.Decorator
{
    public class SHADecorator: Decorator
    {
        public override string Hash(string data)
        {
            string hashed = base.Hash(data);
            SHA1 sha1 = SHA1.Create();
            byte[] computed = sha1.ComputeHash(Encoding.UTF8.GetBytes(hashed));
            StringBuilder sb = new StringBuilder();
            foreach (var item in computed)
            {
                sb.Append(item.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
