namespace SGE.Aplicacion.Interfaces;
using  SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
public interface IUsuarioRepositorio
{
    public int Agregar(Usuario u);
    public void Eliminar (Usuario u);
    public List<Usuario>? ListarTodos();
    public void Modificar (Usuario u);
    public Usuario? ObtenerPorId(int id);
    public Usuario? IniciarSesion(string correo);
    public bool BuscarPorCorreoElectronico(string correo);
    public void AgregarPermisoUsuario(int id,Permiso permiso);
    public List<Permiso>? GetPermisos(int id);
}
