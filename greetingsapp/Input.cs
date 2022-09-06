public static class Input
{
    public static string[] getInput()
    {
        Console.Write("Enter command > ");
        string[]  command = Console.ReadLine().Split(' ');
        return command;
    }
}