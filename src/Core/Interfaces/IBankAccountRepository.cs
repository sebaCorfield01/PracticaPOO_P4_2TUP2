using Core.Entities;

namespace Core.Interfaces;

public interface IBankAccountRepository
{
    BankAccount GetById(int id);

    BankAccount GetByAccountNumber(string accountNumber);

    List<BankAccount> List();

    BankAccount Add(BankAccount entity);

    BankAccount Update(BankAccount entity);

    void Delete(BankAccount entity);

}