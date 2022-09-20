using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using greetingswebapp.Models;

namespace greetingswebapp.Pages;

public class IndexModel : PageModel
{
    private readonly IGreeting _greeting;
    private readonly CommandDbContext _context;
    public IndexModel(CommandDbContext context, IGreeting greeting)
    {
        _context = context;
        _greeting = greeting;
    }
    public IEnumerable<UserModel> Commands {get;set;} = Enumerable.Empty<UserModel>();
    public void OnGet()
    {
        Commands = _greeting.GetUsers().ToList();
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid == false)
        {
            return Page();
        }
        return RedirectToPage("/Index");
    }
    
    public IActionResult OnPostDelete(string Name)
    {
         var user = _greeting.GetUser(Name);
         if(user != null)
        {
            _greeting.Remove(user);
        } 
         return RedirectToPage("/Index");
    }
     public IActionResult OnPostClear()
    {
        _greeting.Clear();
        return RedirectToPage("/Index");
    }
}
