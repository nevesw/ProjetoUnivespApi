using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoUnivespApi.Application.Dtos
{
    public class PedidoInsertDto
    {
        public int Id { get; set; }
        public int? produtoId { get; set; }
        public int? alunoId { get; set; }
        public int? pagamentoId { get; set; }
        public DateTime? DataPedido { get; set; }
        public string? Plano { get; set; }
        public int? Quantidade { get; set; }
    }
}
