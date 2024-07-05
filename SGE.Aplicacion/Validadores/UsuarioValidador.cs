namespace SGE.Aplicacion.Validadores;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

public class UsuarioValidador (IUsuarioRepositorio _usuarioRepo):IUsuarioValidador
{
    public bool Validar (Usuario u, out String mensajeError ){
        mensajeError = "";
        if(_usuarioRepo.BuscarPorCorreoElectronico(u.CorreoElectronico)){ 
            mensajeError="Ya existe un usuario con el correo electronico ingresado.\n";
        }
        if (string.IsNullOrWhiteSpace(u.Nombre)){
            mensajeError += "La casilla de Nombre no puede estar vacía.\n";
        }
        if (string.IsNullOrWhiteSpace(u.Apellido)){
            mensajeError += "La casilla de Apellido no puede estar vacía.\n";
        }
        if (string.IsNullOrWhiteSpace(u.CorreoElectronico)){
            mensajeError += "El correo electrónico no puede estar vacío.\n";
        }
        if(!u.CorreoElectronico.Contains("@"))
        {
            mensajeError += "El correo electrónico debe contener un '@'.\n";

        }
        return (mensajeError == "");
    }
}
