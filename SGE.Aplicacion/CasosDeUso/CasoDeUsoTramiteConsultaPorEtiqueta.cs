namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
public class CasoDeUsoTramiteConsultaPorEtiqueta (ITramiteRepositorio tramite):TramiteCasoDeUso(tramite)
{
   

    public List<Tramite> Ejecutar (EtiquetaTramite etiqueta)
    {
        List<Tramite> tramites = Repositorio.ListarPorEtiqueta(etiqueta);
        if (tramites.Count()==0){
            throw new RepositorioException("No hay trámites con la etiqueta ingresada");
        }
        return tramites;
    }



}
