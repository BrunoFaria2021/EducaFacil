using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducaFacil.Application.ViewModel
{
    public class AlunoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public string Genero { get; set; }
        public string Observacao { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid ResponsavelId { get; set; }
       // public ResponsavelViewModel Responsavel { get; set; }
        //public List<MatriculaViewModel> Matriculas { get; set; }
        //public List<NotificacaoViewModel> Notificacoes { get; set; }
        //public List<BilhetePresencaViewModel> BilhetesPresencas { get; set; }
    }
}
