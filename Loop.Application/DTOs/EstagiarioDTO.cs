namespace Loop.Application.DTOs
{
    public class UserDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public UserDTO()
        {
            Nome = string.Empty;
            Email = string.Empty;
            Senha = string.Empty;
        }
    }
}
