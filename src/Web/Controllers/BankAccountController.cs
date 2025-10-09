using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using System.Linq.Expressions;
using Web.Models;
using Core.Exceptions;
using Web.Models.Requests;
using Core.Services;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class BankAccountController : ControllerBase
{
    private readonly IBankAccountRepository _bankAccountRepository;
    private readonly BankAccountService _bankAccountService;

    public BankAccountController(IBankAccountRepository bankAccountRepository, BankAccountService bankAccountService )
    {
        _bankAccountService = bankAccountService;
        _bankAccountRepository = bankAccountRepository;
    }

    [HttpPost("create")]
    public IActionResult CreateBankAccount([FromBody] CreateBankAccountRequest bankAccountDto)
    {
       var newAccount =  _bankAccountService.CreateBankAccount(bankAccountDto.Name
        , bankAccountDto.InitialBalance
        , bankAccountDto.AccountType
        , bankAccountDto.CreditLimit
        , bankAccountDto.MonthlyDeposit);

        return CreatedAtAction(nameof(GetAccountInfo), new { accountNumber = newAccount.Number }, BankAccountDto.Create(newAccount));
    }

    [HttpPost("monthEnd")]
    public ActionResult<string> PerformMonthEndForAccount([FromQuery] string accountNumber)
    {
        var account = _bankAccountRepository.GetByAccountNumber(accountNumber)
            ?? throw new AppValidationException("Cuenta no encontrada.");

        account.PerformMonthEndTransactions();
        return Ok($"Month-end processing completed for account {account.Number}.");
    }

    [HttpPost("deposit")]
    public ActionResult<string> MakeDeposit([FromQuery] decimal amount, [FromQuery] string note, [FromQuery] string accountNumber)
    {
        var account = _bankAccountRepository.GetByAccountNumber(accountNumber)
            ?? throw new AppValidationException("Cuenta no encontrada.");

        account.MakeDeposit(amount, DateTime.Now, note);
        _bankAccountRepository.Update(account);

        return Ok($"A deposit of ${amount} was made in account {account.Number}.");
    }

    [HttpPost("withdrawal")]
    public ActionResult<string> MakeWithdrawal([FromQuery] decimal amount, [FromQuery] string note, [FromQuery] string accountNumber)
    {
        var account = _bankAccountRepository.GetByAccountNumber(accountNumber)
            ?? throw new AppValidationException("Cuenta no encontrada.");

        account.MakeWithdrawal(amount, DateTime.Now, note);
        _bankAccountRepository.Update(account);


        return Ok($"A withdrawal of ${amount} was made in account {account.Number}.");
    }

    [HttpGet("balance")]
    public ActionResult<string> GetBalance([FromQuery] string accountNumber)
    {
        var balance = _bankAccountService.GetBalance(accountNumber);
        return Ok($"The balance in account {accountNumber} is ${balance}.");

    }

    [HttpGet("accountHistory")]
    public IActionResult GetAccountHistory([FromQuery] string accountNumber)
    {
        var account = _bankAccountRepository.GetByAccountNumber(accountNumber)
            ?? throw new AppValidationException("Cuenta no encontrada.");

        var history = account.GetAccountHistory();

        return Ok(history);
    }

    [HttpGet("accountInfo")]
    public ActionResult<BankAccountDto> GetAccountInfo([FromQuery] string accountNumber)
    {
        var account = _bankAccountRepository.GetByAccountNumber(accountNumber)
            ?? throw new AppValidationException("Cuenta no encontrada.");

        return BankAccountDto.Create(account);
    }

    [HttpGet("allAccountsInfo")]
    public ActionResult<List<BankAccountDto>> GetAllAccountInfo()
    {
        var list = _bankAccountRepository.ListWithTransaction();
        return BankAccountDto.Create(list);
    }
}