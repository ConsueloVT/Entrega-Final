namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
public class CasoDeUsoTramiteConsultaPorExpediente(ITramiteRepositorio tramite):TramiteCasoDeUso(tramite)
{
    public List<Tramite>? Ejecutar(int id)
    {
        /*lista todos los tramites --> */
        return Repositorio.ListarPorIdExpediente(id);
    }

}
