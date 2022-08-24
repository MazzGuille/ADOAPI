using ADOAPI.Models;

namespace ADOAPI.Services.Interfaces
{
    public interface IDestinos
    {
        public void PutEditarDestino(Destino Ob);
        public void DeleteDestino(int id);
        //public Usuario GetUsuario(Usuario Ob);
        public List<Destino> GetAllDestino();
        public void PostCrearDestino(Destino Ob);
    }
}
