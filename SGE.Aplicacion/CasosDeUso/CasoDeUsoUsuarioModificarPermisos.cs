namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
public class CasoDeUsoUsuarioModificarPermisos(IUsuarioRepositorio _usuarioRepositorio,IServicioAutorizacion servicioAutorizacion):UsuarioCasoDeUso(_usuarioRepositorio)
{
    public void Ejecutar(int id_UsuarioM, int ID_usuario,Permiso nuevoPermiso){

        if(servicioAutorizacion.PoseeElPermiso(ID_usuario, Permiso.ModificarPermisos)){
            var ListaPermisos=Repositorio.GetPermisos( id_UsuarioM);
            if((ListaPermisos!=null) ){
                if(!ListaPermisos.Contains(nuevoPermiso)){
                    if( ( nuevoPermiso.Equals(Permiso.TramiteBaja) && ListaPermisos.Contains(Permiso.ExpedienteBaja) )||
                        ( nuevoPermiso.Equals(Permiso.ExpedienteBaja) && ListaPermisos.Contains(Permiso.TramiteBaja) )||
                        (nuevoPermiso.Equals(Permiso.ExpedienteModificacion) && ListaPermisos.Contains(Permiso.TramiteModificacion))||
                        (nuevoPermiso.Equals(Permiso.TramiteModificacion) && ListaPermisos.Contains(Permiso.ExpedienteModificacion)))
                    {
                        throw new RepositorioException("No se puede agregar este permiso al usuario porque entra en conflicto con otros permisos existentes.");
                    }
                    else{
                        Repositorio.AgregarPermisoUsuario( id_UsuarioM,nuevoPermiso);
                    }
                }
                else{
                    throw new RepositorioException("El usuario ya tiene este permiso");
                }
            }
            else{
                Repositorio.AgregarPermisoUsuario( id_UsuarioM,nuevoPermiso);
            }
        }
        else{
            throw new AutorizacionException();
        }
    }
}
