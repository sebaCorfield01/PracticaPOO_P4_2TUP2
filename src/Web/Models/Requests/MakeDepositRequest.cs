using System.ComponentModel.DataAnnotations;

namespace Web.Models.Requests;

public record MakeDepositRequest(
    [Required]
    decimal Amount,

    [Required]
    string Note,

    [Required]
    string Number
);