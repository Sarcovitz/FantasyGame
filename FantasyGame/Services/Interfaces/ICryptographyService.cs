namespace FantasyGame.Services.Interfaces;

public interface ICryptographyService
{
    public string AesEncrypt(string input);
    public string AesDecrypt(string cipherText);
    public Task<string> GetSHA256HashAsync(string input);
}
