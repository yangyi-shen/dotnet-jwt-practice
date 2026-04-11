using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetPractice.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotnetPractice.Repository
{
    public class ContentDBContext : DbContext
    {
        public ContentDBContext(DbContextOptions<ContentDBContext> options)
            : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
