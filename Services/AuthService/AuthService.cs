using DAO;
using DAO.Models;
using Microsoft.EntityFrameworkCore;
using Services.UserService;
using System.Threading.Tasks;

namespace Services.AuthService
{
    public class AuthService : IAuth
    {
        private readonly ForumDbcontext _context;

        public AuthService(ForumDbcontext context)
        {
            _context = context;
        }

        public async Task<string> SignUp(Utilisateur user, string password)
        {
            if (await _context.utilisateurs.AnyAsync(u => u.Log == user.Log))
            {
                return "Username already taken.";
            }

            user.Pass = password;
            _context.utilisateurs.Add(user);
            await _context.SaveChangesAsync();

            return "User created successfully.";
        }

        public async Task<string?> SignIn(string username, string password)
        {
            var user = await _context.utilisateurs.FirstOrDefaultAsync(u => u.Log == username);
            if (user == null)
            {
                return "Invalid username.";
            }

            if (user.Pass != password)
            {
                return "Invalid password.";
            }

            return "Sign-in successful.";
        }
    }
}
