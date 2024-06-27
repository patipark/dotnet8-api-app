using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotnetAPIApp.Models;

[Table("user_profile")]
public partial class UserProfile
{
    [Key]
    [Column("user_id", TypeName = "int(11)")]
    public int UserId { get; set; }

    [Column("firstname")]
    [StringLength(255)]
    public string? Firstname { get; set; }

    [Column("lastname")]
    [StringLength(255)]
    public string? Lastname { get; set; }

    [Column("birthday", TypeName = "int(11)")]
    public int? Birthday { get; set; }

    [Column("avatar_path")]
    [StringLength(255)]
    public string? AvatarPath { get; set; }

    [Column("gender", TypeName = "smallint(1)")]
    public short? Gender { get; set; }

    [Column("website")]
    [StringLength(255)]
    public string? Website { get; set; }

    [Column("other")]
    [StringLength(255)]
    public string? Other { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("UserProfile")]
    public virtual User User { get; set; } = null!;
}
