using FantasyGame.Configs;
using FantasyGame.Services.Interfaces;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;

namespace FantasyGame.Services;

/// <summary>
///     Service responsible for cryptographic operations. Implementation of <see cref="IAuthService"/> interface.
/// </summary>
public class CryptographyService : ICryptographyService
{
    private readonly CryptographyConfig _cryptographyConfig;

    /// <summary>
    ///     Contructor for <see cref="CryptographyService"/>.
    /// </summary>
    /// <param name="cryptographyConfig">Injected <see cref="CryptographyConfig"/> object.</param>
    public CryptographyService(IOptions<CryptographyConfig> cryptographyConfig)
    {
        _cryptographyConfig = cryptographyConfig.Value;
    }

    #region ICryptographyService

    public async Task<string> AesDecryptAsync(string cipherText)
    {
        using Aes aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(_cryptographyConfig.AesKey);
        aes.IV = Encoding.UTF8.GetBytes(_cryptographyConfig.AesIV);

        using var decryptor = aes.CreateDecryptor();
        using var ms = new MemoryStream(Convert.FromBase64String(cipherText));
        using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
        using var sr = new StreamReader(cs);
        return await sr.ReadToEndAsync();
    }

    public async Task<string> AesEncryptAsync(string input)
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
            await sw.WriteAsync(input);
        }
        return Convert.ToBase64String(ms.ToArray());
    }

    public async Task<string> GetSHA256HashAsync(string input)
    {
        input += _cryptographyConfig.HashSalt;
        using MemoryStream ms = new(Encoding.UTF8.GetBytes(input));
        byte[] bytes = await SHA256.HashDataAsync(ms);

        StringBuilder builder = new();
        foreach (byte b in bytes)
        {
            builder.Append(b.ToString("x2"));
        }

        return builder.ToString();
    }

    #endregion ICryptographyService
}
