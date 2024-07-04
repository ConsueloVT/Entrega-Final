namespace SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set;}="";
    public string Apellido { get; set;}="";
    public String CorreoElectronico { get; set;}="";
    public string HashContraseña { get; set;}="";
    public string SalContraseña { get; set; } = "";
    public List<Permiso> ListaPermisos{get; set;} = new List<Permiso>();

    public override string ToString()
    {
        return $"Usuario:/nNombre:{Nombre}, Apellido: {Apellido}, Correo Electrónico:{CorreoElectronico}";
    }

}
