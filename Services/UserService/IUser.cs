using DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UserService
{
    public interface IUser
    {
        int addUtilisateur(Utilisateur po);
        Utilisateur FindById(int id);
        List<Utilisateur> allUtilisateurs();
        Utilisateur? updateUtilisateur(Utilisateur po, int idp);
        Utilisateur? deleteUtilisateur(int idp);
    }
}
