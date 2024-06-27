using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotnetAPIApp.Models;

[Table("navbar_menu")]
[Index("ParentId", Name = "parent")]
public partial class NavbarMenu
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("url")]
    [StringLength(255)]
    public string Url { get; set; } = null!;

    [Column("label")]
    [StringLength(255)]
    public string Label { get; set; } = null!;

    [Column("parent_id", TypeName = "int(11)")]
    public int? ParentId { get; set; }

    [Column("status", TypeName = "smallint(6)")]
    public short Status { get; set; }

    [Column("sort_index", TypeName = "int(11)")]
    public int? SortIndex { get; set; }

    [InverseProperty("Parent")]
    public virtual ICollection<NavbarMenu> InverseParent { get; set; } = new List<NavbarMenu>();

    [ForeignKey("ParentId")]
    [InverseProperty("InverseParent")]
    public virtual NavbarMenu? Parent { get; set; }
}
