namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Enumerativos;


public class CasoDeUsoExpedienteBaja(IServicioAutorizacion servicioAutorizacion,IExpedienteRepositorio expedienteRepositorio):ExpedienteCasoDeUso(expedienteRepositorio)
{
     public void Ejecutar(int idExpediente, int idUsuario)
    {    
           // Verificar permisos
           if(servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.ExpedienteBaja)){
               // Eliminar expediente en el repositorio
               var expediente = Repositorio.ObtenerPorId(idExpediente);
               if(expediente!= null){
                   Repositorio.Eliminar(expediente);
                  //Al dar de baja el expediente, también doy de baja todos los trámites asociados
                  //tramiteRepositorio.EliminarTramitesPorIdExpediente(idExpediente);
               }
               else{
                 throw new RepositorioException("El expediente que quiere dar de baja no existe ");
               }      
           }
           else{
               throw new AutorizacionException();
           }
    }
}
