using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interfaces;

public interface IUserRepository
{
    User? GetUserByUserName(string userName);

}