using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotnetAPIApp.Models;

[Table("key_storage_item")]
[Index("Key", Name = "idx_key_storage_item_key", IsUnique = true)]
public partial class KeyStorageItem
{
    [Key]
    [Column("key")]
    [StringLength(128)]
    public string Key { get; set; } = null!;

    [Column("value", TypeName = "text")]
    public string Value { get; set; } = null!;

    [Column("comment", TypeName = "text")]
    public string? Comment { get; set; }
}
