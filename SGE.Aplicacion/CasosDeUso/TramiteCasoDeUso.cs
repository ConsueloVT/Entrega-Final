namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Interfaces;

public abstract class TramiteCasoDeUso
{
    protected ITramiteRepositorio Repositorio { get;private set;  } 
    public TramiteCasoDeUso(ITramiteRepositorio repositorio)
   {
       this.Repositorio = repositorio;
   }
}
