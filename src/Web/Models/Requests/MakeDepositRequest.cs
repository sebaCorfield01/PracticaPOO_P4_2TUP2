using System.ComponentModel.DataAnnotations;

namespace Web.Models.Requests;

public record MakeDepositRequest(
    [Required]
    decimal Amount,

    [Required]
    string Notes,

    [Required]
    string Number
);