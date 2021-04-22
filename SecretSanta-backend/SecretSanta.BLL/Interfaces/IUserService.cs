using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecretSanta.BLL.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetUsers();
        Task Add(UserDTO user);
    }
}
