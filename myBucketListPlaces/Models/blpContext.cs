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
                Country = p.Country,
                Id = p.Id 
            }).ToArray();
        }

        internal PlacesIndexVM GetPlace(int id)
        {
            PlacesIndexVM placesIndexVM = new PlacesIndexVM();

            var place = Place.FirstOrDefault(p => p.Id == id);

            placesIndexVM.Name = place.Name;
            placesIndexVM.Country = place.Country;
            placesIndexVM.Description = place.Description;
            placesIndexVM.Lat = place.Lat;
            placesIndexVM.Long = place.Long;
            placesIndexVM.Id = place.Id;

            return placesIndexVM;
        }
    }
}
