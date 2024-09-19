using Microsoft.EntityFrameworkCore;

public class UserService
{
    private readonly AppDBContext _context;

    public UserService(AppDBContext context)
    {
        _context = context;
    }

    // CREATE
    // TODO: CreateUserAsync

    // READ
    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }
}
