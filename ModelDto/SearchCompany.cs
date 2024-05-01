using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DotnetAPIApp.ModelsDto;

public class SearchCompany
{
    [Required(ErrorMessage = "ชื่อบริษัทห้ามว่าง")]
    public string Name { get; set; } = null!;
    [Range(100, 300, ConvertValueInInvariantCulture = false, ErrorMessage = "Code ต้องอยู่ระหว่าง 100 ถึง 300 เท่านั้น")]
    public int? Code { get; set; }

    [StringLength(5, ErrorMessage = "location ห้ามเกิน 5 ตัวอักษร")]
    [FromQuery(Name = "location")]
    public string? Province { get; set; }

}
