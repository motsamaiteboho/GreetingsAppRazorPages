using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using greetingswebapp.Models;
using System.ComponentModel.DataAnnotations;

public class NewModel : PageModel
{
    private readonly CommandDbContext _context;
    private readonly IOutput output;
    private IWebHostEnvironment _environment;
    public NewModel(CommandDbContext context, IOutput output,IWebHostEnvironment environment)
    {
        _context = context;
        this.output = output;
        _environment = environment;
    }

    [BindProperty(SupportsGet = true), Required]
    //public CommandModel Command { get; set; }
    public UserModel Command { get; set; }

    [BindProperty]
    public string? GreetingMessage { get; set; }

    public string? Name { get; set; }
    public string? ProfilePic { get; set; }
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
                    {
                        GreetingMessage += $"{lang.Value}, {Command.Name}";
                        Name = Command.Name;
                        ProfilePic = Command.ImageFile; 
                    }
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
            if (user != null)
            {
                user.ImageFile = Command.Upload is not null? Command.Upload.FileName: user.ImageFile;
                user.Language = Command.Language;
                output.Update(user);
                if(Command.Upload != null)
                {
                     var file = Path.Combine(_environment.ContentRootPath, "wwwroot/images/users", Command.Upload.FileName);
                    using (var fileStream = new FileStream(file, FileMode.Create))
                    {
                         Command.Upload.CopyToAsync(fileStream);
                    }
                }
            }
            else
            {
                Command.Count = 1;
                Command.ImageFile = Command.Upload is not null? Command.Upload.FileName : "user.png";
                Command.Name = Command.Name.ToLower();
                output.Add(Command);
                
                if(Command.Upload != null)
                {
                     var file = Path.Combine(_environment.ContentRootPath, "wwwroot/images/users", Command.Upload.FileName);
                    using (var fileStream = new FileStream(file, FileMode.Create))
                    {
                         Command.Upload.CopyToAsync(fileStream);
                    }
                }
               

            }
        return RedirectToPage(new { Command.Language, Command.Name, Command.ImageFile});
    }

}
