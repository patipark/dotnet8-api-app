//using System;
//using System.Collections.Generic;
using DotnetAPIApp.Models;
using Microsoft.EntityFrameworkCore;


namespace DotnetAPIApp.Data;

public partial class MySQLDbContext : DbContext
{
    private IConfiguration _configuration;
    //public MySQLDbContext(IConfiguration configuration)
    //{
    //    _configuration = configuration;
    //}

    public MySQLDbContext(DbContextOptions<MySQLDbContext> options , IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<ArticleCategory> ArticleCategories { get; set; }

    public virtual DbSet<AuthAssignment> AuthAssignments { get; set; }

    public virtual DbSet<AuthItem> AuthItems { get; set; }

    public virtual DbSet<AuthRule> AuthRules { get; set; }

    public virtual DbSet<KeyStorageItem> KeyStorageItems { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Migration> Migrations { get; set; }

    public virtual DbSet<NavbarMenu> NavbarMenus { get; set; }

    public virtual DbSet<Page> Pages { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL(_configuration.GetConnectionString("MySQLConnectionString")!);


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.AuthorId).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.CategoryId).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Description).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Keywords).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.PublishedAt).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.UpdaterId).HasDefaultValueSql("'NULL'");

            entity.HasOne(d => d.Author).WithMany(p => p.ArticleAuthors)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_article_author");

            entity.HasOne(d => d.Category).WithMany(p => p.Articles)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_article_category");

            entity.HasOne(d => d.Updater).WithMany(p => p.ArticleUpdaters)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_article_updater");

            entity.HasMany(d => d.Tags).WithMany(p => p.Articles)
                .UsingEntity<Dictionary<string, object>>(
                    "ArticleTag",
                    r => r.HasOne<Tag>().WithMany()
                        .HasForeignKey("TagId")
                        .HasConstraintName("fk_tag-tag_id-tag-id"),
                    l => l.HasOne<Article>().WithMany()
                        .HasForeignKey("ArticleId")
                        .HasConstraintName("fk_tag-article_id-article-id"),
                    j =>
                    {
                        j.HasKey("ArticleId", "TagId").HasName("PRIMARY");
                        j.ToTable("article_tag");
                        j.HasIndex(new[] { "TagId" }, "fk_tag-tag_id-tag-id");
                        j.IndexerProperty<int>("ArticleId")
                            .HasColumnType("int(11)")
                            .HasColumnName("article_id");
                        j.IndexerProperty<int>("TagId")
                            .HasColumnType("int(11)")
                            .HasColumnName("tag_id");
                    });
        });

        modelBuilder.Entity<ArticleCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Comment).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.ParentId).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("'NULL'");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_article_category_section");
        });

        modelBuilder.Entity<AuthAssignment>(entity =>
        {
            entity.HasKey(e => new { e.ItemName, e.UserId }).HasName("PRIMARY");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("'NULL'");

            entity.HasOne(d => d.ItemNameNavigation).WithMany(p => p.AuthAssignments).HasConstraintName("auth_assignment_ibfk_1");
        });

        modelBuilder.Entity<AuthItem>(entity =>
        {
            entity.HasKey(e => e.Name).HasName("PRIMARY");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Data).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Description).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.RuleName).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("'NULL'");

            entity.HasOne(d => d.RuleNameNavigation).WithMany(p => p.AuthItems)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("auth_item_ibfk_1");

            entity.HasMany(d => d.Children).WithMany(p => p.Parents)
                .UsingEntity<Dictionary<string, object>>(
                    "AuthItemChild",
                    r => r.HasOne<AuthItem>().WithMany()
                        .HasForeignKey("Child")
                        .HasConstraintName("auth_item_child_ibfk_2"),
                    l => l.HasOne<AuthItem>().WithMany()
                        .HasForeignKey("Parent")
                        .HasConstraintName("auth_item_child_ibfk_1"),
                    j =>
                    {
                        j.HasKey("Parent", "Child").HasName("PRIMARY");
                        j.ToTable("auth_item_child");
                        j.HasIndex(new[] { "Child" }, "child");
                        j.IndexerProperty<string>("Parent")
                            .HasMaxLength(64)
                            .HasColumnName("parent");
                        j.IndexerProperty<string>("Child")
                            .HasMaxLength(64)
                            .HasColumnName("child");
                    });

            entity.HasMany(d => d.Parents).WithMany(p => p.Children)
                .UsingEntity<Dictionary<string, object>>(
                    "AuthItemChild",
                    r => r.HasOne<AuthItem>().WithMany()
                        .HasForeignKey("Parent")
                        .HasConstraintName("auth_item_child_ibfk_1"),
                    l => l.HasOne<AuthItem>().WithMany()
                        .HasForeignKey("Child")
                        .HasConstraintName("auth_item_child_ibfk_2"),
                    j =>
                    {
                        j.HasKey("Parent", "Child").HasName("PRIMARY");
                        j.ToTable("auth_item_child");
                        j.HasIndex(new[] { "Child" }, "child");
                        j.IndexerProperty<string>("Parent")
                            .HasMaxLength(64)
                            .HasColumnName("parent");
                        j.IndexerProperty<string>("Child")
                            .HasMaxLength(64)
                            .HasColumnName("child");
                    });
        });

        modelBuilder.Entity<AuthRule>(entity =>
        {
            entity.HasKey(e => e.Name).HasName("PRIMARY");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Data).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("'NULL'");
        });

        modelBuilder.Entity<KeyStorageItem>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("PRIMARY");

            entity.Property(e => e.Comment).HasDefaultValueSql("'NULL'");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Category).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Level).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.LogTime).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Message).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Prefix).HasDefaultValueSql("'NULL'");
        });

        modelBuilder.Entity<Migration>(entity =>
        {
            entity.HasKey(e => e.Version).HasName("PRIMARY");

            entity.Property(e => e.ApplyTime).HasDefaultValueSql("'NULL'");
        });

        modelBuilder.Entity<NavbarMenu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.ParentId).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.SortIndex).HasDefaultValueSql("'NULL'");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("parent");
        });

        modelBuilder.Entity<Page>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Description).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Keywords).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("'NULL'");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Comment).HasDefaultValueSql("'NULL'");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.AccessToken).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.ActionAt).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Ip).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("'NULL'");
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.Property(e => e.UserId).ValueGeneratedOnAdd();
            entity.Property(e => e.AvatarPath).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Birthday).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Firstname).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Gender).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Lastname).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Other).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Website).HasDefaultValueSql("'NULL'");

            entity.HasOne(d => d.User).WithOne(p => p.UserProfile).HasConstraintName("fk_user");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
