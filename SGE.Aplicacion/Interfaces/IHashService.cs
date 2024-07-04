namespace SGE.Aplicacion.Interfaces;

public interface IHashService
{
    (string Hash, string Salt) CreateHash(string password);
    bool VerifyHash(string password, string hash, string salt);
}