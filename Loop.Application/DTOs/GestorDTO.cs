namespace Loop.Application.DTOs
{
    public class GestorDTO
    {
        public Guid id { get; set; }
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Senha { get; set; } = null!;
    }
}
