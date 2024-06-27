using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotnetAPIApp.Models;

[Table("log")]
[Index("Category", Name = "idx_log_category")]
[Index("Level", Name = "idx_log_level")]
public partial class Log
{
    [Key]
    [Column("id", TypeName = "bigint(20)")]
    public long Id { get; set; }

    [Column("level", TypeName = "int(11)")]
    public int? Level { get; set; }

    [Column("category")]
    public string? Category { get; set; }

    [Column("log_time")]
    public double? LogTime { get; set; }

    [Column("prefix", TypeName = "text")]
    public string? Prefix { get; set; }

    [Column("message", TypeName = "text")]
    public string? Message { get; set; }
}
