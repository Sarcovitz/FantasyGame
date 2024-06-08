using FantasyGame.Configs;
using FantasyGame.Services.Interfaces;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;

namespace FantasyGame.Services;

public class CryptographyService : ICryptographyService
{
    private readonly CryptographyConfig _cryptographyConfig;

    public CryptographyService(IOptions<CryptographyConfig> cryptographyConfig)
    {
        _cryptographyConfig = cryptographyConfig.Value;
    }

    #region ICryptographyService
    public string AesDecrypt(string cipherText)
    {
        using Aes aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(_cryptographyConfig.AesKey);
        aes.IV = Encoding.UTF8.GetBytes(_cryptographyConfig.AesIV);

        using var decryptor = aes.CreateDecryptor();
        using var ms = new MemoryStream(Convert.FromBase64String(cipherText));
        using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
        using var sr = new StreamReader(cs);
        return sr.ReadToEnd();
    }

    public string AesEncrypt(string input)
    {
        using Aes aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(_cryptographyConfig.AesKey);
        aes.IV = Encoding.UTF8.GetBytes(_cryptographyConfig.AesIV);
        aes.Mode = CipherMode.CBC;

        using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
        using var ms = new MemoryStream();
        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
        using (var sw = new StreamWriter(cs))
        {
            sw.Write(input);
        }
        return Convert.ToBase64String(ms.ToArray());
    }

    public string GetSHA256Hash(string input)
    {
        input += _cryptographyConfig.HashSalt;

        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(input));

        StringBuilder builder = new();
        foreach (byte b in bytes)
        {
            builder.Append(b.ToString("x2"));
        }

        return builder.ToString();
    }

    #endregion ICryptographyService
}
