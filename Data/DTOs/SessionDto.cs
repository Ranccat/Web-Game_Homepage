public class SessionDto
{
    public required string UserId { get; set; }
    public required string Email { get; set; }
    public required string Nickname { get; set; }
    public string? ProfileImageUrl { get; set; }
    public string? Bio { get; set; }
    public DateTime? LastLogin { get; set; }
}