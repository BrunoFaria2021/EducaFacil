namespace EducaFacil.Domain.Entities
{
    public class Matricula
    {
        public Guid Id { get; set; }

        public Guid AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        public Guid EscolaId { get; set; }
        public Escola Escola { get; set; }


    }
}


//[ForeignKey("ResponsavelId")]
//public Guid ResponsavelId { get; set; }
//public ResponsavelContratante Responsavel { get; set; }

//[ForeignKey("TurmaId")]
//public Guid TurmaId { get; set; }
//public Turma Turma { get; set; }