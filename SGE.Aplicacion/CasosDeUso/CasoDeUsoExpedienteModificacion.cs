namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Validadores;
using SGE.Aplicacion.Enumerativos;

public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio expedienteRepositorio,IServicioAutorizacion _servicioAutorizacion):ExpedienteCasoDeUso(expedienteRepositorio)
{
    public void Ejecutar(Expediente expediente,int idUsuario)
    {
            if(_servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.ExpedienteModificacion)){

                string mensajeError;
                expediente.IdUsuarioUltimaModificacion=idUsuario;

                if(ExpedienteValidador.Validar(expediente, out mensajeError)){

                   
                    Expediente? aux = Repositorio.ObtenerPorId(expediente.Id);

                    //Verifico si el expediente con el id pedido existe
                    if(aux != null){  
                        //Asigno los campos que no cambiaron
                        expediente.FechaCreacion=aux.FechaCreacion;
                        expediente.Estado=aux.Estado;
                        // Asignar fecha de modificación
                        expediente.UltimaModificacion = DateTime.Now;
                        //Persistir expediente modificado
                        Repositorio.Modificar(expediente);
                    }
                    else{
                        throw new RepositorioException("El expediente con el id ingresado no existe");
                    }
                }
                else{
                    throw new ValidacionException(mensajeError);
                }
            }   
            else{
                throw new AutorizacionException();
            }
    }
}
