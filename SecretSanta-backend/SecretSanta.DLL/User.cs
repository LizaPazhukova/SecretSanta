using System;

namespace SecretSanta.DLL
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public User Donor { get; set; }
        public User Recipient { get; set; }
       
    }
}
