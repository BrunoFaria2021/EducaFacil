using EducaFacil.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EducaFacil.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Responsavel> Responsaveis { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Serie> Cursos { get; set; }
       public DbSet<Disciplina> Disciplinas { get; set; }
       public DbSet<DisciplinaSerie> DisciplinaSeries { get; set; }
        //public DbSet<Turma> Turmas { get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<Escola> Escola { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Notificacao> Notificacoes { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DisciplinaSerie>()
              .HasKey(ds => new { ds.DisciplinaId, ds.SerieId });

            modelBuilder.Entity<Nota>()
              .Property(n => n.Valor)
              .HasColumnType("decimal(18,   2)");

            modelBuilder.Entity<Aluno>()
        .HasOne(a => a.Responsavel)
        .WithMany(r => r.Alunos)
        .HasForeignKey(a => a.ResponsavelId);

            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.Aluno)
                .WithOne(a => a.Matricula)
                .HasForeignKey<Matricula>(m => m.AlunoId);

            modelBuilder.Entity<Disciplina>()
                .HasMany(d => d.DisciplinasSeries)
                .WithOne(ds => ds.Disciplina)
                .HasForeignKey(ds => ds.DisciplinaId);

            modelBuilder.Entity<Serie>()
                .HasMany(s => s.DisciplinasSeries)
                .WithOne(ds => ds.Serie)
                .HasForeignKey(ds => ds.SerieId);

            modelBuilder.Entity<Professor>()
                .HasOne(p => p.Escola)
                .WithMany(e => e.Professores)
                .HasForeignKey(p => p.EscolaId);

            modelBuilder.Entity<Nota>()
                .HasOne(n => n.Aluno)
                .WithMany(a => a.Notas)
                .HasForeignKey(n => n.AlunoId);

            modelBuilder.Entity<Nota>()
                .HasOne(n => n.Professor)
                .WithMany(p => p.Notas)
                .HasForeignKey(n => n.ProfessorId);

            modelBuilder.Entity<Notificacao>()
                .HasOne(n => n.Responsavel)
                .WithMany(r => r.Notificacoes)
                .HasForeignKey(n => n.ResponsavelId);
        }

    }
}
