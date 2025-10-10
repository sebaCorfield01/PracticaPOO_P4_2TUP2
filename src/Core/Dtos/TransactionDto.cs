namespace Core.Dtos;

using Core.Entities;

public record TransactionDto(decimal Amount, DateTime Date, string Notes)
{
    public static TransactionDto Create(Transaction entity)
        => new(entity.Amount, entity.Date, entity.Notes ?? string.Empty);

    public static List<TransactionDto> Create(IEnumerable<Transaction> entities)
        => entities.Select(Create).ToList();
}
