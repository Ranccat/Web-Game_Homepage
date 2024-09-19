using Microsoft.EntityFrameworkCore;

public class UserService
{
    private readonly AppDBContext _context;

    public UserService(AppDBContext context)
    {
        _context = context;
    }

    // CREATE
    public async Task<(bool IsSuccess, string ErrorMessage)> CreateUserAsync(User user)
    {
        // check for duplicated user_id
        bool isUserIdTaken = await _context.Users.AnyAsync(u => u.UserId == user.UserId);
        if (isUserIdTaken)
        {
            return (false, "The ID is already taken.");
        }

        // check for duplicated nickname
        bool isNicknameTaken = await _context.Users.AnyAsync(u => u.Nickname == user.Nickname);
        if (isNicknameTaken)
        {
            return (false, "The nickname is already taken.");
        }

        // check for duplicated email
        bool isEmailTaken = await _context.Users.AnyAsync(u => u.Email == user.Email);
        if (isEmailTaken)
        {
            return (false, "The email is already in use.");
        }

        // hash password
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

        // if no duplicates found
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return (true, string.Empty);
    }

    // READ?
}
