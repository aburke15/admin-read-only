﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Admin.Data.Models;

namespace Admin.Data.Access
{
    public partial class IrohContext : DbContext
    {
        public IrohContext() { }

        public IrohContext(DbContextOptions<IrohContext> options) : base(options) { }

        public virtual DbSet<FileResource> FileResource { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileResource>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Filename)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}