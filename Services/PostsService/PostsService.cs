using DAO;
using DAO.Models;
using Microsoft.EntityFrameworkCore;
using Services.PostsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.postsService
{
    public class postsService : IPost
    {
      
            ForumDbcontext _context;

            public postsService(ForumDbcontext context)
            {
                _context = context;
            }

            public int addPost(Post ct)
            {
                _context.posts.Add(ct);
                int nb = _context.SaveChanges();
                return nb;
            }

            public List<Post> allposts()
            {
                List<Post> posts = _context.posts.Include(p => p.Utilisateur).ToList();
                return posts;
            }

            public Post? deletePost(int idc)
            {
                Post? postModel = _context.posts.FirstOrDefault(x => x.Id == idc);
                if (postModel == null)
                {
                    return null;
                }
                _context.posts.Remove(postModel);

                _context.SaveChanges();

                return postModel;
            }

            public Post FindById(int id)
            {
                Post c = _context.posts.Include(p => p.Utilisateur).FirstOrDefault(c => c.Id == id);
                return c;

            }

            public Post? updatePost(Post ct, int idc)
            {
                Post? postModel = _context.posts.Include(p => p.Utilisateur).FirstOrDefault(x => x.Id == idc);
                if (postModel == null)
                {
                    return null;
                }
                postModel.Contenu = ct.Contenu;

                _context.SaveChanges();
                return postModel;
            }
        }

    }

