﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducaFacil.Domain.Entities
{
    public class Professor
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Sobrenome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string Sexo { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public string EstadoCivil { get; set; } = string.Empty;
        public string Ocupacao { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string NumeroContato { get; set; } = string.Empty;
        public string WhatsApp { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string CodigoPostal { get; set; } = string.Empty;
        public string NumeroEndereco { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
        public string EstadoEndereco { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Observacao { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime DataCriacao { get; set; }

        //Relacionamento
        [ForeignKey("EscolaId")]
        public Guid EscolaId { get; set; }
        public Escola Escola { get; set; }
        public List<Nota> Notas { get; set; }
    }

}
