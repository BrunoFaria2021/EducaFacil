namespace EducaFacil.Domain.Entities
{
   
        public class Serie
        {
            public Guid Id { get; set; }
            public string Nome { get; set; } = string.Empty;
            public ModeloEnsino ModeloEnsino { get; set; }
            public List<Turma> Turmas { get; set; } = new List<Turma>();
            public List<Matricula> Matriculas { get; set; } = new List<Matricula>();
        }

    
}
