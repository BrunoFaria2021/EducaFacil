using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducaFacil.Application.ViewModel
{
    public class ResponsavelViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
        public string NumeroContato { get; set; }
        public string WhatsApp { get; set; }
        public string Estado { get; set; }
        public string Endereco { get; set; }
        public string CodigoPostal { get; set; }
        public string NumeroEndereco { get; set; }
        public string Complemento { get; set; }
        public string EstadoEndereco { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Observacao { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataVencimento { get; set; }
        public List<AlunoViewModel> Alunos { get; set; }
    }
}
