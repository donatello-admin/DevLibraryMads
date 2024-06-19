namespace DevLibraryMads.Core.Entities
{
    public class Client : EntityBase
    {
        public Client(string fullName, string birdthDate, string email)
        {
            FullName = fullName;
            BirdthDate = birdthDate;
            Email = email;
        }

        public string FullName { get; private set; }
        public string BirdthDate { get; private set; }
        public string Email { get; private set; }
        public List<Order> Orders { get; private set; }

        public void Update(string fullName,string birdthDate,string email)
        {
            FullName = fullName;
            BirdthDate = birdthDate;
            Email = email;
        }
    }
}
