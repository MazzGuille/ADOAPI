using ADOAPI.Models;

namespace ADOAPI.Services.Interfaces
{
    public interface IUsuarios
    {
        public void PutEditarUsuario(Usuario Ob);
        public void DeleteUsuario(string mail);
        //public Usuario GetUsuario(Usuario Ob);
        public List<Usuario> GetAllUsuarios();
        public void PostCrearUsuario(Usuario Ob);

    }
}
