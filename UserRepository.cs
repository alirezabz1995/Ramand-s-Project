public class UserRepository
{
    private readonly string _connectionString;

    public UserRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<User> Authenticate(string username, string password)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var result = await connection.QueryFirstOrDefaultAsync<User>(
                "authenticateUser",
                new { Username = username, Password = password },
                commandType: CommandType.StoredProcedure);

            return result;
        }
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var result = await connection.QueryAsync<User>(
                "getAllUsers",
                commandType: CommandType.StoredProcedure);

            return result;
        }
    }
}
