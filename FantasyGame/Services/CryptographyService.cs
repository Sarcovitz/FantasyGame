using FantasyGame.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace FantasyGame.Services;

public class CryptographyService : ICryptographyService
{
    #region ICryptographyService
    public string AesDecrypt(string cipherText)
    {
        using Aes aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(key);
        aes.IV = Encoding.UTF8.GetBytes(iv);

        using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
        using var ms = new MemoryStream(Convert.FromBase64String(cipherText));
        using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
        using var sr = new StreamReader(cs);
        return sr.ReadToEnd();
    }

    public string AesEncrypt(string input)
    {
        using Aes aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(key);
        aes.IV = Encoding.UTF8.GetBytes(iv);

        using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
        using var ms = new MemoryStream();
        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
        using (var sw = new StreamWriter(cs))
        {
            sw.Write(input);
        }
        return Convert.ToBase64String(ms.ToArray());
    }

    public string GetSHA256HashString(string input)
    {
        throw new NotImplementedException();
    }

    #endregion ICryptographyService
}
