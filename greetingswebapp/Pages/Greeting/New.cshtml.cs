using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using greetingswebapp.Models;
using System.ComponentModel.DataAnnotations;

public class NewModel : PageModel
{
    private readonly CommandDbContext _context;
    private readonly IGreeting _greeting;
    private IWebHostEnvironment _environment;
    public NewModel(CommandDbContext context, IGreeting greeting, IWebHostEnvironment environment)
    {
        _context = context;
        _greeting = greeting;
        _environment = environment;
    }

    [BindProperty(SupportsGet = true), Required]
    public UserModel? Command { get; set; }

    public string[] Languages = new[] { "English", "Afrikaans", "Sesotho" };

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        var user = _greeting.GetUser(Command.Name.ToLower());
        if (user != null)
        {
            var filepic = Command.Upload is not null ? Command.Upload.FileName : user.ImageFile;
            user.ImageFile = filepic;
            user.Language = Command.Language;
            _greeting.Update(user);

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
            _greeting.Add(Command);

            if (Command.Upload != null)
            {
                var file = Path.Combine(_environment.ContentRootPath, "wwwroot/images/users", filepic2);
                using (var fileStream = new FileStream(file, FileMode.OpenOrCreate))
                {
                    Command.Upload.CopyToAsync(fileStream);
                }
            }
        }
        return Page();
    }
}
