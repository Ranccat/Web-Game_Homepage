using System.ComponentModel.DataAnnotations;

public class ProfileDto
{
    [Required(ErrorMessage = "User ID is required")]
    public string Nickname { get; set; } = string.Empty;
    public string? Bio { get; set; } = string.Empty;
    public string? ProfileImageUrl { get; set; } = string.Empty;
}
