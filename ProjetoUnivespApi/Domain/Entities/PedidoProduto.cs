using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoUnivespApi.Domain.Entities
{
    public class PedidoProduto
    {
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }

    }
}
