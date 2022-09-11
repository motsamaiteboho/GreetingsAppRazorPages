using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using greetingswebapp.Models;
using System.ComponentModel.DataAnnotations;

public class NewModel : PageModel
{
    private readonly CommandDbContext _context;
    private readonly IOutput output;
    public NewModel(CommandDbContext context, IOutput output)
    {
        _context = context;
        this.output = output;
    }

    [BindProperty(SupportsGet = true), Required]
    //public CommandModel Command { get; set; }
    public UserModel Command { get; set; }

    [BindProperty]
    public string? GreetingMessage { get; set; }

    public string[] Languages = new[] { "English", "Afrikaans", "Sesotho" };

    public void OnGet()
    {
        if (Command != null)
        {
            Dictionary<string, string> Languages = new(){
            {"English", "Hello"},  {"Afrikaans", "Hallo"},  {"Sesotho", "Dumelang"}
            };
            if (Command != null)
            {
                foreach (var lang in Languages)
                {
                    if (lang.Key == Command.Language)
                        GreetingMessage += $"{lang.Value}, {Command.Name}";
                }
            }
        }
    }

    public IActionResult OnPost()
    {
        // var user = _context.Commands.FirstOrDefault(o => o.Name == Command.Name);
        // if (user != null)
        // {
        //     user.Count = user.Count + 1;
        //     user.Language = Command.Language;
        //     _context.SaveChanges();
        // }
        // else
        // {
        //     if (ModelState.IsValid)
        //     {
        //          Command.Count = 1;
        //         _context.Commands.Add(Command);
        //         _context.SaveChanges();
        //     }
        // }

        var user = output.GetUser(Command.Name.ToLower());
        if (ModelState.IsValid)
        {
            if (user != null)
            {
                user.Language = Command.Language;
                output.Update(user);
            }
            else
            {

                Command.Count = 1;
                Command.Name = Command.Name.ToLower();
                output.Add(Command);

            }
        }
        return RedirectToPage(new { Command.Language, Command.Name });
    }

}
