using EducaFacil.CrossCutting.Util.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducaFacil.Domain.Entities
{
    public class Turma
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public EnumTipoTurno Tipo { get; set; }

    }
}
