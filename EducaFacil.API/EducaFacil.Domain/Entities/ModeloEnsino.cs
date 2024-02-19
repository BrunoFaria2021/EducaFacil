using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducaFacil.Domain.Entities
{
    public class ModeloEnsino
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public List<Serie> Series { get; set; } = new List<Serie>();
    }

}
