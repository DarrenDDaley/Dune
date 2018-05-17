using Dune.Models;

namespace Dune.Repository
{
    public interface IUserRepository
    {
        bool InsertUser(User user);
    }
}
