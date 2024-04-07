using System.ComponentModel.DataAnnotations;

namespace SOA.Data.Entities;

public class UserEntity
{
    [Key]
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public float Balance { get; set; }
}
