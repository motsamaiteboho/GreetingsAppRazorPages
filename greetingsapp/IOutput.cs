public interface IOutput
{
    IEnumerable<UserModel> GetUsers();
    UserModel GetUser(string Name);
    void Add(UserModel user);
    void Update(UserModel user);
    void  Remove(string Name);
    void Clear();
    void  Help();
}