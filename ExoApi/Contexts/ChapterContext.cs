//Instalar o Microsoft.EntityFrameworkCore pelo gerenciador de pacotes NuGet
using ExoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExoApi.Contexts
{
    public class ChapterContext : DbContext
    {
        // dbcontext é a ponte entre o modelo de classe e o banco de dados
        public ChapterContext()
        {
        }
        public ChapterContext(DbContextOptions<ChapterContext> options) : base(options)
        {
        }
        // vamos utilizar esse método para configurar o banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // cada provedor tem sua sintaxe para especificação
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-PRU7PLC\\SQLEXPRESS; initial catalog = ChapterApi;Integrated Security = true; encrypt=false"); //erro 500 de conexão para correção foi inserido (encrypt=false)
            }                                                                                                 //;Id Users sa; pwd=***** (Acessar banco usando senha) Integrated Security = true"
        }
        // dbset representa as entidades que serão utilizadas nas operações de leitura, criação, atualização e deleção
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        
    }
}
