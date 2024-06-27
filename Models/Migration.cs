using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotnetAPIApp.Models;

[Table("migration")]
public partial class Migration
{
    [Key]
    [Column("version")]
    [StringLength(180)]
    public string Version { get; set; } = null!;

    [Column("apply_time", TypeName = "int(11)")]
    public int? ApplyTime { get; set; }
}
