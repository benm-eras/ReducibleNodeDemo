using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ReducibleNodeDemo
{
    public class Foo
    {
        [Key]
        public int Id { get; set; }

        public ICollection<FooBar> FooBars { get; set; } = new List<FooBar>();
    }

    public class Bar
    {
        [Key]
        public int Id { get; set; }

        public string Value { get; set; }

        public ICollection<FooBar> FooBars { get; set; } = new List<FooBar>();
    }

    public class FooBar
    {
        [Required]
        public int FooId { get; set; }

        [ForeignKey(nameof(FooId))]
        public Foo Foo { get; set; }

        [Required]
        public int BarId { get; set; }

        [ForeignKey(nameof(BarId))]
        public Bar Bar { get; set; }
    }

    public class DataContext : DbContext
    {
        public virtual DbSet<Foo> Foos { get; set; }
        public virtual DbSet<Bar> Bars { get; set; }
        public virtual DbSet<FooBar> FooBars { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FooBar>().HasKey(fb => new { fb.FooId, fb.BarId });

            builder.Entity<Foo>().HasData(
                new Foo() { Id = 1 },
                new Foo() { Id = 2 }
            );

            builder.Entity<Bar>().HasData(
                new Bar() { Id = 3, Value = "Bar3" },
                new Bar() { Id = 4, Value = "Bar4" }
            );

            builder.Entity<FooBar>().HasData(
                new FooBar() { FooId = 1, BarId = 3 },
                new FooBar() { FooId = 1, BarId = 4 },
                new FooBar() { FooId = 2, BarId = 3 },
                new FooBar() { FooId = 2, BarId = 4 }
            );
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
    }
}
