namespace ProjetoUnivespApi.Application.Dtos
{
    public class ProfessorInsertDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string Cnpj { get; set; }
        public DateTime? DataCriacao { get; set; }
        public string NumeroCelular { get; set; }
        public string UsuarioPlataforma { get; set; }
        public string Cpf { get; set; }
    }
}
