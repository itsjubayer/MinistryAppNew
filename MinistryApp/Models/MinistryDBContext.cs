using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinistryApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MinistryApp.ViewModel;
using Ministry.Models;

namespace MinistryApp.Models
{
    public class MinistryDBContext:IdentityDbContext<ApplicationUser>
    {
        public MinistryDBContext(DbContextOptions<MinistryDBContext> options) : base(options)
        {

        }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        //    {
        //        foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
        //    }
        //}

       
        public DbSet<FileModelVM> FilesList { get; set; }        
        public DbSet<FAQVM> Faqs { get; set; }
        public DbSet<FileCategoryVM> FileCategoryList { get; set; }
        public DbSet<DropDownValuesVM> DropdownValues { get; set; }


        public DbSet<DivisionsVM> DivisionsList { get; set; }
        public DbSet<DistrictsVM> DistrictsList { get; set; }
        public DbSet<UpazilasVM> UpazilasList { get; set; }
        public DbSet<UnionsVM> UnionsList { get; set; }

        /**
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyVM>(entity => {
                entity.HasIndex(e => e.CodeName).IsUnique();
            });

            
            modelBuilder.Entity<CompanyVM>()
                .HasIndex(p => new { p.CompanyShortName, p.LastName })
                .IsUnique(true);
            
           
        }
    */

    }
}
