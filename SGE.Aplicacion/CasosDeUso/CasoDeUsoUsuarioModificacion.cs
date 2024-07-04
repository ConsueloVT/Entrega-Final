namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
public class CasoDeUsoUsuarioModificacion(IUsuarioRepositorio _usuarioRepositorio,IServicioAutorizacion servicioAutorizacion):UsuarioCasoDeUso(_usuarioRepositorio)
{
    public void Ejecutar(Usuario usuario, int idUsuario){
        if(servicioAutorizacion.PoseeElPermiso(idUsuario,Permiso.UsuarioModificacion)|| idUsuario== usuario.Id){
            var aux=Repositorio.ObtenerPorId(usuario.Id);
            if(aux!=null) {
                usuario.ListaPermisos=aux.ListaPermisos;
                Repositorio.Modificar(usuario);
            }
        }
        else{
            throw new AutorizacionException();
        }
    }
}
