public static class Data
{
    static Dictionary<string, int> users = new();
    public  static  void Add(string name)
    {
        string newUser = name.ToLower().Trim();
        if(!users.ContainsKey(newUser))
            users.Add(newUser, 1);
        else
            users[newUser]++;
    }
    public  static void Remove(string name)
    {
        users.Remove(name);
    }
    public  static void Clear()
    {
        users.Clear();
    }
    public static Dictionary<string,int> getUsers()
    {
        return users;
    }
}