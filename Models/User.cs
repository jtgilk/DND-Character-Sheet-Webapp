namespace DND_Character_Sheet_Webapp.Models
{
    public class User
    {        
        // Properties
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string EmailNormalized { get; set; }
        public string Password { get; set; }

        // Item Constructor
        public User()
        {
        }
    }
}
