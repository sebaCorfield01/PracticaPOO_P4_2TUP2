using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Web.Models.Requests;

public record CreateBankAccountRequest(
    [Required]
    string Name,

    [Required]
    decimal InitialBalance,

    [Required]
    AccountType AccountType,

    decimal? CreditLimit = null,
    decimal? MonthlyDeposit = null
);