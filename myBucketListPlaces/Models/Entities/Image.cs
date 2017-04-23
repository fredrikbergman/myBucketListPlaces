using System;
using System.Collections.Generic;

namespace myBucketListPlaces.Models.Entities
{
    public partial class Image
    {
        public int Id { get; set; }
        public int ImageId { get; set; }
        public string ImageName { get; set; }

        public virtual Place ImageNavigation { get; set; }
    }
}
