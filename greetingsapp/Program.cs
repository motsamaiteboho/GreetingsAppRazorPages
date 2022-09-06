// See https://aka.ms/new-console-template for more information
Console.WriteLine("Greetings App");
Console.WriteLine("====================");
Console.WriteLine("enter 'help' for valid commands");
string cmdtype = string.Empty;
do
{
    string [] command  = Input.getInput();
    cmdtype= command[0].ToLower(); 
    IOutput output = new Output();
    switch (cmdtype)
    {
        case "greet":
       
        Console.WriteLine(output.Greet(command));
        break;
        case "greeted":
        Console.WriteLine(output.Greeted(command));
        break;
        case "counter":
        Console.WriteLine(output.Count());
        break;
        case "clear":
        Console.WriteLine(output.Clear(command));
        break;
        case "help":
        Console.WriteLine(output.Help());
        break;
        default:
        Console.WriteLine("Invalid command. please, enter 'help' to check all valid commands");
        break;

    }
}while(cmdtype !="exit");


Console.WriteLine("Thank you for using our greetings app, press any key to exit...");
Console.ReadKey();


