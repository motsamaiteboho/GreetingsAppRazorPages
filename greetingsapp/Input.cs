public static class Input
{
    static UserModel user = new UserModel();
    public static string[] getInput()
    {
        Console.Write("Enter command > ");
        string[] command = Console.ReadLine().Split(' ');
        string cmdtype = command[0].ToLower();

        if (cmdtype == "greet")
        {
            if (command.Length == 3)
            {
                user.Name = command[1].ToLower();
                user.Count = 1;
                user.Language = command[2].ToLower();
            }
            else
            {
                if (command.Length == 2)
                {
                    user.Name = command[1].ToLower();
                    user.Count = 1;
                    user.Language = "english";
                }
            }
        }

        return command;
    }
    public static UserModel GetUserModel()
    {
        return user;
    }
}