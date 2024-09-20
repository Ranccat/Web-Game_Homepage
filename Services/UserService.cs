using Microsoft.EntityFrameworkCore;

public class UserService
{
    private readonly AppDBContext _context;

    public UserService(AppDBContext context)
    {
        _context = context;
    }

    // CREATE
    public async Task<(bool IsSuccess, string ErrorMessage)> CreateUserAsync(UserDto userDto)
    {
        // check for duplicated user_id
        bool isUserIdTaken = await _context.Users.AnyAsync(u => u.UserId == userDto.UserId);
        if (isUserIdTaken)
        {
            return (false, "The ID is already taken.");
        }

        // check for duplicated nickname
        bool isNicknameTaken = await _context.Users.AnyAsync(u => u.Nickname == userDto.Nickname);
        if (isNicknameTaken)
        {
            return (false, "The nickname is already taken.");
        }

        // check for duplicated email
        bool isEmailTaken = await _context.Users.AnyAsync(u => u.Email == userDto.Email);
        if (isEmailTaken)
        {
            return (false, "The email is already in use.");
        }

        var user = new User
        {
            UserId = userDto.UserId,
            Password = userDto.Password,
            Email = userDto.Email,
            Nickname = userDto.Nickname,
            Bio = userDto.Bio,
            LastLogin = DateTime.UtcNow,
            CreatedAt = DateTime.UtcNow
        };

        // hash password
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

        // if no duplicates found
        Console.WriteLine("New user registed");
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return (true, string.Empty);
    }

    public async Task<(bool IsSuccess, string ErrorMessage)> LoginAsync(UserDto userDto)
    {
        var userExist = await _context.Users.AnyAsync(u => u.UserId == userDto.UserId);
        if (userExist == false)
        {
            return (false, "User ID doesn't exists");
        }

        Console.WriteLine("Login Successfull");
        Console.WriteLine($"{userDto.UserId}");
        return (true, string.Empty);
    }
}
