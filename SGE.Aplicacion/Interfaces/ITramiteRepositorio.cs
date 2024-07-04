namespace SGE.Aplicacion.Interfaces;
using  SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;

public interface ITramiteRepositorio
{
    void Agregar(Tramite tramite);
    void Eliminar(Tramite tramite);
    void Modificar(Tramite tramite);
    List<Tramite> ListarPorIdExpediente(int id);
    List<Tramite> ListarPorEtiqueta(EtiquetaTramite etiqueta);
    //int ObtenerSiguienteId();
    Tramite? ObtenerPorId(int id);
    List<Tramite>? ListarTramites();

}
