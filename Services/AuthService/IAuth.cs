using DAO.Models;
using Services.UserService;
using System.Threading.Tasks;

namespace Services.AuthService
{
    public interface IAuth
    {
        Task<string> SignUp(Utilisateur user, string password);
        Task<string?> SignIn(string username, string password);
    }
}
