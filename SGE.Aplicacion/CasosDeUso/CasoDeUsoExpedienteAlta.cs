namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Validadores;
using SGE.Aplicacion.Enumerativos;

public class CasoDeUsoExpedienteAlta (IExpedienteRepositorio _expedienteRepo, IServicioAutorizacion _servicioAutorizacion ):ExpedienteCasoDeUso(_expedienteRepo)
{       


    public void Ejecutar(Expediente expediente, int IdUsuario){

        if(_servicioAutorizacion.PoseeElPermiso(IdUsuario, Permiso.ExpedienteAlta)){
            string mensajeError;
            expediente.IdUsuarioUltimaModificacion=IdUsuario;
            if(ExpedienteValidador.Validar(expediente, out mensajeError)){
                expediente.FechaCreacion = DateTime.Now;
                expediente.UltimaModificacion = DateTime.Now;
                expediente.Estado = EstadoExpediente.RecienIniciado;
                //expediente.Id = _expedienteRepo.ObtenerSiguienteId();
                // Guardar expediente en el repositorio
                Repositorio.Agregar(expediente);
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

