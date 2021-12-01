using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WeaponShop.Models
{
    public class WeaponDBContext : DbContext
    {
        public DbSet<WeaponCategory> WeaponCategories { get; set; }
        public DbSet<Weapons> Weapons { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
    }
}