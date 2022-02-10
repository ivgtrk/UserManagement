using System.Security.Cryptography;
using System.Text;

namespace UserManagementModelNS
{
    public class Hash
    {
        /// <summary>
        /// Generate a Hash code from byte[] values
        /// </summary>
        public static string GetHash( string s )
        {
            byte[] hashValue;
            string result = "";

            using ( SHA256 hash256 = SHA256.Create() )
                hashValue = hash256.ComputeHash( Encoding.Default.GetBytes( s ) );

            for ( int i = 0; i < hashValue.Length; i++ )
                result += $"{hashValue[ i ]:x2}";
            return result;
        }
    }
}
