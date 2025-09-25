using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

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
        _applicationDbContext.bankAccounts.Add(entity);
        _applicationDbContext.SaveChanges();
        return entity;
    }

    public void Delete(BankAccount entity)
    {
        _applicationDbContext.bankAccounts.Remove(entity);
        _applicationDbContext.SaveChanges();
    }

    public BankAccount? GetByAccountNumber(string accountNumber)
    {
        return _applicationDbContext
        .bankAccounts
        //.Include(x => x.Transactions)
        .FirstOrDefault(a => a.Number == accountNumber);
    }

    public BankAccount? GetById(int id)
    {
        return _applicationDbContext.bankAccounts.FirstOrDefault(a => a.Id == id);
    }

    public List<BankAccount> List()
    {
        return _applicationDbContext.bankAccounts
        .ToList();
    }
    public List<BankAccount> ListWithTransaction()
    {
        return _applicationDbContext.bankAccounts
        .Include(x => x.Transactions)
        .ToList();
    }

    public BankAccount Update(BankAccount entity)
    {
        _applicationDbContext.bankAccounts.Update(entity);
        _applicationDbContext.SaveChanges();
        return entity;
    }

    public List<BankAccount> GetByExpression(Expression<Func<BankAccount, bool>> expression)
    {
        return _applicationDbContext.bankAccounts.Where(expression).ToList();
    }
}