using System.Runtime.InteropServices;
using System.Text;

namespace ProtegrityProtector
{

    public class ProtectorException : Exception
    {
        public ProtectorException()
        {
        }

        public ProtectorException(string message)
            : base(message)
        {
        }

        public ProtectorException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    public class Session
    {
        public string SessionId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsActive { get; private set; }
        private Protector _protector;

        public Session()
        {
            SessionId = Guid.NewGuid().ToString();
            CreatedAt = DateTime.UtcNow;
            IsActive = true;
            _protector = new Protector();
        }

        public void EndSession()
        {
            IsActive = false;
        }

        public Protector GetProtector()
        {
            return _protector;
        }
    }

    public class Protector
    {
        private const string Key = "sample-key";

        public string Encrypt(string data)
        {
            char[] buffer = data.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = (char)(buffer[i] + 1);
            }
            return new string(buffer);
        }

        public string Decrypt(string data)
        {
            char[] buffer = data.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = (char)(buffer[i] - 1);
            }
            return new string(buffer);
        }

        public string GetVersion()
        {
            return "1.0.0";
        }

        public bool CheckAccess(string userName, string dataElement, int accessType) 
        { 
            return false; 
        }

        public string Protect(string input, string userName, string dataElementName, byte[] externalIv , byte[] externalTweak )
        {
            string output = Decrypt(input);
            return output;
        }

        public byte[] StringToByteArray(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return new byte[0]; 
            }

            // Convert the string to a byte array using UTF8 encoding
            return System.Text.Encoding.UTF8.GetBytes(input);
        }

        public Tuple<string[], int[]> Protect(string[] input, string userName, string dataElementName, byte[] externalIv , byte[] externalTweak )
        {
            string[] names = { "Alice", "Bob", "Charlie" };
            int[] ages = { 25, 30, 35 };

            return Tuple.Create(names, ages);
          
        }

        public byte[] Protect(byte[] input, string userName, string dataElementName, byte[] externalIv , byte[] externalTweak ,int charset)
        {

            byte[] byteArray = StringToByteArray("");
            return byteArray;

        }

        public Tuple<List<byte[]>, int[]> Protect(List<byte[]> input, string userName, string dataElementName, byte[] externalIv , byte[] externalTweak , int charset )
        {

            List<byte[]> byteArrayList = new List<byte[]>
            {
                new byte[] { 1, 2, 3 },
                new byte[] { 4, 5, 6 }
            };

            int[] numbers = { 10, 20, 30 };

            return Tuple.Create(byteArrayList, numbers);

        }

        /*
         *  string singleProt = protector.Protect("Protegrity1234", "user1", "AlphaNum", 
            Encoding.UTF8.GetBytes("abcd123"), null);
            string singleUnprot = protector.Unprotect(singleProt, "user1", "AlphaNum", 
            Encoding.UTF8.GetBytes("abcd123"), null);
        */

        public string Unprotect(string input, string userName, string dataElementName, byte[] externalIv , byte[] externalTweak )
        {
            return "";
        }




        /*
         * Tuple<string[], int[]> prot = protector.Protect({"Protegrity1", "Protegrity2", 
            "Protegrity3"}, "user1", "AlphaNum", Encoding.UTF8.GetBytes("abcd123"), null);
            Tuple<string[], int[]> unprot = protector.Unprotect(prot.Item1, "user1", "AlphaNum", 
Encoding.UTF8.GetBytes("abcd123"), null);
        */

        public Tuple<string[], int[]> Unprotect(string[] input, string userName, string dataElementName, byte[] externalIv , byte[] externalTweak  )
        {

            string[] names = { "Alice", "Bob", "Charlie" };
            int[] ages = { 25, 30, 35 };

            return Tuple.Create(names, ages);
        }



        /*byte[] singleByteProt = protector.Protect(Encoding.Unicode.GetBytes("Protegrity123"),
        "user1", "UnicodeGen2_UTF16LE", Encoding.UTF8.GetBytes("abcd123"), null, charset:
        Charset.UTF16LE);
                byte[] singleByteUnprot = protector.Unprotect(singleByteProt,
                "user1", "UnicodeGen2_UTF16LE", Encoding.UTF8.GetBytes("abcd123"), null,
                charset: Charset.UTF16LE);
        */


        public byte[]  Unprotect(byte[] input, string userName, string dataElementName, byte[] externalIv , byte[] externalTweak, int charset )
        {
            byte[] byteArray = StringToByteArray("");
            return byteArray;
        }








    }


}