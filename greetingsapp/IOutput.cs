public interface IOutput
{
    IEnumerable<UserModel> GetUsers();
    UserModel GetUser(string Name);
    void Add(UserModel user);
    void Update(UserModel user);
    void  Remove(UserModel user);
    void Clear();
    void  Help();
}