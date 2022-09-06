public class Output:IOutput
{
    Dictionary<string, int> users = Data.getUsers();
  
    public  string Greet(string[] command)
    {
        string greeting  = string.Empty;
        Dictionary<string,string> languaages = new(){
            {"english", "Hello"},  {"afrikaans", "Hallo"},  {"sesotho", "Dumelang"}
        };
        string Name = command.Length !=1 ? command[1].ToLower().Trim(): string.Empty;
        if(command.Length == 3)
        {
            string Lang = command[2].ToLower().Trim();
            if(languaages.ContainsKey(Lang))
            {
                foreach(var language in languaages)
                {
                    if(language.Key == Lang)
                        greeting += $"{language.Value}, {Name}";
                }
                Data.Add(Name);
            }
            else
            {
                greeting += $"Hello, {Name}. {Lang} laguage is curretly not supported";
            }
        }
        else
        {
             if(command.Length == 2)
             {
                 greeting += $"Hello, {Name}";
                Data.Add(Name);
             }
             else
                greeting += "please specify the name and language, enter 'help' to check all valid commands";
        }
        return greeting;
    }


    private  void AddUser(string name)
    {
        string newUser = name.ToLower().Trim();
        if(!users.ContainsKey(newUser))
            users.Add(newUser, 1);
        else
            users[newUser]++;
    }

    public  string Greeted(string[] command)
    {

        string sResult = string.Empty;
        if(command.Length == 2)
        {
            string Name = command[1].ToLower().Trim();
            if(users.ContainsKey(Name))
                sResult += $"{Name}  has been greeted {users[Name]} times";
            else
                sResult += $"{Name} hasn't been greeted";
        }
        else
        {
            if(command.Length == 1)
            {
                foreach(var user in users)
                {
                    sResult += $"{user.Key} : {user.Value} \n";
                }
            }
            else
                sResult += "Invalid arguments. please, enter 'help' to check all valid commands";
        }
        return sResult;
    }
    public  string Count()
    {
        string  sResults = string.Empty;
        int count = users.Values.Count;
        sResults += $"The number of users is {count}";
        return sResults;
    }
    public string Clear(string[] command)
    {
        string sResult = string.Empty;
        
        if(command.Length == 2)
        {
            string Name = command[1].ToLower().Trim();
            if(users.ContainsKey(Name))
            {
                Data.Remove(Name);
                sResult += $"{Name} has been cleared";
            }
            else
                sResult += $"{Name} hasn't been greeted";
        }
        else
        {
            Data.Clear();
            sResult += "users has been cleared";
        }
        return sResult;
    }

    public  string Help()
    {
        string help ="App valid commands: \n" +
            "greet [name] [language] - greet followed by the name and the language the user is to be greeted in secified language \n" +
            "greeted                 - list of all users that has been greeted and how many time each user has been greeted \n"+
            "greeted [username]      - greeted followed by a username returns how many times that specfic user has been greeted \n"+
            "counter                 - counter returns a count of how many unique users has been greeted \n"+
            "clear                   - clear deletes of all users greeted  \n"+
            "clear [username]        - clear followed by a username delete the greet counter for the specified user\n"+
            "exit                    - exits the application \n"+
            "help                    - help shows valid commands \n";
        
        return help;
    }

}

