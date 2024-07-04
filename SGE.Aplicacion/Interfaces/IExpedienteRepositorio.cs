namespace SGE.Aplicacion.Interfaces;
using  SGE.Aplicacion.Entidades;

public interface IExpedienteRepositorio
{
    void Agregar(Expediente expediente);
    void Eliminar(Expediente expediente);
    void Modificar(Expediente expediente);
    Expediente? ObtenerPorId(int id);
    List <Expediente>? ObtenerTodos();
    public List<Expediente>? ListarExpedientesConSusTramites();
    //int ObtenerSiguienteId();

}
