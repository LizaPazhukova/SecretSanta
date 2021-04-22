using SecretSanta.BLL.Interfaces;
using SecretSanta.DAL;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SecretSanta.BLL.Services
{
    public class ShuffleService : IShuffleService
    {
        private readonly SecretSantaContext _db;

        public ShuffleService(SecretSantaContext context)
        {
            _db = context;
        }

        public async Task ShuffleUsers()
        {
            var rnd = new Random(DateTime.UtcNow.Second);

            var participants = _db.Users.ToList();
            while (participants.Any(x => !x.HasGiver))
            {
                var participant1 = participants.First(x => !x.HasGiver);
                var unmatched = participants.Where(x => x.Match == null && x.Id != participant1.Id);
                if (unmatched.Count() == 0)
                {
                    var match = participants.First(x => x.Id != participant1.Id);
                    participant1.Giver = match;
                    participant1.Match = match.Match;
                    match.Match.Giver = participant1;
                    match.Match = participant1;
                    participant1.HasGiver = true;
                }
                else
                {
                    var match = unmatched.ToList().ElementAt(rnd.Next(unmatched.Count() - 1));
                    participant1.Giver = match;
                    participant1.HasGiver = true;
                    match.Match = participant1;
                }
            }
            await _db.SaveChangesAsync();
        }
    }
}
