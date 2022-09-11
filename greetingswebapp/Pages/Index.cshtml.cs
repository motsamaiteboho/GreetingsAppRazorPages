using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using greetingswebapp.Models;

namespace greetingswebapp.Pages;

public class IndexModel : PageModel
{
    private readonly IOutput output;
    private readonly CommandDbContext _context;
    public IndexModel(CommandDbContext context, IOutput output)
    {
        _context = context;
        this.output = output;
    }
   
    //public IEnumerable<CommandModel> Commands {get;set;} = Enumerable.Empty<CommandModel>();
    public IEnumerable<UserModel> Commands {get;set;} = Enumerable.Empty<UserModel>();
    public void OnGet()
    {
        // Commands =  _context.Commands
        //                         .OrderBy(o => o.Name).ToList();

        Commands = output.GetUsers().ToList();
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
        // var user = _context.Commands.FirstOrDefault(o => o.Id == id);

        // if(user != null)
        // {
        //     _context.Commands.Remove(user);
        //     _context.SaveChanges();
        // }
         var user = output.GetUser(Name);
         if(user != null)
        {
            output.Remove(user.Name);
        } 
         return RedirectToPage("/Index");
    }
     public IActionResult OnPostClear()
    {
      
        // _context.Commands.RemoveRange(_context.Commands);
        //  _context.SaveChanges();
        output.Clear();
        return RedirectToPage("/Index");
    }
}
