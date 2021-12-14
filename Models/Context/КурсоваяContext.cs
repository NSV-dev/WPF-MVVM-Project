using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MVVM1.Models;

#nullable disable

namespace MVVM1.Models.Context
{
    public partial class КурсоваяContext : DbContext
    {
        public КурсоваяContext()
        {
        }

        public КурсоваяContext(DbContextOptions<КурсоваяContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Emp> Emps { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Personality> Personalities { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-O05LV9C\\SQLEXPRESS;Database=Курсовая;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("admin");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");

                entity.Property(e => e.PersonalityId).HasColumnName("personalityID");

                entity.Property(e => e.RoleId).HasColumnName("roleID");

                entity.HasOne(d => d.Personality)
                    .WithMany(p => p.Admins)
                    .HasForeignKey(d => d.PersonalityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_admin_personality");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Admins)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_admin_roles");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("company");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.AdminId).HasColumnName("adminID");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Compname)
                    .IsRequired()
                    .HasColumnName("compname");

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.AdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_company_admin");
            });

            modelBuilder.Entity<Emp>(entity =>
            {
                entity.ToTable("emp");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CompanyId).HasColumnName("companyID");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");

                entity.Property(e => e.PersonalityId).HasColumnName("personalityID");

                entity.Property(e => e.RoleId).HasColumnName("roleID");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Emps)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_emp_company");

                entity.HasOne(d => d.Personality)
                    .WithMany(p => p.Emps)
                    .HasForeignKey(d => d.PersonalityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_emp_personality");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Emps)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_emp_roles");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("gender");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Gender1)
                    .IsRequired()
                    .HasColumnName("gender");
            });

            modelBuilder.Entity<Personality>(entity =>
            {
                entity.ToTable("personality");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address");

                entity.Property(e => e.Dateofbirth)
                    .HasColumnType("date")
                    .HasColumnName("dateofbirth");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname");

                entity.Property(e => e.GenderId).HasColumnName("genderID");

                entity.Property(e => e.Info).HasColumnName("info");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname");

                entity.Property(e => e.Middlename).HasColumnName("middlename");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Personalities)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_personality_gender");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("reports");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.TaskId).HasColumnName("taskID");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reports_tasks");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Role1)
                    .IsRequired()
                    .HasColumnName("role");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("tasks");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.EmpId).HasColumnName("empID");

                entity.Property(e => e.Expired).HasColumnName("expired");

                entity.Property(e => e.Taskname)
                    .IsRequired()
                    .HasColumnName("taskname");

                entity.Property(e => e.Verification).HasColumnName("verification");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tasks_emp");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
