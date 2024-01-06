using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WPFVkontakte.Model.VkUser;
using WPFVkontakte.Model.VkGroup;
namespace WPFVkontakte.Model.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public ApplicationContext() 
        { 
            Database.EnsureCreated();
        }
        protected override void  OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VkApiWork;Trusted_Connection=True;");
        }
    }
}
