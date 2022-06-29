using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoUnivespApi.Domain.Entities
{
    public class Professor
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime? DataCriacao { get; set; }
        public string? Status { get; set; }
        public string? Cnpj { get; set; }
        public string? NumeroCelular { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? UsuarioPlataforma { get; set; }
        public string? SenhaPlataforma { get; set; }
        public string? Cpf { get; set; }
        public string? Rg { get; set; }
        public IEnumerable<Aluno>? Alunos { get; set; }
        public int? AgendaProfessorId { get; set; }
        public AgendaProfessor? AgendaProfessor { get; set; }
       
    }
}
