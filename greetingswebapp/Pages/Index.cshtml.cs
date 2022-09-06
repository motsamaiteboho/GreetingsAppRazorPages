using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace greetingswebapp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private IOutput _output;
    public IndexModel(ILogger<IndexModel> logger, IOutput output)
    {
        _logger = logger;
        _output = output;
    }
    [BindProperty(SupportsGet = true)]
    public CommandModel Command { get; set; }
    public string? greeting { get; set; }
    public void OnGet()
    {
        if (!string.IsNullOrEmpty(Command.usercommand))
        {
            string[] command = Command.usercommand.Split(' ');
            string cmdtype = command[0].ToLower();
            switch (cmdtype)
            {
                case "greet":
                    greeting = _output.Greet(command);
                    break;
                case "greeted":
                    greeting = _output.Greeted(command);
                    break;
                case "counter":
                    greeting = _output.Count();
                    break;
                case "clear":
                    greeting = _output.Clear(command);
                    break;
                case "help":
                    greeting = _output.Help();
                    break;
                default:
                    greeting = "Invalid command. please, enter 'help' to check all valid commands";
                    break;
            }
        }

    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid == false)
        {
            return Page();
        }
        return RedirectToPage("/Index", new { Command.usercommand });
    }
}
