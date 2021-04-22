using System.ComponentModel.DataAnnotations.Schema;

namespace SecretSanta.DAL
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [ForeignKey("MatchForeignKey")]
        public User Match { get; set; }

        public bool HasGiver { get; set; }

        [ForeignKey("GiverForeignKey")]
        public User Giver { get; set; }

    }
}
