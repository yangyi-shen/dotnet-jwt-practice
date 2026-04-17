using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetJwtPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetJwtPractice.Repository
{
    public class UserRepository
    {
        private readonly UserDBContext _dbo;

        public UserRepository(UserDBContext dbContext)
        {
            _dbo = dbContext;
        }

        public async Task AddUser(User data)
        {
            _dbo.Users.Add(data);
            await _dbo.SaveChangesAsync();
        }

        public async Task<bool> UserExistsByGUID(Guid GUID)
        {
            return await _dbo.Users.Where(u => u.GUID == GUID).AnyAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _dbo.Users.ToListAsync();
        }

        public async Task<User?> GetUserByGUID(Guid GUID)
        {
            return await _dbo.Users.Where(u => u.GUID == GUID).FirstOrDefaultAsync();
        }

        public async Task<User?> GetUserByUserName(string userName)
        {
            return await _dbo.Users.Where(u => u.UserName == userName).FirstOrDefaultAsync();
        }

        public async Task EditUser(User data)
        {
            _dbo.Users.Update(data);
            await _dbo.SaveChangesAsync();
        }
    }
}
