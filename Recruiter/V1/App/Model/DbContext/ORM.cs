using Microsoft.EntityFrameworkCore;
using Models.SkillSets;
using QandAApi.Models;
using CandidateModel.Models;
using Models.Recruiter;

public class TableContext : DbContext
    {
        
        public TableContext(DbContextOptions<TableContext> options)
            : base(options)
        {
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<SkillSet> SkillSets { get; set; }
        public DbSet<ResourceRequisition> ResourceRequisitions { get; set; }
         public DbSet<MyCandidate> MyCandidates { get; set; }
    }    
