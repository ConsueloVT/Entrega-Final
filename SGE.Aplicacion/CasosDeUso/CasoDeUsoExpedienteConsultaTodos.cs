namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;

public class CasoDeUsoExpedienteConsultaTodos(IExpedienteRepositorio expedienteRepositorio):ExpedienteCasoDeUso(expedienteRepositorio)
{
    public List<Expediente>? Ejecutar()
    {
        /*lista todos los expedientes (sin sus trámites) --> */
        return Repositorio.ObtenerTodos();
    }

}
