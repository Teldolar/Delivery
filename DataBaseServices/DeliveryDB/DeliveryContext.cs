using DeliveryDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryDB
{
    public class DeliveryContext : DbContext
    {
        public DeliveryContext(DbContextOptions<DeliveryContext> options) : base(options)
        {

        }

        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<MenuItem> MenuItems { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<RestaurantTag> RestaurantTags { get; set; }
    }
}
