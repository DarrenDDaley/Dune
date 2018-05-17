using AutoMapper;
using Dune.Models;

namespace Dune.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserApiModel, User>();
        }
    }
}
