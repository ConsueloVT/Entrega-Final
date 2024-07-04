namespace SGE.Aplicacion.Interfaces;

public interface IServicioSesion
{
    public int Id { get; set; }
    public bool Loggin(string email, string contraseña);
    public void Close();
}
