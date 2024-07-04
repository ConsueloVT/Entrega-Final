namespace SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;

public interface IUsuarioValidador
{
    public bool Validar(Usuario u, out String mensajeError);
}
