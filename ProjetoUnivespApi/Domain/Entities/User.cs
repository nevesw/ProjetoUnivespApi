using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoUnivespApi.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Usuario { get; set; }
        public string? Senha { get; set; }
        public string? Tipo { get; set; }
        public string? Email { get; set; }
    }
}
