namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Interfaces;
public abstract class UsuarioCasoDeUso
{
    protected IUsuarioRepositorio Repositorio { get;private set;  } 
    public UsuarioCasoDeUso(IUsuarioRepositorio repositorio)
   {
       this.Repositorio = repositorio;
   }
}
