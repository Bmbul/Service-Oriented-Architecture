using Service_Oriented_Architecture.Dtos;
using SOA.Common.Enums;
using SOA.Data.Entities;
using SOA.Db.Repositories;
using SOA.Services.Interfaces;

namespace SOA.Services;

public class BankingService : IBankingService
{
    private readonly IRepository<UserEntity> _userRepository;
    private readonly IRepository<TransactionHistoryEntity> _transactionHistoryRepository;

    public BankingService(
        IRepository<UserEntity> userRepository, 
        IRepository<TransactionHistoryEntity> transactionHistoryRepository)
    {
        _userRepository = userRepository;
        _transactionHistoryRepository = transactionHistoryRepository;
    }

    public async Task<TransactionDto> Credit(int userId, float amount)
    {
        var user = await GetUser(userId);

        user.Balance += amount;
        await _userRepository.UpdateAsync(user);

        var transaction = new TransactionHistoryEntity()
        {
            UserId = user.Id,
            Ammount = amount,
            TransactionType = TransactionType.Credit,
        };
        await _transactionHistoryRepository.AddAsync(transaction);

        return new TransactionDto(userId, user.Balance);
    }

    public async Task<TransactionDto> Debit(int userId, float amount)
    {
        var user = await GetUser(userId);

        if (user.Balance < amount)
        {
            throw new InvalidOperationException("Insufficient funds!");
        }
        user.Balance -= amount;
        await _userRepository.UpdateAsync(user);

        var transaction = new TransactionHistoryEntity()
        {
            UserId = user.Id,
            Ammount = amount,
            TransactionType = TransactionType.Debit,
        };
        await _transactionHistoryRepository.AddAsync(transaction);

        return new TransactionDto(userId, user.Balance);
    }

    private async Task<UserEntity> GetUser(int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        if (user == null)
        {
            throw new KeyNotFoundException($"User not found with id: {userId}.");
        }
        return user;
    }
}
