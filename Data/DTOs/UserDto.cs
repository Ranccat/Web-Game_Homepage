using System.ComponentModel.DataAnnotations;

public class UserDto
{
    [Required(ErrorMessage = "User ID is required.")]
    public string UserId { get; set; } = string.Empty;
    [Required(ErrorMessage = "Password is required.")]
    public string Password { get; set; } = string.Empty;
    [Required(ErrorMessage = "Email is required.")]
    public string Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "Nickname is required.")]
    public string Nickname { get; set; } = string.Empty;
    public string? Bio { get; set; } = null;
}
