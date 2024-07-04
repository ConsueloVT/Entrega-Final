namespace SGE.Aplicacion.Validadores;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

public class UsuarioValidador (IUsuarioRepositorio _usuarioRepo):IUsuarioValidador
{
    public bool Validar (Usuario u, out String mensajeError ){
        mensajeError = "";
        if(_usuarioRepo.BuscarPorCorreoElectronico(u.CorreoElectronico)){ 
            mensajeError="Ya existe un usuario con el correo electronico ingresado";
        }
        if (string.IsNullOrWhiteSpace(u.Nombre)){
            mensajeError += "El contenido no puede estar vacío.";
        }
        if (string.IsNullOrWhiteSpace(u.Apellido)){
            mensajeError += "El contenido no puede estar vacío.";
        }
        if (string.IsNullOrWhiteSpace(u.CorreoElectronico)){
            mensajeError += "El contenido no puede estar vacío.";
        }
        if(!u.CorreoElectronico.Contains("@"))
        {
            mensajeError += "El correo electrónico debe contener un '@'.";

        }
        if (string.IsNullOrWhiteSpace(u.Apellido)){
            mensajeError +="El contenido no puede estar vacío.";
        }
        return (mensajeError == "");
    }
}
