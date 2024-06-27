using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotnetAPIApp.Models;

[Table("tag")]
public partial class Tag
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("frequency", TypeName = "int(11)")]
    public int Frequency { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [Column("slug")]
    [StringLength(255)]
    public string Slug { get; set; } = null!;

    [Column("comment", TypeName = "text")]
    public string? Comment { get; set; }

    [ForeignKey("TagId")]
    [InverseProperty("Tags")]
    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
}
