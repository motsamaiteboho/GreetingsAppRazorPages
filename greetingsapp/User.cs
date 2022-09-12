using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

public class UserModel 
{
    public int Id {get; set;}
    [Required]
    public string Name {get; set;} = string.Empty;
    public int Count {get; set;}
    public string Language {get; set;} = string.Empty;
    public string? ImageFile { get; set; }
    public IFormFile? Upload { get; set; } 

}