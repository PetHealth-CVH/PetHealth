using Controllers;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Contexts
{
    public class PetHealthDbContext : DbContext
    {
        public PetHealthDbContext(DbContextOptions<PetHealthDbContext> configuracoes) : base (configuracoes)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Credencial> Credenciais { get; set; }
        public DbSet<Contato> Contato { get; set; }
    }
}