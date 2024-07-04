namespace SGE.Aplicacion.Servicios;
using  SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Enumerativos;


public class EspecificacionCambioEstado: IEspecificacionCambioEstado
{
     public EstadoExpediente ObtenerNuevoEstado(EtiquetaTramite etiquetaTramite, EstadoExpediente estadoActual)
    {
        switch (etiquetaTramite)
        {
            case EtiquetaTramite.Resolucion:
                return EstadoExpediente.ConResolucion;
            case EtiquetaTramite.PaseAEstudio:
                return EstadoExpediente.ParaResolver;
            case EtiquetaTramite.PaseAlArchivo:
                return EstadoExpediente.Finalizado;
            default:
                return estadoActual; // No se produce cambio de estado
        }
    }

}
