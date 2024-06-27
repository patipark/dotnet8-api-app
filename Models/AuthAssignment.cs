using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotnetAPIApp.Models;

[PrimaryKey("ItemName", "UserId")]
[Table("auth_assignment")]
[Index("UserId", Name = "idx-auth_assignment-user_id")]
public partial class AuthAssignment
{
    [Key]
    [Column("item_name")]
    [StringLength(64)]
    public string ItemName { get; set; } = null!;

    [Key]
    [Column("user_id")]
    [StringLength(64)]
    public string UserId { get; set; } = null!;

    [Column("created_at", TypeName = "int(11)")]
    public int? CreatedAt { get; set; }

    [ForeignKey("ItemName")]
    [InverseProperty("AuthAssignments")]
    public virtual AuthItem ItemNameNavigation { get; set; } = null!;
}
