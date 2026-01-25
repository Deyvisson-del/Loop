namespace Loop.Application.DTOs
{
    public class LoginDTO
    {
        public string? EmailDTO { get; set; }
        public string? SenhaDTO { get; set; }

        public LoginDTO(string emailDTO, string senhaDTO)
        {

        }
    }
}
