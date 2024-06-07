namespace FantasyGame.Services.Interfaces;

public interface ICryptographyService
{
    public string GetSHA256HashString(string input);
    public string AesEncrypt(string input);
    public string AesDecrypt(string cipherText);
}
