using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CurriculumVitae.Models;
using CurriculumVitae.Models;
namespace CurriculumVitae.Data
{
    public class CurriculumVitaeContext : DbContext
    {
        internal static readonly object ExamScores;

        public CurriculumVitaeContext (DbContextOptions<CurriculumVitaeContext> options)
            : base(options)
        {
        }

        public DbSet<CurriculumVitae.Models.Student> Student { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<CurriculumVitae.Models.ExamScore>? ExamScore { get; set; }

        public DbSet<CurriculumVitae.Models.ClassContact>? ClassContact { get; set; }
       
    }
}
