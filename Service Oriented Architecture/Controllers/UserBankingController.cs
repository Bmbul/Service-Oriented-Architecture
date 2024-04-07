using Microsoft.AspNetCore.Mvc;
using Service_Oriented_Architecture.Dtos;
using SOA.Services.Interfaces;

namespace SOA.Controllers;

[ApiController]
[Route("v1/[controller]/[action]")]
public class UserBankingController : ControllerBase
{
    private readonly IBankingService _bankingService;

    public UserBankingController(IBankingService bankingService)
    {
        _bankingService = bankingService;
    }

    [HttpPost]
    public async Task<ActionResult> Debit([FromBody] TransactionRequest request)
    {
        try
        {
            var result = await _bankingService.Debit(request.UserId, request.Amount);
            return Ok(result);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> Credit([FromBody] TransactionRequest request)
    {
        try
        {
            var result = await _bankingService.Credit(request.UserId, request.Amount);
            return Ok(result);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
