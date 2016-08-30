using System.Security.Cryptography;
using System.Text;

namespace PwdWDecorator.Decorator
{
    public class MD5Decorator: Decorator
    {
        public override string Hash(string data)
        {
            string hashed = base.Hash(data);
            MD5 md5 = MD5.Create();
            byte[] computed = md5.ComputeHash(Encoding.UTF8.GetBytes(hashed));
            StringBuilder sb = new StringBuilder();
            foreach (var item in computed)
            {
                sb.Append(item.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
