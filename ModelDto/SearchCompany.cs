using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DotnetAPIApp.ModelsDto;

public class SearchCompany
{    
    public string Name { get; set; } = null!;
    public int? Code { get; set; }
    public string? Province { get; set; }
    
}
