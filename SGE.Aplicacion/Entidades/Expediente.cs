namespace SGE.Aplicacion.Entidades;
public class Expediente
{
    public int Id {get;set;}
    public String? Caratula {get;set;}
    public DateTime FechaCreacion {get;set;}
    public DateTime UltimaModificacion {get;set;}
    public int IdUsuarioUltimaModificacion {get;set;}
    public EstadoExpediente Estado {get; set;}
    public List<Tramite> Tramites{get; set;} = new List<Tramite>();    

    public override string ToString()
    {
        return $"ID:{Id} | Caratula: {Caratula} | Fecha de Creacion: {FechaCreacion}\nFecha Ultima Modificacion: {UltimaModificacion} | Id Último Usuario:{ IdUsuarioUltimaModificacion} | Estado: {Estado}";
    }

}
