namespace DevLibraryMads.Core.DTOs
{
    public class ClientDTOs
    {
        public ClientDTOs(string fullName, string birdthDate, string email)
        {
            FullName = fullName;
            BirdthDate = birdthDate;
            Email = email;
        }

        public string FullName { get; set; }
        public string BirdthDate { get; set; }
        public string Email { get; set; }
    }
}
