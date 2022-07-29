 using JogosNet.Models;
using Microsoft.EntityFrameworkCore;

namespace JogosNet.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Endereco>()
                .HasOne(endereco => endereco.Locadora)
                .WithOne(locadora => locadora.Endereco)
                .HasForeignKey<Locadora>(locadora => locadora.EnderecoId);
          
            builder.Entity<Locadora>()
                .HasOne(locadora=> locadora.Atendente)
                .WithMany(atendente=> atendente.Locadoras)
                .HasForeignKey(locadora => locadora.AtendenteId);

            builder.Entity<Sessao>()
                .HasOne(sessao => sessao.Jogo)
                .WithMany(jogo => jogo.Sessoes)
                .HasForeignKey(sessao => sessao.JogoId);
            builder.Entity<Sessao>()
                .HasOne(sessao => sessao.Locadora)
                .WithMany(locadora => locadora.Sessoes)
                .HasForeignKey(sessao => sessao.LocadoraId);
        }
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Locadora> Locadoras { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Atendente> Atendentes { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }

    }
}