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

        protected override void OnModelCreating(ModelBuilder modelador)
        {
            // Configuração da relação entre Usuario e Endereco
            modelador.Entity<Usuario>()
                .HasOne(usuario => usuario.Endereco)
                .WithMany()
                .HasForeignKey(usuario => usuario.id_enderecos)
                .IsRequired(false);

            // Configuração da relação entre Usuario e Credencial
            modelador.Entity<Usuario>()
                .HasOne(usuario => usuario.Credencial)
                .WithMany()
                .HasForeignKey(usuario => usuario.id_credencial);

            modelador.Entity<Usuario>()
                .HasOne(usuario => usuario.id_usuario)
                .WithOne()
                .HasForeignKey(usuario => usuario.id_contatos)
                .IsRequired();
                
            base.OnModelCreating(modelador);
        }
    }
}