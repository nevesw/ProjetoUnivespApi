using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoUnivespApi.Application.Dtos
{
    public class ProdutoInsertDto
    {
        public string Descricao { get; set; }
        public string Quantidade { get; set; }
        public double PrecoVenda { get; set; }
        public string Plano { get; set; }
    }
}
