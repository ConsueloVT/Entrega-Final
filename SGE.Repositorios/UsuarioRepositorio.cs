using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;

using Microsoft.EntityFrameworkCore;

namespace SGE.Repositorios;

public class UsuarioRepositorio: IUsuarioRepositorio
{

    public UsuarioRepositorio(){
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

    //Verificar que el usuario no exista
    public bool BuscarPorCorreoElectronico(String correo){
        using(var db=new EntidadesContext()){
            var usuario = db.Usuarios.Where(u=>u.CorreoElectronico.Equals(correo)).SingleOrDefault();
            if(usuario!=null){
                return true;
            }
            return false;
        }
    }

    //Agregar un usuario
    public int Agregar(Usuario u){
        using(var db = new EntidadesContext()){
            db.Usuarios.Add(u);
            db.SaveChanges();
            return u.Id;
        }
    }

    public void AgregarPermisoUsuario(int id, Permiso permiso ){
        using (var db = new EntidadesContext()){
            var usuario = db.Set<Usuario>().Find(id);
            if (usuario != null)
            {
                // Asignar el permiso al usuario
                usuario.ListaPermisos.Add(permiso);

                // Guardar los cambios en la base de datos
                db.SaveChanges();
            }
        }
    }


    //Dar de baja un usuario
    public void Eliminar(Usuario u){
        using(var db = new EntidadesContext()){
            db.Usuarios.Remove(u);
            db.SaveChanges();
        }
    }

    public List<Usuario> ListarTodos(){
        using(var db = new EntidadesContext()){
            return db.Usuarios.ToList();
        }
    }

    public void Modificar(Usuario u){
        using(var db = new EntidadesContext()){
            db.Usuarios.Update(u);
            db.SaveChanges();
        }
    }

    public Usuario? ObtenerPorId(int idUsuario){
        using (var db=new EntidadesContext()){
            Usuario? usuario = db.Usuarios.Where(x => x.Id == idUsuario).SingleOrDefault();
            return usuario;
        }
    }

    //Para iniciar Sesion
    public Usuario? IniciarSesion(String correo){
        using(var db= new EntidadesContext()){
            Usuario? usuario = db.Usuarios.Where(x=>x.CorreoElectronico == correo).SingleOrDefault();
            return usuario;
        }
    }

    public List<Permiso>? GetPermisos(int id){
        using(var db=new EntidadesContext()){
            var lista=db.Usuarios.Where(u=>u.Id == id).SingleOrDefault()?.ListaPermisos;
            return lista;
        }
    }

}