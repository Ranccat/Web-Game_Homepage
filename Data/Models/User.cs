public class User
{
    public int Id { get; set; } // PK
    public required string UserId { get; set; } // id for login
    public required string Password { get; set; } // hashed password
    public required string Email { get; set; }
    public required string Nickname { get; set; } // must be unique
    public string? ProfileImageUrl { get; set; }
    public string? Bio { get; set; }
    public DateTime? LastLogin { get; set; }
    public DateTime CreatedAt { get; set; }
}
