// See https://aka.ms/new-console-template for more information
Console.WriteLine("Greetings App");
Console.WriteLine("====================");
Console.WriteLine("enter 'help' for valid commands");
string cmdtype = string.Empty;

List<UserModel> users = new List<UserModel>();

//IOutput output = new Output(users);
IOutput output = new OutputWithDb("Data Source=./UsersDb.db");

do
{
    string[] command = Input.getInput();
    cmdtype = command[0].ToLower();
    switch (cmdtype)
    {
        case "greet":
            Greet(output,command,users);
            break;
        case "greeted":
            Greeted(command,output);
            break;
        case "counter":
            Console.WriteLine($"Unique users: {output.GetUsers().Count()}");
            break;
        case "clear":
            Clear(command,output);
            break;
        case "help":
            output.Help();
            break;
        default:
            Console.WriteLine("Invalid command. please, enter 'help' to check all valid commands");
            break;

    }
} while (cmdtype != "exit");


Console.WriteLine("Thank you for using our greetings app, press any key to exit...");
Console.ReadKey();

static void Greet(IOutput output, string[] command, List<UserModel> users)
{
    UserModel user = Input.GetUserModel();

    var exituser = output.GetUser(user.Name);
    if (exituser == null)
    {
        user.Id = users.Count > 0 ? users.Max(o => o.Id) + 1 : 1;
        output.Add(user);
    }
    else
        output.Update(exituser);

    Console.WriteLine(user.GreetingMessage);
}
static void Greeted(string[]  command, IOutput output)
{
    if (command.Length == 2)
    {
        string Name = command[1].ToLower();
        var user = output.GetUser(Name);
        if(user != null){
            Console.WriteLine($"{user.Name} has been greeted {user.Count} times");
        }
        else{
            Console.WriteLine($"{Name} hasn't been greeted");
        }
    }
    else
    {
        foreach (var item in output.GetUsers())
        {
            Console.WriteLine($"{item.Name}  :  {item.Count}");
        }
    }
}

static void Clear(string[]  command, IOutput output)
{
    if(command.Length == 2)
    {
        string Name = command[1].ToLower();
        var user = output.GetUser(Name);
        if(user != null){
            output.Remove(user);
        }
        else{
            Console.WriteLine($"{Name} hasn't been greeted");
        }
    }
    else
    {
         output.Clear();
    }
}


