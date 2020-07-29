namespace PrimaryStorage.Entities
{
    public class GuestComment
    {
        public int Id { get; set; }

        public int GuestId { get; set; }
        public Guest Guest { get; set; }

        public string Comment { get; set; }
    }
}
