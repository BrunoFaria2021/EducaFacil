using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducaFacil.Application.DTOs
{
    public class MatriculaDTO
    {
        public Guid AlunoId { get; set; }
        public Guid SerieId { get; set; }
        public Guid ResponsavelId { get; set; }
        // Outras propriedades necessárias para a matrícula
    }
}
