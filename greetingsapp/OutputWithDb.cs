using Microsoft.Data.Sqlite;
using Dapper;

public class OutputWithDb : IOutput
{
    private string _connectionString;
    public OutputWithDb(string connectionString)
    {
        _connectionString = connectionString;

        using (var connection = new SqliteConnection(_connectionString))
        {
            string CREATE_USER_TABLE = @"create table if not exists user (
	            Id integer primary key AUTOINCREMENT,
	            Name text,
	            Count integer,
	            Language text
            );";
            connection.Execute(CREATE_USER_TABLE);
        }
    }
    //"Data Source=./trying_dapper.db";
    public IEnumerable<UserModel> GetUsers()
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            var users = connection.Query<UserModel>(@"select * from user");
            return users;
        }
    }
    public UserModel GetUser(string Name)
    {
        var template = new UserModel { Name = Name };
        var parameters = new DynamicParameters(template);
        var sql = @"select * from user where Name = @Name";
        using (var connection = new SqliteConnection(_connectionString))
        {
            var user = connection.QueryFirstOrDefault<UserModel>(sql, parameters);
            return user;
        }
    }

    public void Add(UserModel user)
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            var sql = @" insert into  user (Name, Count, Language)
	                    values (@Name, @Count, @Language);";
            var parameters = new UserModel()
            {
                Name = user.Name,
                Count = user.Count,
                Language = user.Language
            };

            connection.Execute(sql, parameters);
        }
    }

    public void Update(UserModel user)
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            var template = new UserModel { Name = user.Name, Count = user.Count + 1, Language = user.Language };
            var parameters = new DynamicParameters(template);
            var sql = @" update user
	                     set Count= @Count, Language = @Language
                         where Name = @Name;";
            connection.Execute(sql, parameters);
        }
    }
    public void Remove(UserModel user)
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            if (user.Count > 1)
            {
                var template = new UserModel { Name = user.Name, Count = user.Count - 1 };
                var parameters = new DynamicParameters(template);
                var sql = @"update user
                          set Count= @Count
                          where Name = @Name;";
                connection.Execute(sql, parameters);
            }
            else
            {
                var template = new UserModel { Name = user.Name };
                var parameters = new DynamicParameters(template);
                var sql = @"delete from user
                        where Name = @Name;";
                connection.Execute(sql, parameters);
            }

        }
    }

    public void Clear()
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            var sql = @"delete from user;";
            connection.Execute(sql);
        }
    }

    public void Help()
    {

    }


}