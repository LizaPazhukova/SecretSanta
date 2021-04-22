using AutoMapper;
using SecretSanta.DAL;

namespace SecretSanta.BLL
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateTwoWaysMap<User, UserDTO>();
        }

        private void CreateTwoWaysMap<T1, T2>()
        {
            CreateMap<T1, T2>();
            CreateMap<T2, T1>();
        }
    }
}
