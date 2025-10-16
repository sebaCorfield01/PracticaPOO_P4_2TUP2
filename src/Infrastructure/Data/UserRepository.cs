using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace ConsultaAlumnos.Infrastructure.Data;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    public UserRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public User? GetUserByUserName(string userName)
    {
        return _applicationDbContext.Users.SingleOrDefault(p => p.UserName == userName);
    }

}