namespace SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Enumerativos;


public interface IEspecificacionCambioEstado
{
  EstadoExpediente ObtenerNuevoEstado(EtiquetaTramite etiquetaTramite, EstadoExpediente estadoActual);
}
