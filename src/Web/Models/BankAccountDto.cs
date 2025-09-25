
using Core.Entities;

namespace Web.Models;

public record BankAccountDto(int Id, string Number, string Owner,decimal Balance)
{
    public static BankAccountDto Create(BankAccount entity)
    {
        var dto = new BankAccountDto(entity.Id, entity.Number, entity.Owner, entity.Balance);

        return dto;
    }


    public static List<BankAccountDto> Create(IEnumerable<BankAccount> entities)
    {
        var listDto = new List<BankAccountDto>();
        foreach (var entity in entities)
        {
            listDto.Add(Create(entity));
        }

        return listDto;
    }
}
