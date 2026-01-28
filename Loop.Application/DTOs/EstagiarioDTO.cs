namespace Loop.Application.DTOs
{
    public class EstagiarioDTO
    {
        public string Nome;
        public string Email;
        public string Senha;

        public EstagiarioDTO(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }
    }
}
