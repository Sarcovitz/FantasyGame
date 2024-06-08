namespace FantasyGame.Services.Interfaces;

public interface ICryptographyService
{
    public string GetSHA256Hash(string input);
    public string AesEncrypt(string input);
    public string AesDecrypt(string cipherText);
}
