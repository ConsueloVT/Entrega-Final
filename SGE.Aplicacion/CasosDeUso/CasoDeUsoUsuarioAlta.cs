namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Enumerativos;

public class CasoDeUsoUsuarioAlta(IUsuarioRepositorio _repositorio,IUsuarioValidador _validador):UsuarioCasoDeUso(_repositorio)
{

    public void Ejecutar(Usuario usuario)
    {
        String mensajeError;
        if(_validador.Validar(usuario,out mensajeError)){  
            int id=Repositorio.Agregar(usuario);

            // Verificar el ID del usuario y otorgar permisos según corresponda
            if (id==1)
            {
                // Otorgar todos los permisos
                foreach (Permiso permiso in Enum.GetValues(typeof(Permiso)))
                {
                    Repositorio.AgregarPermisoUsuario(usuario.Id, permiso);
                }
            }
            else
            {
                // Otorgar permiso básico
                Repositorio.AgregarPermisoUsuario(usuario.Id, Permiso.ListarUsuarios);
                Repositorio.AgregarPermisoUsuario(usuario.Id, Permiso.ListarExpedientes);
                Repositorio.AgregarPermisoUsuario(usuario.Id, Permiso.ListarTramites);
            }
        }
        else{
            throw new ValidacionException(mensajeError);
        }
    }
}

