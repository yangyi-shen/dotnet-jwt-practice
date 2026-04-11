using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetPractice.Repository
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
