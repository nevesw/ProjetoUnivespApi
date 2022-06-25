using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoUnivespApi.Application.Dtos
{
    public class PedidoInsertDto
    {
        public string produtoId { get; set; }
        public string alunoId { get; set; }
        public string pagamentoId { get; set; }
        public DateTime? DataPedido { get; set; }
        public string Plano { get; set; }
        public string Meses { get; set; }
    }
}
