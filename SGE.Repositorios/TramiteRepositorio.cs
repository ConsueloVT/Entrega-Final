using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using Microsoft.EntityFrameworkCore;

namespace SGE.Repositorios;
public class TramiteRepositorio : ITramiteRepositorio
{
    
    public TramiteRepositorio(){
        using(var context=new EntidadesContext()){  
            context.Database.EnsureCreated();
            var connection = context.Database.GetDbConnection();
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "PRAGMA journal_mode=DELETE;";
                command.ExecuteNonQuery();
            }
        }
    }

    //Caso de uso trámite ALTA
    public void Agregar(Tramite t){
        using (var db = new EntidadesContext()){
            db.Tramites.Add(t);
            db.SaveChanges();
        }
    }

    //Caso de uso trámite BAJA
    public void Eliminar(Tramite tramite){
        using(var db = new EntidadesContext()){
            db.Tramites.Remove(tramite);
            db.SaveChanges();
        }
    }
    //Caso de uso trámite MODIFICACIÓN
    public void Modificar(Tramite tramite){
        using(var db = new EntidadesContext()){
            db.Tramites.Update(tramite);
            db.SaveChanges();
        }

    }

    //Metodo usado por el caso de uso expediente consulta por Id
    public List <Tramite> ListarPorIdExpediente(int id){
        using (var db=new EntidadesContext()){  
            var resultado = db.Tramites.Where(t => t.ExpedienteId == id).ToList();
            return resultado; 
        }
    }


    public List<Tramite> ListarPorEtiqueta(EtiquetaTramite etiqueta){
        using (var db = new EntidadesContext()){
            var resultado = db.Tramites.Where(t => t.Etiqueta == etiqueta).ToList();
            if (resultado!=null){
                return resultado;
            }
            return new List<Tramite>();
            
        }

    }

    public List<Tramite>? ListarTramites(){
        using (var db = new EntidadesContext()){
            return db.Tramites.ToList();
        }
    }

   public Tramite? ObtenerPorId(int id){
        using (var db = new EntidadesContext()){
            Tramite? t=db.Tramites.Where(t => t.Id == id).SingleOrDefault();;
            return t;
        }
   }
}
