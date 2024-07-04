namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
public class CasoDeUsoUsuarioBaja (IUsuarioRepositorio _usuarioRepositorio,IServicioAutorizacion servicioAutorizacion):UsuarioCasoDeUso(_usuarioRepositorio)
{
    public void Ejecutar(Usuario usuario, int idUsuario){
                // Verificar permisos
                if(servicioAutorizacion.PoseeElPermiso(idUsuario,Permiso.UsuarioBaja) ){

                    Usuario? aux=Repositorio.ObtenerPorId(usuario.Id);
                    if( aux != null){  
                        Repositorio.Eliminar(aux);
                    }
                    else{
                        throw new RepositorioException("Id de usuario no encontrado");
                    }
                }
                else{
                    throw new AutorizacionException();
                } 
        }


}
