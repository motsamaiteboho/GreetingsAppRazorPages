public interface IOutput
{
    string Greet(string[] command);
    string Greeted(string[] command);
    string  Count();
    string  Clear(string[] command);
    string Help();

}