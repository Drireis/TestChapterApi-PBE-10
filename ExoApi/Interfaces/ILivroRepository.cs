using ExoApi.Models;

namespace ExoApi.Interfaces
{
    public interface ILivroRepository
    {
        List<Livro> Ler();

        void Cadastrar(Livro livro);

        void Atualizar(int id, Livro livro);

        void Deletar(int id);

        Livro BuscarPorId(int id);

        Livro BuscarPorTitulo(string titulo);
    }
}
