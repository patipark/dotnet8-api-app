using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotnetAPIApp.Models;

[Table("user")]
public partial class User
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("username")]
    [StringLength(255)]
    public string Username { get; set; } = null!;

    [Column("auth_key")]
    [StringLength(32)]
    public string AuthKey { get; set; } = null!;

    [Column("access_token")]
    [StringLength(255)]
    public string? AccessToken { get; set; }

    [Column("password_hash")]
    [StringLength(255)]
    public string PasswordHash { get; set; } = null!;

    [Column("email")]
    [StringLength(255)]
    public string Email { get; set; } = null!;

    [Column("status", TypeName = "smallint(6)")]
    public short Status { get; set; }

    [Column("ip")]
    [StringLength(128)]
    public string? Ip { get; set; }

    [Column("created_at", TypeName = "int(11)")]
    public int? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "int(11)")]
    public int? UpdatedAt { get; set; }

    [Column("action_at", TypeName = "int(11)")]
    public int? ActionAt { get; set; }

    [InverseProperty("Author")]
    public virtual ICollection<Article> ArticleAuthors { get; set; } = new List<Article>();

    [InverseProperty("Updater")]
    public virtual ICollection<Article> ArticleUpdaters { get; set; } = new List<Article>();

    [InverseProperty("User")]
    public virtual UserProfile? UserProfile { get; set; }
}
