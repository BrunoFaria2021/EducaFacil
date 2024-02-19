using EducaFacil.Domain.Entities;
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
        public DbSet<ResponsavelContratante> Responsaveis { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Materia> Disciplinas { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Notificacao> Notificacoes { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }
        public DbSet<AlunoMatricula> AlunoMatriculas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AlunoMatricula>()
                .HasKey(am => new { am.AlunoId, am.MatriculaId });

            modelBuilder.Entity<AlunoMatricula>()
                .HasOne(am => am.Aluno)
                .WithMany(a => a.AlunoMatriculas)
                .HasForeignKey(am => am.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AlunoMatricula>()
                .HasOne(am => am.Matricula)
                .WithMany(m => m.AlunoMatriculas)
                .HasForeignKey(am => am.MatriculaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.Aluno)
                .WithMany(a => a.Matriculas)
                .HasForeignKey(m => m.AlunoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.Turma)
                .WithMany(t => t.Matriculas)
                .HasForeignKey(m => m.TurmaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.Responsavel)
                .WithMany(r => r.Matriculas)
                .HasForeignKey(m => m.ResponsavelId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.Serie)
                .WithMany(s => s.Matriculas)
                .HasForeignKey(m => m.SerieId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
