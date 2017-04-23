using System;
using System.Collections.Generic;

namespace myBucketListPlaces.Models.Entities
{
    public partial class Place
    {
        public Place()
        {
            Image = new HashSet<Image>();
            Link = new HashSet<Link>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public double? Lat { get; set; }
        public double? Long { get; set; }

        public virtual ICollection<Image> Image { get; set; }
        public virtual ICollection<Link> Link { get; set; }
        public virtual User User { get; set; }
    }
}
