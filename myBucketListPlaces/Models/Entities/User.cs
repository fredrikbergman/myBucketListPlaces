using System;
using System.Collections.Generic;

namespace myBucketListPlaces.Models.Entities
{
    public partial class User
    {
        public User()
        {
            Place = new HashSet<Place>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Place> Place { get; set; }
    }
}
