using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HoneymoonShop.Models
{
    public class HoneyMoonShopContext : DbContext
    {
        public HoneyMoonShopContext(DbContextOptions<HoneyMoonShopContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
