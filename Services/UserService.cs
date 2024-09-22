using Microsoft.EntityFrameworkCore;

public class UserService
{
    private readonly AppDBContext _context;

    public UserService(AppDBContext context)
    {
        _context = context;
    }

    public async Task<(bool IsSuccess, string ErrorMessage)> RegisterAsync(RegisterDto registerDto)
    {
        // check for duplicated user_id
        bool isUserIdTaken = await _context.Users.AnyAsync(u => u.UserId == registerDto.UserId);
        if (isUserIdTaken)
        {
            return (false, "The ID is already taken.");
        }

        // check for duplicated nickname
        bool isNicknameTaken = await _context.Users.AnyAsync(u => u.Nickname == registerDto.Nickname);
        if (isNicknameTaken)
        {
            return (false, "The nickname is already taken.");
        }

        // check for duplicated email
        bool isEmailTaken = await _context.Users.AnyAsync(u => u.Email == registerDto.Email);
        if (isEmailTaken)
        {
            return (false, "The email is already in use.");
        }

        // create entity
        DateTime currentDateTime = DateTime.UtcNow;
        var user = new User
        {
            UserId = registerDto.UserId,
            Password = registerDto.Password,
            Email = registerDto.Email,
            Nickname = registerDto.Nickname,
            Bio = null,
            LastLogin = currentDateTime,
            CreatedAt = currentDateTime
        };

        // hash password
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

        // if no duplicates found
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return (true, string.Empty);
    }

    public async Task<(bool IsSuccess, string ErrorMessage)> LoginAsync(LoginDto loginDto)
    {
        // check if the user exists
        var userInfo = await _context.Users.FirstOrDefaultAsync(u => u.UserId == loginDto.UserId);
        if (userInfo == null)
        {
            return (false, "The user ID doesn't exists");
        }

        // verify password
        bool passwordVerified = BCrypt.Net.BCrypt.Verify(loginDto.Password, userInfo.Password);
        if (passwordVerified == false)
        {
            return (false, "Incorrect password");
        }

        // update last login datetime
        userInfo.LastLogin = DateTime.UtcNow;
        await _context.SaveChangesAsync();

        return (true, string.Empty);
    }
}
