using DAO;
using DAO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UserService
{
    public class UserService : IUser
    {
       
            ForumDbcontext _context;

            public UserService(ForumDbcontext context)
            {
                _context = context;
            }

            public int addUtilisateur(Utilisateur po)
            {
                _context.utilisateurs.Add(po);
                int nb = _context.SaveChanges();
                return nb;
            }

            public List<Utilisateur> allUtilisateurs()
            {
                List<Utilisateur> Utilisateurs = _context.utilisateurs.Include(p => p.Posts).ToList();
                return Utilisateurs;
            }

            public Utilisateur? deleteUtilisateur(int idp)
            {
                Utilisateur? UtilisateurModel = _context.utilisateurs.FirstOrDefault(x => x.Id == idp);
                if (UtilisateurModel == null)
                {
                    return null;
                }
                _context.utilisateurs.Remove(UtilisateurModel);

                _context.SaveChanges();

                return UtilisateurModel;
            }

            public Utilisateur FindById(int id)
            {
                Utilisateur p = _context.utilisateurs.Include(p => p.Posts).FirstOrDefault(p => p.Id == id);
                return p;
            }

            public Utilisateur? updateUtilisateur(Utilisateur po, int idp)
            {
                Utilisateur? UtilisateurModel = _context.utilisateurs.Include(p => p.Posts).FirstOrDefault(x => x.Id == idp);
                if (UtilisateurModel == null)
                {
                    return null;
                }
                UtilisateurModel.Log = po.Log;
                UtilisateurModel.Pass = po.Pass;
                UtilisateurModel.Posts = po.Posts;

                _context.SaveChanges();
                return UtilisateurModel;
            }
        }

    }

