public class Output:IOutput
{
    private List<UserModel> users;
    public Output(List<UserModel> users)
    {
        this.users = users;
    }
    public IEnumerable<UserModel> GetUsers()
    {
        return users;
    }
    public  UserModel GetUser(string Name)
    {
       return users.FirstOrDefault(o => o.Name == Name);
    }

    public void Add(UserModel user)
    {
        if (!users.Contains(user))
            users.Add(user);
    }
    public void Update(UserModel user)
    {
        var existinguser = users.FirstOrDefault(o => o.Name == user.Name);
        if (existinguser != null)
        {
            existinguser.Count = existinguser.Count + 1;
        }
    }
    public void Remove(UserModel user)
    {
        var existinguser = users.FirstOrDefault(o => o.Name == user.Name);
        if (existinguser != null)
        {
            users.Remove(existinguser);
        }
    }
    public void Clear()
    {
        users.Clear();
    }
    public void Help()
    {
        string help = 
            "App valid commands: \n" +
            "greet [name] [language] - greet followed by the name and the language the user is to be greeted in secified language \n" +
            "greeted                 - list of all users that has been greeted and how many time each user has been greeted \n"+
            "greeted [username]      - greeted followed by a username returns how many times that specfic user has been greeted \n"+
            "counter                 - counter returns a count of how many unique users has been greeted \n"+
            "clear                   - clear deletes of all users greeted  \n"+
            "clear [username]        - clear followed by a username delete the greet counter for the specified user\n"+
            "exit                    - exits the application \n"+
            "help                    - help shows valid commands \n";
           
        
        Console.WriteLine(help);
    }

}

