namespace SGE.Aplicacion.Validadores;
using SGE.Aplicacion.Entidades;

public static class ExpedienteValidador
{
    public static bool Validar(Expediente e, out string mensajeError){
        mensajeError = "";
        if (string.IsNullOrWhiteSpace(e.Caratula)){
           mensajeError="La caratula no puede estar vacia."; 
        }
        if (e.IdUsuarioUltimaModificacion <= 0){
            mensajeError += "El Id Usuario debe ser un valor entero mayor que cero.\n";
        }
        return (mensajeError == "");
    }
}
