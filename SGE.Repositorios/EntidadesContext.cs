using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion.Entidades;

namespace SGE.Repositorios;
public class EntidadesContext: DbContext
{
    #nullable disable
    public DbSet <Expediente> Expedientes{ get; set; }
    public DbSet <Tramite> Tramites { get; set; }   
    public DbSet <Usuario> Usuarios { get; set; }
    #nullable enable
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       optionsBuilder.UseSqlite("data source=Entidades.sqlite");
    }
}
