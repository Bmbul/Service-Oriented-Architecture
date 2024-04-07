using SOA.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace SOA.Data.Entities;

public class TransactionHistoryEntity
{
    [Key]
    public long TransactionId { get; set; }

    public int UserId { get; set; }

    public float Ammount { get; set; }

    public TransactionType TransactionType { get; set; }
}
