using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducaFacil.Application.DTOs
{
    public class NotaDTO
    {
        public decimal Valor { get; set; }
        public string Disciplina { get; set; }
        public string Periodo { get; set; }
        public DateTime DataLancamento { get; set; }
        public Guid AlunoId { get; set; }
        public AlunoDTO Aluno { get; set; }
        public Guid ProfessorId { get; set; }
        public ProfessorDTO Professor { get; set; }
    }
}
