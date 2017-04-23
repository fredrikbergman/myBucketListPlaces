using myBucketListPlaces.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myBucketListPlaces.Models
{
    public class PlacesIndexVM
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public double? Lat { get; set; }
        public double? Long { get; set; }

        //public virtual ICollection<Image> Images { get; set; }
        //public virtual ICollection<Link> Links { get; set; }
        //public virtual User Users { get; set; }
    }
}
