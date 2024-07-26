using Microsoft.EntityFrameworkCore;
using Models;

namespace Contexts
{
    public class PetHealthDbContext : DbContext
    {
        public PetHealthDbContext(DbContextOptions<PetHealthDbContext> configuracoes) : base(configuracoes)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Credencial> Credenciais { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelador)
        {
            modelador.Entity<Usuario>()
                .HasOne(usuario => usuario.Endereco)
                .WithOne(endereco => endereco.Usuario)
                .HasForeignKey<Usuario>(usuario => usuario.EnderecoId);

            modelador.Entity<Credencial>()
                .HasIndex(credencial => credencial.Email)
                .IsUnique();
            
            modelador.Entity<Credencial>()
                .HasOne(credencial => credencial.Usuario)
                .WithOne(usuario => usuario.Credencial)
                .HasForeignKey<Credencial>(Credencial => Credencial.UsuarioId);
            
            modelador.Entity<Fornecedor>();
                
        }
    }
}