namespace SGE.Aplicacion.Servicios;
using SGE.Aplicacion.Interfaces;


public class ServicioSesion(IUsuarioRepositorio _repo,IHashService _hash):IServicioSesion
{

    public int Id {get;set;}

    public bool Loggin(String email, String contraseña){
        var usuario=_repo.IniciarSesion(email);
        if(usuario != null ){  
            if(_hash.VerifyHash(contraseña,usuario.HashContraseña,usuario.SalContraseña)){
                Id=usuario.Id;
                return true;
            }
            else{
                return false;
            }
        }
        return false;
    }

    public void Close(){
        Id=0;
    }
}
