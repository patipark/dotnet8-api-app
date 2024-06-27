using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotnetAPIApp.Models;

[Table("article")]
[Index("AuthorId", Name = "fk_article_author")]
[Index("CategoryId", Name = "fk_article_category")]
[Index("UpdaterId", Name = "fk_article_updater")]
public partial class Article
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

    [Column("preview", TypeName = "text")]
    public string Preview { get; set; } = null!;

    [Column("body", TypeName = "text")]
    public string Body { get; set; } = null!;

    [Column("status", TypeName = "smallint(6)")]
    public short Status { get; set; }

    [Column("category_id", TypeName = "int(11)")]
    public int? CategoryId { get; set; }

    [Column("author_id", TypeName = "int(11)")]
    public int? AuthorId { get; set; }

    [Column("updater_id", TypeName = "int(11)")]
    public int? UpdaterId { get; set; }

    [Column("published_at", TypeName = "int(11)")]
    public int? PublishedAt { get; set; }

    [Column("created_at", TypeName = "int(11)")]
    public int? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "int(11)")]
    public int? UpdatedAt { get; set; }

    [ForeignKey("AuthorId")]
    [InverseProperty("ArticleAuthors")]
    public virtual User? Author { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Articles")]
    public virtual ArticleCategory? Category { get; set; }

    [ForeignKey("UpdaterId")]
    [InverseProperty("ArticleUpdaters")]
    public virtual User? Updater { get; set; }

    [ForeignKey("ArticleId")]
    [InverseProperty("Articles")]
    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
