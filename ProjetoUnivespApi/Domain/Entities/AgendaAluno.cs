using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoUnivespApi.Domain.Entities
{
    public class AgendaAluno
    {
        public int Id { get; set; }
        public DateTime? Data{ get; set; }
        public DateTime? Horario { get; set; }
        public string? DiaSemanaAulaAgendada { get; set; }
        public DateTime? DataPrevistaAula { get; set; }
        public DateTime? DataDisponivelAluno { get; set; }
    }
}
