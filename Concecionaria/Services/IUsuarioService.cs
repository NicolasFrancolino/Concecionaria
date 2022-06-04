using Concecionaria.Models.Users;

namespace Concecionaria.Services
{
    public interface IUsuarioService
    {
        AuthenticateResponse Registrar(AuthenticateRequest usuario, string password);
        AuthenticateResponse Login(string email, string password);
        string GetToken(AuthenticateResponse usuario);
    }
}
