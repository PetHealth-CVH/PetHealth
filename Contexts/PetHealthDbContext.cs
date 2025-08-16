using Microsoft.EntityFrameworkCore;
using Models;
using System.Reflection.Emit;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Sobrenome).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Cpf).IsRequired().HasMaxLength(11);
                entity.Property(e => e.EnderecoId).HasColumnName("id_endereco");

                // Configuração de relacionamento um-para-um com Endereco
                entity.HasOne(e => e.Endereco)
                      .WithOne(e => e.Usuario)
                      .HasForeignKey<Usuario>(e => e.EnderecoId);

                entity.HasIndex(e => e.Cpf)
                      .IsUnique();
            });

            modelBuilder.Entity<Credencial>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<Credencial>()
                .HasOne(c => c.Usuario)
                .WithOne(u => u.Credencial)
                .HasForeignKey<Credencial>(c => c.UsuarioId);

            modelBuilder.Entity<Produto>()
                .HasOne(p => p.Fornecedor)
                .WithMany(f => f.Produtos)
                .HasForeignKey(p => p.IdFornecedor);
        }
    }
}