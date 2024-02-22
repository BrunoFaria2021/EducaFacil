﻿using System.ComponentModel.DataAnnotations.Schema;

namespace EducaFacil.Domain.Entities
{
    public class Nota
    {
        public Guid Id { get; set; }
        public decimal Valor { get; set; }
        public string Disciplina { get; set; }
        public string Periodo { get; set; }
        public DateTime DataLancamento { get; set; }

        // Relacionamento
        public Guid AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public Guid ProfessorId { get; set; }
        public Professor Professor { get; set; }
    }
}
