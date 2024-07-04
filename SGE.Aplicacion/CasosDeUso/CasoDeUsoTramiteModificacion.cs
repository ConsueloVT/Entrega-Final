namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Enumerativos;
public class CasoDeUsoTramiteModificacion (ITramiteRepositorio _tramiteRepositorio, IServicioAutorizacion servicioAutorizacion,ServicioActualizacionEstado actualizar):TramiteCasoDeUso(_tramiteRepositorio)
{
     public void Ejecutar(Tramite tramite, int idUsuario)
    {
        
            // Verificar permisos
            if(servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.TramiteModificacion)){
                tramite.IdUsuarioUltimaModificacion = idUsuario;
                // Validar tramite
                string mensajeError;
                if(!TramiteValidador.Validar(tramite,out mensajeError)){
                    throw new ValidacionException(mensajeError);
                }
                else{
                    var aux = Repositorio.ObtenerPorId(tramite.Id);
                    if(aux != null){  
                        //Asigno el valor a los campos que no se modifican
                        tramite.ExpedienteId = aux.ExpedienteId;
                        tramite.FechaCreacion = aux.FechaCreacion;
                        // Asignar fecha de modificación
                        tramite.UltimaModificacion = DateTime.Now;
                        // Guardar tramite en el repositorio
                        Repositorio.Modificar(tramite);
                        //Actualizar estado del expediente
                        actualizar.ActualizarEstado(aux.ExpedienteId);
                    }
                    else{
                        throw new RepositorioException("El trámite con el id ingresado no existe.");
                    }  

                }
            }
             else{
                throw new AutorizacionException();
             }
    }

}
