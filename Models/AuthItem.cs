using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotnetAPIApp.Models;

[Table("auth_item")]
[Index("Type", Name = "idx-auth_item-type")]
[Index("RuleName", Name = "rule_name")]
public partial class AuthItem
{
    [Key]
    [Column("name")]
    [StringLength(64)]
    public string Name { get; set; } = null!;

    [Column("type", TypeName = "smallint(6)")]
    public short Type { get; set; }

    [Column("description", TypeName = "text")]
    public string? Description { get; set; }

    [Column("rule_name")]
    [StringLength(64)]
    public string? RuleName { get; set; }

    [Column("data", TypeName = "blob")]
    public byte[]? Data { get; set; }

    [Column("created_at", TypeName = "int(11)")]
    public int? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "int(11)")]
    public int? UpdatedAt { get; set; }

    [InverseProperty("ItemNameNavigation")]
    public virtual ICollection<AuthAssignment> AuthAssignments { get; set; } = new List<AuthAssignment>();

    [ForeignKey("RuleName")]
    [InverseProperty("AuthItems")]
    public virtual AuthRule? RuleNameNavigation { get; set; }

    [ForeignKey("Parent")]
    [InverseProperty("Parents")]
    public virtual ICollection<AuthItem> Children { get; set; } = new List<AuthItem>();

    [ForeignKey("Child")]
    [InverseProperty("Children")]
    public virtual ICollection<AuthItem> Parents { get; set; } = new List<AuthItem>();
}
