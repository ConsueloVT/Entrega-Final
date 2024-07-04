namespace SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;



public class ServicioActualizacionEstado (IEspecificacionCambioEstado _especificacion, ITramiteRepositorio _tramiteRepositorio, IExpedienteRepositorio _expedienteRepositorio)
{
    public void ActualizarEstado(int id)
    {

        Expediente? expediente = _expedienteRepositorio.ObtenerPorId(id);
        if(expediente!=null){
            expediente.Tramites = _tramiteRepositorio.ListarPorIdExpediente(id);
            if(expediente.Tramites!=null && expediente.Tramites.Count - 1>=0){
                Tramite ultimoTramite = expediente.Tramites[expediente.Tramites.Count - 1];
                expediente.Estado = _especificacion.ObtenerNuevoEstado(ultimoTramite.Etiqueta, expediente.Estado);
                _expedienteRepositorio.Modificar(expediente);
            }
        }

        
    }

}
