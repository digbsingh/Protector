using System.Text;

internal class Program
{
    static void Main()
    {
        var session = new ProtegrityProtector.Session();
        Console.WriteLine($"Session Created: {session.SessionId} at {session.CreatedAt}");

        var protector = session.GetProtector();
        string secret = "HelloWorld";
        string encrypted = protector.Encrypt(secret);
        string decrypted = protector.Decrypt(encrypted);

        Console.WriteLine($"Original: {secret}");
        Console.WriteLine($"Encrypted: {encrypted}");
        Console.WriteLine($"Decrypted: {decrypted}");
        Console.WriteLine($"Protector Version: {protector.GetVersion()}");

        string singleProt = protector.Protect("Protegrity1234", "user1", "AlphaNum",Encoding.UTF8.GetBytes("abcd123"), null);

        Console.WriteLine($"protector.Protect: {singleProt}");
    }
}