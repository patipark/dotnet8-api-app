using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotnetAPIApp.Models;

[Table("article_category")]
[Index("ParentId", Name = "fk_article_category_section")]
public partial class ArticleCategory
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

    [Column("comment", TypeName = "text")]
    public string? Comment { get; set; }

    [Column("parent_id", TypeName = "int(11)")]
    public int? ParentId { get; set; }

    [Column("status", TypeName = "smallint(6)")]
    public short Status { get; set; }

    [Column("created_at", TypeName = "int(11)")]
    public int? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "int(11)")]
    public int? UpdatedAt { get; set; }

    [InverseProperty("Category")]
    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();

    [InverseProperty("Parent")]
    public virtual ICollection<ArticleCategory> InverseParent { get; set; } = new List<ArticleCategory>();

    [ForeignKey("ParentId")]
    [InverseProperty("InverseParent")]
    public virtual ArticleCategory? Parent { get; set; }
}
