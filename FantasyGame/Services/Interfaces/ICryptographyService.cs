namespace FantasyGame.Services.Interfaces;

public interface ICryptographyService
{
    public Task<string> AesDecryptAsync(string cipherText);
    public Task<string> AesEncryptAsync(string input);

    /// <summary>
    ///     Function responsibole for getting SHA256 hash of supplied string.
    /// </summary>
    /// <param name="input">Input string that should be hashed.</param>
    /// <returns>A <see cref="Task"/> with string value of hash.</returns>
    public Task<string> GetSHA256HashAsync(string input);
}
