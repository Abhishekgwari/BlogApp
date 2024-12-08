using BlogApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data
{
    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext(DbContextOptions options) : base(options)
        {
        }



        public DbSet<Blog> Blogs { get; set; }             // blog is model class
                                                               // blogs is table name
    }
}
