namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
public class CasoDeUsoUsuarioConsultaTodos(IUsuarioRepositorio _usuarioRepositorio,IServicioAutorizacion servicioAutorizacion):UsuarioCasoDeUso(_usuarioRepositorio)
{
    public List<Usuario> Ejecutar(int idUsuario)
    {
        if(servicioAutorizacion.PoseeElPermiso(idUsuario,Permiso.ListarUsuarios)){
            /*lista todos los usuarios */
            return Repositorio.ListarTodos();
        }
        else{
            throw new AutorizacionException();
        }
        
    }

}
