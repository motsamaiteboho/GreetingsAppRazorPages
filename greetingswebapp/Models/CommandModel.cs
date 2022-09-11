
using System.ComponentModel.DataAnnotations;
namespace greetingswebapp.Models
{
public class CommandModel 
{
    public int Id {get; set;}
    [Required]
    public string Name {get; set;} = string.Empty;
    public int Count {get; set;}
    public string Language {get; set;} = string.Empty;
}
}