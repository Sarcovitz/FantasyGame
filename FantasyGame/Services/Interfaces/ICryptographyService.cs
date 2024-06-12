namespace FantasyGame.Services.Interfaces;

public interface ICryptographyService
{
    public Task<string> AesDecryptAsync(string cipherText);
    public Task<string> AesEncryptAsync(string input);
    public Task<string> GetSHA256HashAsync(string input);
}
