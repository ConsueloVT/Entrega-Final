namespace SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Entidades;

public static class TramiteValidador
{

    public static bool Validar(Tramite t, out string mensajeError){
        mensajeError = "";
        if (string.IsNullOrWhiteSpace(t.Contenido)){
            mensajeError = "El contenido no puede estar vacío.";
        }
        if (t.IdUsuarioUltimaModificacion <= 0){
            mensajeError += "El ID de Usuario debe ser un valor entero mayor que cero.\n";
        }
        return (mensajeError == "");
    }

}
