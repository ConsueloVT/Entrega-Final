namespace SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Enumerativos;
public interface IServicioAutorizacion
{
    bool PoseeElPermiso(int IdUsuario, Permiso permiso);

}
