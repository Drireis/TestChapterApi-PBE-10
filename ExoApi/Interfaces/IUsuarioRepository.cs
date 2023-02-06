using ExoApi.Models;

namespace ExoApi.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> Listar();

        void Cadastrar(Usuario usuario);

        void Atualizar(int id, Usuario usuario);

        void Deletar(int id);

        Usuario BuscarPorId(int id);

        Usuario Login(string email, string senha);
    }
}
