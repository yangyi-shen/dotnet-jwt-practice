using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetJwtPractice.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotnetJwtPractice.Repository
{
    public class PostRepository
    {
        private readonly ContentDBContext _dbo;

        public PostRepository(ContentDBContext dbContext)
        {
            _dbo = dbContext;
        }

        public async Task AddPost(Post data)
        {
            _dbo.Posts.Add(data);
            await _dbo.SaveChangesAsync();
        }

        public async Task<List<Post>> GetFilteredPosts(Guid? userGUID, Guid? categoryGUID)
        {
            IQueryable<Post> query = _dbo.Posts;

            if (userGUID != null)
                query = query.Where(p => p.UserGUID == userGUID);

            if (categoryGUID != null)
                query = query.Where(p => p.CategoryGUID == categoryGUID);

            return await query.ToListAsync();
        }
    }
}
