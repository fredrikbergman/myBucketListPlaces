using Microsoft.EntityFrameworkCore;
using myBucketListPlaces.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myBucketListPlaces.Models
{
    public partial class blpContext : DbContext
    {
        public blpContext(DbContextOptions<blpContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Place> Place { get; set; }

        public PlacesIndexVM[] GetAllPlaces()
        {
            return Place.Select(p => new PlacesIndexVM
            {
                Name = p.Name,
                Country = p.Country
            }).ToArray();
        }
    }
}
