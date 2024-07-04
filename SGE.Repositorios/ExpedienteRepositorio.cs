using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;

namespace SGE.Repositorios;
public class ExpedienteRepositorio : IExpedienteRepositorio
{

  
    public ExpedienteRepositorio(){
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
    //Caso de uso expediente ALTA
    public void Agregar(Expediente e){
        
        using(var db=new EntidadesContext()){  
            db.Add(e);
            db.SaveChanges();
        }
    }

    //Caso de uso expediente BAJA
    public void Eliminar(Expediente e){
        using(var db=new EntidadesContext()){  
            var expediente = db.Expedientes.Where(t => t.Id == e.Id).SingleOrDefault();
            if(expediente != null){
                 db.Remove(expediente);
                 db.SaveChanges();
        }
        }
    }

    //Caso de uso Consulta por Id
    public Expediente? ObtenerPorId(int id){
        using(var db=new EntidadesContext()){  
            var expediente = db.Expedientes.Where(t => t.Id == id).SingleOrDefault();
            return expediente;
        }
    }
    public List<Expediente>? ListarExpedientesConSusTramites()
    {
        using(var db = new EntidadesContext()){
            return db.Expedientes.Include(t => t.Tramites).ToList();
        }
    } 

    
    //Caso de uso consulta TODOS
    public List<Expediente>? ObtenerTodos(){
        using (var db=new EntidadesContext()){
            List<Expediente> resultado = db.Expedientes.ToList();
            return resultado;  
        }
    }


    //Caso de uso expediente MODIFICACION
    public void Modificar(Expediente e){
        using(var db=new EntidadesContext()){  
            db.Expedientes.Update(e);
            db.SaveChanges();
        }
    }
}
