using Microsoft.EntityFrameworkCore;
using ProjetoUnivespApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoUnivespApi.Persistence.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<AgendaAluno> AgendaAlunos { get; set; }
        public DbSet<AgendaProfessor> AgendaProfessores { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }       
        public DbSet<Login> Logins { get; set; }

    }
}
