namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;


public class CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio _expedientes, ITramiteRepositorio _tramite):ExpedienteCasoDeUso(_expedientes)
{
    public Expediente Ejecutar(int id){
          Expediente? ex =Repositorio.ObtenerPorId(id);
          if(ex!= null){
             ex.Tramites = _tramite.ListarPorIdExpediente(id)?? new List<Tramite>();
             return ex;
          }
          else{
            throw new RepositorioException("El expediente con el id ingresado no existe ");
          }
    }


}
