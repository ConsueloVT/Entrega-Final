using Microsoft.EntityFrameworkCore;

namespace SGE.Repositorios;
public class EntidadesSqlite
{
    public static void Inicializar(){

        using var context = new EntidadesContext();
        if(context.Database.EnsureCreated()){
           // Console.WriteLine("Se creó base de datos");
        }
    }
    
}
