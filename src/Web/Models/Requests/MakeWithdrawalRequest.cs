using System.ComponentModel.DataAnnotations;

namespace Web.Models.Requests;

public record MakeWithdrawalRequest(
    [Required]
    decimal Amount,

    [Required]
    string Notes,

    [Required]
    string Number
);