using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SecretSanta.BLL.Interfaces;
using SecretSanta.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecretSanta.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly SecretSantaContext _db;
        private readonly IShuffleService _shuffle;
        private readonly IMapper _mapper;

        public UserService(SecretSantaContext context, IShuffleService shuffle, IMapper mapper)
        {
            _db = context;
            _shuffle = shuffle;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            var users = await _db.Users.ToListAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task Add(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            _db.Users.Add(user);

            await _db.SaveChangesAsync();

            await _shuffle.ShuffleUsers();
        }
    }
}
