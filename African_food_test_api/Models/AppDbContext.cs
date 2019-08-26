using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFRICAN_FOOD_API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Pie> Pies { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pie>(ConfigurePie);
            modelBuilder.Entity<ShoppingCart>(ConfigureShoppingCart);
            modelBuilder.Entity<ShoppingCartItem>(ConfigureShoppingCartItem);
            modelBuilder.Entity<ContactInfo>(ConfigureContactInfo);
            modelBuilder.Entity<Address>(ConfigureAddress);
            modelBuilder.Entity<Order>(ConfigureOrder);
            modelBuilder.Entity<User>(ConfigureUser);
        }

        private void ConfigureOrder(EntityTypeBuilder<Order> obj)
        {

        }
        private void ConfigureUser(EntityTypeBuilder<User> obj)
        {

        }

        private void ConfigureAddress(EntityTypeBuilder<Address> obj)
        {

        }

        private void ConfigureContactInfo(EntityTypeBuilder<ContactInfo> obj)
        {

        }

        private void ConfigureShoppingCartItem(EntityTypeBuilder<ShoppingCartItem> obj)
        {

        }

        private void ConfigureShoppingCart(EntityTypeBuilder<ShoppingCart> obj)
        {

        }

        private void ConfigurePie(EntityTypeBuilder<Pie> entityTypeBuilder)
        {

        }
    }
}
