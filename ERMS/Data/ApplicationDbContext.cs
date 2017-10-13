using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ERMS.Models;

namespace ERMS.Data
{
    // dotnet ef database update
    // dotnet ef migrations add
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
            public DbSet<Person> Persons { get; set; }
            public DbSet<Employee> Employees { get; set; }
            public DbSet<Department> Departments { get; set; }
            public DbSet<Division> Divisions { get; set; }
            public DbSet<Section> Sections { get; set; }
            public DbSet<Office> Offices { get; set; }
            public DbSet<Designation> Designations { get; set; }
            public DbSet<Position> Positions { get; set; }
            public DbSet<EmployeePosition> EmployeePositions { get; set; }
            public DbSet<EmployeeOffice> EmployeeOffices { get; set; }
            public DbSet<EmployeeDepartment> EmployeeDepartment { get; set; }
            public DbSet<EmployeeDesignation> EmployeeDesignations { get; set; }
            public DbSet<OfficeCode> OfficeCodes { get; set; }
            public DbSet<DocumentType> DocumentTypes { get; set; }
            public DbSet<Box> Boxes { get; set; }
            public DbSet<Document> Documents { get; set; }
            public DbSet<LetterType> LetterTypes { get; set; }
            public DbSet<Sender> Sender { get; set; }
            public DbSet<Letter> Letters { get; set; }

            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {

            }

