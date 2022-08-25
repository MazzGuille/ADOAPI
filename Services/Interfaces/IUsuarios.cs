using ADOAPI.Models;

namespace ADOAPI.Services.Interfaces
{
    public interface IUsuarios
    {

        Task<string> PostCrearUsuario(Usuario Ob);
        Task<List<Usuario>> GetAllUsuarios();
        Task<string> PutEditarUsuario(Usuario Ob);
        Task<string> DeleteUsuario(string mail);

    }
}
