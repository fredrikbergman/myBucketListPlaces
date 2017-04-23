using System;
using System.Collections.Generic;

namespace myBucketListPlaces.Models.Entities
{
    public partial class Link
    {
        public int Id { get; set; }
        public int PlaceId { get; set; }
        public string Link1 { get; set; }

        public virtual Place Place { get; set; }
    }
}
