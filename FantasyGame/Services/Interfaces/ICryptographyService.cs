namespace FantasyGame.Services.Interfaces;

/// <summary>
///     Interface for service responsible cryptographic operations.
/// </summary>
public interface ICryptographyService
{
    /// <summary>
    ///     Function responsible for getting decrypted AES cipher value.
    /// </summary>
    /// <param name="cipherText">Input cipher <see cref="string"/> that should be decrypted.</param>
    /// <returns>A <see cref="Task"/> with <see cref="string"/> - decrypted cipher value.</returns>
    public Task<string> AesDecryptAsync(string cipherText);
    public Task<string> AesEncryptAsync(string input);

    /// <summary>
    ///     Function responsibole for getting SHA256 hash of supplied string.
    /// </summary>
    /// <param name="input">Input string that should be hashed.</param>
    /// <returns>A <see cref="Task"/> with string value of hash.</returns>
    public Task<string> GetSHA256HashAsync(string input);
}
