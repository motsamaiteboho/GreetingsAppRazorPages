namespace greetingsapp.test;

public class TestOutput
{
    [Fact]
    public void ShoudReturnTheGreetingInSpecifiedLang()
    {
        string[] command = "greet teboho english".Split(' ');
        Assert.Equal("Hello, teboho",Output.Greet(command));
    }

    [Fact]
    public void ShoudGreetInEnglishIfLangIsUnspecified()
    {
        string[] command = "greet teboho".Split(' ');
        Assert.Equal("Hello, teboho",Output.Greet(command));
    }

    [Fact]
    public void ShoudReturnUnsupportedLangReposonse()
    {
        string[] command = "greet teboho xhosa".Split(' ');
        Assert.Equal("Hello, teboho. xhosa laguage is curretly not supported",Output.Greet(command));
    }
    [Fact]
    public void ShoudErroMessageIfUnspecifiedArguments()
    {
        string[] command = "greet".Split(' ');
        Assert.Equal("please specify the name and language, enter 'help' to check all valid commands",Output.Greet(command));
    }

    [Fact]
    public void ShoudReturnListofGreetedUsers()
    {
        string[] command1 = "greet teboho english".Split(' ');
        Output.Greet(command1);
        string[] command2 = "greeted".Split(' ');
        Assert.Equal("teboho : 1 \n",Output.Greeted(command2));
    }
    public void ShoudReturnGreetedCountOfSpecifiedUser()
    {
        string[] command2 = "greeted thabo".Split(' ');
        Assert.Equal("teboho has been greeted 2 times",Output.Greeted(command2));
    }
    public void ShoudReturnCountofUniqueUsers()
    {
        Assert.Equal("The number of users is 1",Output.Count());
    }

    public void ShouldClearTheListOfUsers()
    {
         string[] command = "clear".Split(' ');
        Assert.Equal("users has been cleared",Output.Clear(command));
    }
    public void ShouldDeleteTheSpecifiedUserUsers()
    {
      
        string[] command1 = "greet teboho english".Split(' ');
        Output.Greet(command1);
        string[] command = "clear teboho".Split(' ');
        Assert.Equal("teboho has been cleared",Output.Clear(command));
    }
}