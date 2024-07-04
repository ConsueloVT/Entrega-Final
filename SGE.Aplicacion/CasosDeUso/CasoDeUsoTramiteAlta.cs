namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Enumerativos;


public class CasoDeUsoTramiteAlta(ITramiteRepositorio tramiteRepositorio,IServicioAutorizacion _servicioAutorizacion,ServicioActualizacionEstado actualizar):TramiteCasoDeUso(tramiteRepositorio)
{
    public void Ejecutar(Tramite tramite, int idUsuario)
    {
            // Verificar permisos
            if(_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.TramiteAlta)){
                tramite.IdUsuarioUltimaModificacion=idUsuario;
                string mensajeError;
                // Validar tramite
                if(TramiteValidador.Validar(tramite, out mensajeError)){ 
                    // Asignar Id 
                    //tramite.Id = tramiteRepositorio.ObtenerSiguienteId(); 
                    // Asignar fecha de creación y modificación
                    tramite.FechaCreacion = DateTime.Now;
                    tramite.UltimaModificacion = DateTime.Now;
                    // Guardar tramite en el repositorio
                    Repositorio.Agregar(tramite);
                    //Actualizar estado del expediente
                    actualizar.ActualizarEstado(tramite.ExpedienteId);

                }
                else{
                    throw new ValidacionException(mensajeError);
                }
            }
            else{
                throw new AutorizacionException();
            }  

    }
}
