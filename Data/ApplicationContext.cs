using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model.Entities;

namespace FirstProject.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Password=sa1234;Persist Security Info=True;User ID=sa;Initial Catalog=FirstProject;Data Source=EN00397\\SQLEXPRESS");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(s => s.Name).IsRequired();
            modelBuilder.Entity<User>().Property(s => s.Nickname).IsRequired();
            modelBuilder.Entity<User>().Property(s => s.Email).IsRequired();
            modelBuilder.Entity<User>().Property(s => s.Phone).IsRequired();
            modelBuilder.Entity<User>().Property(s => s.Password).IsRequired();

            modelBuilder.Entity<User>().HasIndex(s => s.Nickname).IsUnique();
            modelBuilder.Entity<User>().HasIndex(s => s.Email).IsUnique();


            modelBuilder.Entity<Client>().Property(s => s.Corporative_name).IsRequired();
            modelBuilder.Entity<Client>().Property(s => s.Fantasy_name).IsRequired();
            modelBuilder.Entity<Client>().Property(s => s.Cnpj).IsRequired();
            modelBuilder.Entity<Client>().Property(s => s.Address_public).IsRequired();
            modelBuilder.Entity<Client>().Property(s => s.Number_home).IsRequired();
            modelBuilder.Entity<Client>().Property(s => s.District).IsRequired();
            modelBuilder.Entity<Client>().Property(s => s.City).IsRequired();
            modelBuilder.Entity<Client>().Property(s => s.Cep).IsRequired();

            modelBuilder.Entity<Client>().HasIndex(s => s.Corporative_name).IsUnique();
            modelBuilder.Entity<Client>().HasIndex(s => s.Cnpj).IsUnique();

        }
    }
}