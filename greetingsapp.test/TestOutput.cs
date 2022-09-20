namespace greetingsapp.test;

public class TestOutput
{

    [Fact]
    public void ShoudBeAbleToAddUser()
    {
        List<UserModel> users = new List<UserModel>();
        IGreeting output = new Output(users);
        UserModel user = new UserModel(){ Id = 1, Name="teboho", Count= 1, Language ="english"};
        output.Add(user);
        Assert.Equal(1,output.GetUsers().Count());
    }

    [Fact]
    public void ShoudBeAbleToUpdateCounterUser()
    {
        List<UserModel> users = new List<UserModel>();
        IGreeting output = new Output(users);
        UserModel user = new UserModel(){ Id = 1, Name="teboho", Count= 1, Language ="english"};
        output.Add(user);
        output.Update(user);
        var updated = output.GetUser(user.Name);
        Assert.Equal(2,updated.Count);
    }

    [Fact]
    public void ShoudBeAbleRemoveUser()
    {
        List<UserModel> users = new List<UserModel>();
        IGreeting output = new Output(users);
        UserModel user = new UserModel(){ Id = 1, Name="teboho", Count= 1, Language ="english"};
        output.Add(user);
        output.Remove(user.Name);
        Assert.Equal(0,output.GetUsers().Count());
    }
    [Fact]
    public void ShoudBeAbleClear()
    {
        List<UserModel> users = new List<UserModel>();
        IGreeting output = new Output(users);
        UserModel user = new UserModel(){ Id = 1, Name="teboho", Count= 1, Language ="english"};
        output.Add(user);
        output.Clear();
        Assert.Equal(0,output.GetUsers().Count());
    }

    [Fact]
    public void ShoudReturnListofGreetedUsers()
    {
        List<UserModel> users = new List<UserModel>();
        IGreeting output = new Output(users);
        UserModel user = new UserModel(){ Id = 1, Name="teboho", Count= 1, Language ="english"};
        UserModel user1 = new UserModel(){ Id = 2, Name="thabo", Count= 1, Language ="afrikaans"};
        output.Add(user);
        output.Add(user1);
        Assert.Equal(2,output.GetUsers().Count());
    }
    
    [Fact]
    public void ShoudReturnGreetedCountOfSpecifiedUser()
    {
        List<UserModel> users = new List<UserModel>();
        IGreeting output = new Output(users);
        UserModel user = new UserModel(){ Id = 1, Name="teboho", Count= 1, Language ="english"};
        output.Add(user);
        var existuser = output.GetUser(user.Name);
        Assert.Equal(user,existuser);
    }
}