            protected override void OnModelCreating(ModelBuilder builder)
            {
                // Indexes
                // Required
                // Unique
                // Timestamp
                // RelationShip

                //Person
                builder.Entity<Person>(entity => {
                    // Indexes 

                    // Required
                    entity.Property(p => p.FirstName)
                        .IsRequired();
                    entity.Property(p => p.MiddleInitial)
                        .IsRequired();
                    entity.Property(p => p.LastName)
                        .IsRequired();
                    // Unique
                    entity.HasIndex(p => new { p.Title, p.FirstName, p.MiddleInitial, p.LastName, p.Suffix })
                        .HasName("UIX_Persons_FullName");
                    // TimeStamp
                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");
                    // RelationShips
                });

                //Employee
                builder.Entity<Employee>(entity =>
                {
                    // Indexes
                    entity.HasIndex(p => p.PersonId)
                        .HasName("IX_Employees_PersonId");
                    // RelationShip
                    entity.HasOne(p => p.Person)
                        .WithOne(p => p.Employee)
                        .HasForeignKey<Employee>(p => p.PersonId)
                        .OnDelete(DeleteBehavior.Restrict);
                    // Timestamp
                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");
                });

                //Department
                builder.Entity<Department>(entity =>
                {
                    // Required
                    entity.Property(p => p.Name)
                        .IsRequired();
                    // Unique
                    entity.HasIndex(p => p.Name)
                        .HasName("UIX_Departments_Name")
                        .IsUnique();
                    // TimeStamp
                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");

                });

                //Division
                builder.Entity<Division>(entity =>
                {
                    // Required
                    entity.Property(p => p.Name)
                        .IsRequired();
                    // Unique
                    entity.HasIndex(p => p.Name)
                        .HasName("UIX_Divisions_Name")
                        .IsUnique();
                    // TimeStamp
                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");
                });

                //Section
                builder.Entity<Section>(entity =>
                {
                    // Indexes
                    // Required
                    entity.Property(p => p.Name)
                        .IsRequired();

                    // Unique
                    entity.HasIndex(p => p.Name)
                        .HasName("UIX_Sections_Name")
                        .IsUnique();
                    // Timestamp
                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");
                    // RelationShip
                });

                //Designation
                builder.Entity<Designation>(entity =>
                {
                    // Indexes
                    // Required
                    entity.Property(p => p.Name)
                        .IsRequired();
                    // Unique
                    entity.HasIndex(p => p.Name)
                        .HasName("UIX_Designations_Name")
                        .IsUnique();
                    // Timestamp
                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");
                    // RelationShip
                });

                //EmployeePosition
                builder.Entity<EmployeePosition>(entity => {
                    // Indexes
                    entity.HasIndex(p => p.EmployeeId)
                        .HasName("IX_EmployeePositions_EmployeeId");
                    entity.HasIndex(p => p.PositionId)
                        .HasName("IX_EmployeePositions_PositionId");
                    // Required
                    entity.Property(p => p.StartDate)
                        .IsRequired();
                    entity.Property(p => p.EndDate)
                        .IsRequired();
                    // TimeStamp
                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");
                    // RelationShips
                    entity.HasOne(p => p.Employee)
                        .WithMany(p => p.EmployeePositions)
                        .HasForeignKey(p => p.EmployeeId)
                        .OnDelete(DeleteBehavior.Restrict);
                    entity.HasOne(p => p.Position)
                        .WithMany(p => p.EmployeePositions)
                        .HasForeignKey(p => p.PositionId)
                        .OnDelete(DeleteBehavior.Restrict);

                });

                //EmployeeOffice
                builder.Entity<EmployeeOffice>(entity =>
                {
                    // Indexes

                    // Required
                    // Unique
                    // Timestamp
                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");
                    // RelationShip
                    entity.HasOne(p => p.EmployeePosition)
                        .WithOne(p => p.EmployeeOffice)
                        .HasForeignKey<EmployeeOffice>(p => p.EmployeePositionId)
                        .OnDelete(DeleteBehavior.Restrict);
                    entity.HasOne(p => p.Office)
                        .WithMany(p => p.EmployeeOffices)
                        .HasForeignKey(p => p.OfficeId)
                        .OnDelete(DeleteBehavior.Restrict);

                });

                //EmployeeDepartment
                builder.Entity<EmployeeDepartment>(entity =>
                {
                    // Indexes
                    // Required
                    // Unique
                    // Timestamp
                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");
                    // RelationShip       
                    entity.HasOne(p => p.Department)
                        .WithMany(p => p.EmployeeDepartments)
                        .HasForeignKey(p => p.DepartmentId)
                        .OnDelete(DeleteBehavior.Restrict);
                    entity.HasOne(p => p.EmployeePosition)
                        .WithOne(p => p.EmployeeDepartment)
                        .HasForeignKey<EmployeeDepartment>(p => p.EmployeePositionId)
                        .OnDelete(DeleteBehavior.Restrict);
                });

                //EmployeeDesignations
                builder.Entity<EmployeeDesignation>(entity =>
                {
                    // Indexes
                    // Required
                    // Unique
                    // Timestamp
                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");
                    // RelationShip
                    entity.HasOne(p => p.Designation)
                        .WithMany(p => p.EmployeeDesignations)
                        .HasForeignKey(p => p.DesignationId)
                        .OnDelete(DeleteBehavior.Restrict);
                    entity.HasOne(p => p.EmployeeOffice)
                        .WithMany(p => p.EmployeeDesignations)
                        .HasForeignKey(p => p.EmployeeOfficeId)
                        .OnDelete(DeleteBehavior.Restrict);
                });

                //Office
                builder.Entity<Office>(entity =>
                {
                    // Indexes
                    // Required
                    // Unique
                    entity.HasIndex(p => new { p.DepartmentId, p.DivisionId, p.SectionId })
                         .HasName("UIX_DepDivSec")
                         .IsUnique();
                    entity.HasIndex(p => new { p.DepartmentId, p.DivisionId, p.SectionId })
                         .HasName("UIX_DepDiv")
                         .HasFilter("[SectionId] IS NULL")
                         .IsUnique();

                    entity.HasIndex(p => new { p.DepartmentId, p.DivisionId, p.SectionId })
                         .HasName("UIX_DepSec")
                         .HasFilter("[DivisionId] IS NULL")
                         .IsUnique();
                    // Timestamp
                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");
                    // RelationShip           
                    entity.HasOne(p => p.Department)
                        .WithMany(p => p.Offices)
                        .HasForeignKey(p => p.DepartmentId)
                        .OnDelete(DeleteBehavior.Restrict);
                    entity.HasOne(p => p.Division)
                        .WithMany(p => p.Offices)
                        .HasForeignKey(p => p.DivisionId)
                        .OnDelete(DeleteBehavior.Restrict);
                    entity.HasOne(p => p.Section)
                        .WithMany(p => p.Offices)
                        .HasForeignKey(p => p.SectionId)
                        .OnDelete(DeleteBehavior.Restrict);
                });

                //OfficeCode
                builder.Entity<OfficeCode>(entity =>
                {
                    // Indexes
                    // Required
                    entity.Property(p => p.Code)
                        .IsRequired();
                    // Unique
                    entity.HasIndex(p => p.Code)
                        .HasName("UIX_OfficeCodes_Code")
                        .IsUnique();
                    // Timestamp
                    // RelationShip
                    entity.HasOne(p => p.Office)
                        .WithOne(p => p.OfficeCode)
                        .HasForeignKey<OfficeCode>(p => p.OfficeId)
                        .OnDelete(DeleteBehavior.Restrict);
                });

                //DocumentType
                builder.Entity<DocumentType>(entity =>
                {
                    // Indexes
                    // Required
                    entity.Property(p => p.Title)
                        .IsRequired();
                    // Unique
                    entity.HasIndex(p => p.Title)
                        .HasName("UIX_DocumentTypes_Title")
                        .IsUnique();
                    // Timestamp
                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");
                    // RelationShip
                });

                //Box
                builder.Entity<Box>(entity =>
                {
                    // Indexes
                    // Required
                    entity.Property(p => p.ControlNumber)
                        .IsRequired();
                    // Unique
                    entity.HasIndex(p => p.ControlNumber)
                        .HasName("UIX_Boxes_controlNumber")
                        .IsUnique();
                    // Timestamp
                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");
                    // RelationShip
                    entity.HasOne(p => p.Office)
                        .WithMany(p => p.Boxes)
                        .HasForeignKey(p => p.OfficeId)
                        .OnDelete(DeleteBehavior.Restrict);
                });

                //Document
                builder.Entity<Document>(entity =>
                {
                    // Indexes
                    // Required
                    entity.Property(p => p.DocumentNumber)
                        .IsRequired();
                    // Unique
                    // Timestamp
                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");
                    // RelationShip              
                });

                //LetterType
                builder.Entity<LetterType>(entity =>
                {
                    // Indexes
                    // Required
                    entity.Property(p => p.Name)
                        .IsRequired();
                    // Unique
                    entity.HasIndex(p => p.Name)
                        .HasName("IX_LetterTypes_Name")
                        .IsUnique();
                    // Timestamp
                    // RelationShip               
                });

                //Sender
                builder.Entity<Sender>(entity => {
                    // Indexes
                    // Required
                    entity.Property(p => p.Name)
                        .IsRequired();
                    entity.Property(p => p.Address)
                        .IsRequired();
                    // Unique
                    entity.HasIndex(p => p.Name)
                        .HasName("UIX_Senders_Name")
                        .IsUnique();
                    // Timestamp
                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");
                    // RelationShip
                });

                //Letter
                builder.Entity<Letter>(entity => {
                    // Indexes
                    // Required
                    entity.Property(p => p.Title)
                        .IsRequired();
                    // Unique
                    entity.HasIndex(p => p.Title)
                        .HasName("UIX_Letters_Title")
                        .IsUnique();
                    // Timestamp
                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");
                    // RelationShip         
                    entity.HasOne(p => p.LetterType)
                        .WithMany(p => p.Letters)
                        .HasForeignKey(p => p.LetterTypeId)
                        .OnDelete(DeleteBehavior.Restrict);
                    entity.HasOne(p => p.Sender)
                        .WithMany(p => p.Letters)
                        .HasForeignKey(p => p.SenderId)
                        .OnDelete(DeleteBehavior.Restrict);
                });


                base.OnModelCreating(builder);
                // Customize the ASP.NET Identity model and override the defaults if needed.
                // For example, you can rename the ASP.NET Identity table names and more.
                // Add your customizations after calling base.OnModelCreating(builder);
            }
        
    }
}

