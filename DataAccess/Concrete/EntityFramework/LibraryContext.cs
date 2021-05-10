using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concreate;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class LibraryContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Library;Trusted_Connection=true");
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Kind> Kinds { get; set; }
        public DbSet<Lend> Lends { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ReturnBook> ReturnBooks { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
