using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoUnivespApi.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataPedido { get; set; }
        public Pagamento Pagamento { get; set; }
        public int Quantidade { get; set; }
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public List<PedidoProduto> PedidoProdutos { get; set; }

    }
}
