namespace Aplication.Interfaces;

public interface IHash
{
    public string HashPassword(string password, byte[] salt);
}