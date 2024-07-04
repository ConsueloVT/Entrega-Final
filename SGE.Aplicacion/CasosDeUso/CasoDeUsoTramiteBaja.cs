namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Enumerativos;
public class CasoDeUsoTramiteBaja(ITramiteRepositorio _tramiteRepositorio, IServicioAutorizacion _servicioAutorizacion,ServicioActualizacionEstado actualizar): TramiteCasoDeUso(_tramiteRepositorio)
{
        public void Ejecutar(Tramite tramite, int idUsuario){
                // Verificar permisos
                if(_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.TramiteBaja)){
                    tramite.IdUsuarioUltimaModificacion = idUsuario;
                    Tramite? aux = Repositorio.ObtenerPorId(tramite.Id);
                    if(aux != null){  
                        Repositorio.Eliminar(aux);
                        //Actualizar estado del expediente
                        actualizar.ActualizarEstado(aux.ExpedienteId);
                    }
                    else{
                        throw new RepositorioException("Id de trámite no encontrado");
                    }

                }
                else{
                    throw new AutorizacionException();
                } 
        }

}
