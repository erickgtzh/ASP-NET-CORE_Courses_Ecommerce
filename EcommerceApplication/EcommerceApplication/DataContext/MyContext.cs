﻿using EcommerceApplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApplication.DataContext
{
    public class MyContext : IdentityDbContext<Customer, ApplicationRole, string>
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }
        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderLine> OrderLine { get; set; }
        public DbSet<Picture> Picture { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<ApplicationRole> ApplicationRole { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
    }
}