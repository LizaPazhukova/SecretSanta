namespace SecretSanta.BLL
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserDTO Match { get; set; }
        public bool HasGiver { get; set; }
        public UserDTO Giver { get; set; }
    }
}
