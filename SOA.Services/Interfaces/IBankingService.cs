using SOA.Dtos;

namespace SOA.Services.Interfaces;

public interface IBankingService
{
    Task<TransactionDto> Debit(int userId, float amount);

    Task<TransactionDto> Credit(int userId, float amount);
}
