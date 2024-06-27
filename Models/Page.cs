using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotnetAPIApp.Models;

[Table("page")]
public partial class Page
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("title")]
    [StringLength(255)]
    public string Title { get; set; } = null!;

    [Column("slug")]
    [StringLength(255)]
    public string Slug { get; set; } = null!;

    [Column("description")]
    [StringLength(255)]
    public string? Description { get; set; }

    [Column("keywords")]
    [StringLength(255)]
    public string? Keywords { get; set; }

    [Column("body", TypeName = "text")]
    public string Body { get; set; } = null!;

    [Column("status", TypeName = "smallint(6)")]
    public short Status { get; set; }

    [Column("created_at", TypeName = "int(11)")]
    public int? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "int(11)")]
    public int? UpdatedAt { get; set; }
}
