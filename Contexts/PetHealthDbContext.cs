using Microsoft.EntityFrameworkCore;
using Models;
using Controllers;

namespace Contexts
{
    public class PetHealthDbContext : DbContext
    {
        public PetHealthDbContext(DbContextOptions<PetHealthDbContext> configuracoes) : base(configuracoes)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Credencial> Credenciais { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Pedidos> Pedidos {get; set; }
        public DbSet<Fornecedor> Fornecedor {get; set; }

        protected override void OnModelCreating(ModelBuilder modelador)
        {
            // Configuração da relação entre Usuario e Endereco
            modelador.Entity<Usuario>()
                .HasOne(usuario => usuario.Endereco)
                .WithMany()
                .HasForeignKey(usuario => usuario.EnderecoId)
                .IsRequired(false);

            // Configuração da relação entre Usuario e Contato
            modelador.Entity<Usuario>()
                .HasOne(usuario => usuario.Contato)
                .WithOne()

                .HasForeignKey<Usuario>(usuario => usuario.ContatoId)
                .IsRequired();

            // Configuração da relação entre Contato e Email
            modelador.Entity<Contato>()
                .HasOne(contato => contato.Email)
                .WithOne()
                .HasForeignKey<Contato>(contato => contato.Email)

                .IsRequired();

            // Configuração da relação entre Credencial e Usuario
            modelador.Entity<Credencial>()
                .HasOne(credencial => credencial.Usuario)
                .WithOne()
                .HasForeignKey<Credencial>(Credencial => Credencial.UsuarioId)
                .IsRequired();

            // Configuração da relação entre Pedidos e Usuario
            modelador.Entity<Pedidos>()
                .HasOne(pedidos => pedidos.Usuario)
                .WithOne()
                .HasForeignKey<Pedidos>(Pedidos => Pedidos.UsuarioId)
                .IsRequired();

            // Configuração da relação entre Pedidos e Produtos
            modelador.Entity<Pedidos>()
                .HasOne(Pedidos => Pedidos.Produtos)
                .WithMany()
                .HasForeignKey(Pedidos => Pedidos.ProdutosId)
                .IsRequired();

            // Configuração da relação entre Produtos e Fornecedor
            modelador.Entity<Produtos>()
                .HasOne(Produtos => Produtos.Fornecedores)
                .WithMany()
                .HasForeignKey(Produtos => Produtos.FornecedorId)
                .IsRequired();

            base.OnModelCreating(modelador);
        }

        internal async Task AtualizarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        internal async Task<bool> AtualizarPorId(Usuario usuarioQueEstaBuscando)
        {
            throw new NotImplementedException();
        }

        internal async Task ObterUsuarioPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}