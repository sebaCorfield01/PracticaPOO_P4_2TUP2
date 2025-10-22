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

    public User Add(User entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(User entity)
    {
        throw new NotImplementedException();
    }

    public User? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public User? GetUserByUserName(string userName)
    {
        return _applicationDbContext.Users.SingleOrDefault(p => p.UserName == userName);
    }

    public List<User> List()
    {
        throw new NotImplementedException();
    }

    public int SaveChanges()
    {
        throw new NotImplementedException();
    }

    public void Update(User entity)
    {
        throw new NotImplementedException();
    }
}