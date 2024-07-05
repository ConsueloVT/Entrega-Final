namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Validadores;
public class CasoDeUsoUsuarioModificacion(IUsuarioRepositorio _usuarioRepositorio,IServicioAutorizacion servicioAutorizacion,IUsuarioValidador _validador):UsuarioCasoDeUso(_usuarioRepositorio)
{
    public void Ejecutar(Usuario usuario, int idUsuario){
        if(servicioAutorizacion.PoseeElPermiso(idUsuario,Permiso.UsuarioModificacion)|| idUsuario== usuario.Id){
            var aux=Repositorio.ObtenerPorId(usuario.Id);
            if(aux!=null) {
                String mensajeError;
                if(_validador.Validar(usuario,out mensajeError)){
                    usuario.ListaPermisos=aux.ListaPermisos;
                    Repositorio.Modificar(usuario);
                }
                else{
                    throw new ValidacionException(mensajeError);
                }
            }
        }
        else{
            throw new AutorizacionException();
        }
    }
}
