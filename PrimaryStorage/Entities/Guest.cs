using System.Collections.Generic;

namespace PrimaryStorage.Entities
{
    public class Guest
    {
        public int Id { get; set; }
        public string Secret { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public bool? Accepted { get; set; }

        public List<GuestComment> GuestComments { get; set; }
    }
}
