using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoUnivespApi.Application.Dtos
{
    public class AlunoInsertDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime? DataCriacao { get; set; }
        public string StatusPagamento { get; set; }
        public DateTime? DataUltimoPagamento { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Nacionalidade { get; set; }
        public DateTime? DataVencimento { get; set; }
        public string NumeroCelular { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public int ProfessorId { get; set; }
        public int? AgendaAlunoId { get; set; }

        public string NomeProfessor { get; set; }
        public DateTime? DataAula { get; set; }
    }
}
