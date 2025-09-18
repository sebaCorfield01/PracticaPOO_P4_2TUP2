using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data;

public class BankAccountRepository : IBankAccountRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    public BankAccountRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public BankAccount Add(BankAccount entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(BankAccount entity)
    {
        throw new NotImplementedException();
    }

    public BankAccount GetByAccountNumber(string accountNumber)
    {
        throw new NotImplementedException();
    }

    public BankAccount GetById(int id)
    {
        throw new NotImplementedException();
    }

    public List<BankAccount> List()
    {
        throw new NotImplementedException();
    }

    public BankAccount Update(BankAccount entity)
    {
        throw new NotImplementedException();
    }
}