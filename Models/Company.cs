using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotnetAPIApp.Models;

[Table("company")]
public partial class Company
{
    [Key]
    [Column("id")]
    public ulong Id { get; set; }

    [Column("title")]
    [StringLength(250)]
    public string Title { get; set; } = null!;

    [Column("company_value")]
    [Precision(10)]
    public decimal? CompanyValue { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }
}
