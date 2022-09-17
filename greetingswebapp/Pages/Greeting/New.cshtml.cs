using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using greetingswebapp.Models;
using System.ComponentModel.DataAnnotations;

public class NewModel : PageModel
{
    private readonly CommandDbContext _context;
    private readonly IOutput output;
    private IWebHostEnvironment _environment;
    public NewModel(CommandDbContext context, IOutput output, IWebHostEnvironment environment)
    {
        _context = context;
        this.output = output;
        _environment = environment;
    }

    [BindProperty(SupportsGet = true), Required]
    //public CommandModel Command { get; set; }
    public UserModel? Command { get; set; }

    //public string? GreetingMessage { get; set; }
    //public string? Name { get; set; }
    //public string? ProfilePic { get; set; }
    public string[] Languages = new[] { "English", "Afrikaans", "Sesotho" };

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
        if (!ModelState.IsValid)
        {
            return Page();
        }
        var user = output.GetUser(Command.Name.ToLower());
        if (user != null)
        {
            var filepic = Command.Upload is not null ? Command.Upload.FileName : user.ImageFile;
            user.ImageFile = filepic;
            user.Language = Command.Language;
            output.Update(user);

            if (Command.Upload != null)
            {
                var file = Path.Combine(_environment.ContentRootPath, "wwwroot/images/users", filepic);
                using (var fileStream = new FileStream(file, FileMode.OpenOrCreate))
                {
                    Command.Upload.CopyToAsync(fileStream);
                }
            }
        }
        else
        {
            var filepic2 = Command.Upload is not null ? Command.Upload.FileName : "user.png";
            Command.Count = 1;
            Command.ImageFile = filepic2;
            Command.Name = Command.Name.ToLower();
            output.Add(Command);

            if (Command.Upload != null)
            {
                var file = Path.Combine(_environment.ContentRootPath, "wwwroot/images/users", filepic2);
                using (var fileStream = new FileStream(file, FileMode.OpenOrCreate))
                {
                    Command.Upload.CopyToAsync(fileStream);
                }
            }
        }
        //return RedirectToPage(new { Command.Language, Command.Name, Command.ImageFile });
        return Page();
    }
}
