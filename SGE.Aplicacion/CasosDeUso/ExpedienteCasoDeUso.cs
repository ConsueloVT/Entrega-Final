namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Interfaces;


public abstract class ExpedienteCasoDeUso
{
    protected IExpedienteRepositorio Repositorio { get;private set;  } 
    public ExpedienteCasoDeUso(IExpedienteRepositorio repositorio)
   {
       this.Repositorio = repositorio;
   }
}
