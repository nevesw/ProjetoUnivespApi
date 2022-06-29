using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoUnivespApi.Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public int? CodProduto { get; set; }
        public string? Descricao { get; set; }
        public string? Quantidade { get; set; }
        public string? Plano { get; set; }
        public double? PrecoVenda { get; set; }
        public DateTime? DataVenda { get; set; }

    }
}
