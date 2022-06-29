using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Controllers;

public class Reporter
{
    [Required]
    public int id { get; set; }
    public string name { get; set; }
    
}