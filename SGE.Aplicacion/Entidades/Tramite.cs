namespace SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
public class Tramite
{
    public int Id { get; set;}
    public int ExpedienteId { get; set;}
    public EtiquetaTramite Etiqueta { get; set;}
    public String? Contenido { get; set;}
    public DateTime FechaCreacion { get; set;}
    public DateTime UltimaModificacion { get; set;}
    public int IdUsuarioUltimaModificacion { get; set;}

    public override string ToString(){
        return $"ID:{Id} |Expediente id al que pertenece:{ExpedienteId} | Etiqueta: {Etiqueta} | Contenido: {Contenido}\nFecha de Creacion: {FechaCreacion}| Fecha Ultima Modificacion: {UltimaModificacion} | Id Último Usuario:{IdUsuarioUltimaModificacion}";
    }

    

}
