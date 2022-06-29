namespace ProjetoUnivespApi.Domain.Entities
{
    public class AgendaProfessor
    {
        public int Id { get; set; }
        public DateTime? DataAgendada { get; set; }
        public DateTime? HorarioAgendado { get; set; }
        public string? DiaSemanaAulaAgendada { get; set; }
        public DateTime? DataPrevistaAula { get; set; }
        public DateTime? DataDisponivelProfessor { get; set; }
    }
}
