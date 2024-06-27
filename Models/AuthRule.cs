using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotnetAPIApp.Models;

[Table("auth_rule")]
public partial class AuthRule
{
    [Key]
    [Column("name")]
    [StringLength(64)]
    public string Name { get; set; } = null!;

    [Column("data", TypeName = "blob")]
    public byte[]? Data { get; set; }

    [Column("created_at", TypeName = "int(11)")]
    public int? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "int(11)")]
    public int? UpdatedAt { get; set; }

    [InverseProperty("RuleNameNavigation")]
    public virtual ICollection<AuthItem> AuthItems { get; set; } = new List<AuthItem>();
}
