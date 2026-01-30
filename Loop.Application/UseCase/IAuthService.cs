namespace Loop.Application.UseCase
{
    public interface IAuthService
    {
        bool ValidarUsuario(string email, string senha);
    }
}