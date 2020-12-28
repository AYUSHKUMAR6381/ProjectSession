using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApplication26.Models;

#nullable disable

namespace WebApplication26.Models
{
    public partial class project1211Context : DbContext
    {
        public project1211Context()
        {
        }

        public project1211Context(DbContextOptions<project1211Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminDetail> AdminDetails { get; set; }
        public virtual DbSet<AttendanceDetail> AttendanceDetails { get; set; }
        public virtual DbSet<FacultyDetail> FacultyDetails { get; set; }
        public virtual DbSet<MarksDetail> MarksDetails { get; set; }
        public virtual DbSet<MstDepartment> MstDepartments { get; set; }
        public virtual DbSet<MstRole> MstRoles { get; set; }
        public virtual DbSet<MstSemester> MstSemesters { get; set; }
        public virtual DbSet<MstSubject> MstSubjects { get; set; }
        public virtual DbSet<MstUser> MstUsers { get; set; }
        public virtual DbSet<StudentDetail> StudentDetails { get; set; }
        public virtual DbSet<Logincs> Login { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=LAPTOP-1KL3BT26;database=project1211;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminDetail>(entity =>
            {
                entity.HasKey(e => e.PkAdminId)
                    .HasName("PK__Admin_De__A4C6D34023A15061");

                entity.ToTable("Admin_Detail", "SMS");

                entity.HasIndex(e => e.Email, "UQ__Admin_De__A9D10534F498B348")
                    .IsUnique();

                entity.HasIndex(e => e.Contact, "UQ__Admin_De__F7C046650F0B899E")
                    .IsUnique();

                entity.Property(e => e.PkAdminId).HasColumnName("Pk_Admin_ID");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_Of_Birth");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(100)
                    .HasColumnName("Employee_ID");

                entity.Property(e => e.FatherName)
                    .HasMaxLength(50)
                    .HasColumnName("Father_Name");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("First_Name");

                entity.Property(e => e.IsActive)
                    .HasColumnName("Is_Active")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("Is_Deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.Pswd)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<AttendanceDetail>(entity =>
            {
                entity.HasKey(e => e.PkAttndId)
                    .HasName("PK__Attendan__FC0A18E4283AE0A7");

                entity.ToTable("Attendance_Detail", "SMS");

                entity.Property(e => e.PkAttndId).HasColumnName("Pk_Attnd_ID");

                entity.Property(e => e.Attendance)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('Absent')");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.FkStudId).HasColumnName("Fk_Stud_ID");

                entity.HasOne(d => d.FkStud)
                    .WithMany(p => p.AttendanceDetails)
                    .HasForeignKey(d => d.FkStudId)
                    .HasConstraintName("FK__Attendanc__Fk_St__4CA06362");
            });

            modelBuilder.Entity<FacultyDetail>(entity =>
            {
                entity.HasKey(e => e.PkFacultyId)
                    .HasName("PK__Faculty___CE576E845A20BE37");

                entity.ToTable("Faculty_Detail", "SMS");

                entity.HasIndex(e => e.Email, "UQ__Faculty___A9D10534DFF853D1")
                    .IsUnique();

                entity.HasIndex(e => e.Contact, "UQ__Faculty___F7C046659383FB11")
                    .IsUnique();

                entity.Property(e => e.PkFacultyId).HasColumnName("Pk_Faculty_ID");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_Of_Birth");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.FacultyId)
                    .HasMaxLength(100)
                    .HasColumnName("Faculty_ID");

                entity.Property(e => e.FatherName)
                    .HasMaxLength(50)
                    .HasColumnName("Father_Name");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("First_Name");

                entity.Property(e => e.FkDeptId).HasColumnName("Fk_Dept_ID");

                entity.Property(e => e.IsActive)
                    .HasColumnName("Is_Active")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("Is_Deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.Pswd)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.FkDept)
                    .WithMany(p => p.FacultyDetails)
                    .HasForeignKey(d => d.FkDeptId)
                    .HasConstraintName("FK__Faculty_D__Fk_De__4D94879B");
            });

            modelBuilder.Entity<MarksDetail>(entity =>
            {
                entity.HasKey(e => e.PkMarksId)
                    .HasName("PK__Marks_De__5135A2BFDAC985A7");

                entity.ToTable("Marks_Detail", "SMS");

                entity.Property(e => e.PkMarksId).HasColumnName("Pk_Marks_ID");

                entity.Property(e => e.FkSemId).HasColumnName("Fk_Sem_ID");

                entity.Property(e => e.FkStudId).HasColumnName("Fk_Stud_ID");

                entity.Property(e => e.FkSubId).HasColumnName("Fk_Sub_ID");

                entity.Property(e => e.MainExamMarks).HasColumnName("MainExam_Marks");

                entity.Property(e => e.SessionalMarks).HasColumnName("Sessional_Marks");

                entity.Property(e => e.TotalMarks).HasColumnName("Total_Marks");

                entity.HasOne(d => d.FkSem)
                    .WithMany(p => p.MarksDetails)
                    .HasForeignKey(d => d.FkSemId)
                    .HasConstraintName("FK__Marks_Det__Fk_Se__4E88ABD4");

                entity.HasOne(d => d.FkStud)
                    .WithMany(p => p.MarksDetails)
                    .HasForeignKey(d => d.FkStudId)
                    .HasConstraintName("FK__Marks_Det__Fk_St__4F7CD00D");

                entity.HasOne(d => d.FkSub)
                    .WithMany(p => p.MarksDetails)
                    .HasForeignKey(d => d.FkSubId)
                    .HasConstraintName("FK__Marks_Det__Fk_Su__5070F446");
            });

            modelBuilder.Entity<MstDepartment>(entity =>
            {
                entity.HasKey(e => e.PkDeptId)
                    .HasName("PK__Mst_Depa__CA4F3935D58E706D");

                entity.ToTable("Mst_Department", "SMS");

                entity.Property(e => e.PkDeptId).HasColumnName("Pk_Dept_ID");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(20)
                    .HasColumnName("Department_Name");

                entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            });

            modelBuilder.Entity<MstRole>(entity =>
            {
                entity.HasKey(e => e.PkRoleId)
                    .HasName("PK__Mst_Role__A393625A08C3081C");

                entity.ToTable("Mst_Role", "SMS");

                entity.Property(e => e.PkRoleId).HasColumnName("Pk_Role_ID");

                entity.Property(e => e.IsActive).HasColumnName("Is_Active");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(20)
                    .HasColumnName("Role_Name");
            });

            modelBuilder.Entity<MstSemester>(entity =>
            {
                entity.HasKey(e => e.PkSemId)
                    .HasName("PK__Mst_Seme__971F5D22AB691362");

                entity.ToTable("Mst_Semester", "SMS");

                entity.Property(e => e.PkSemId).HasColumnName("Pk_Sem_ID");

                entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            });

            modelBuilder.Entity<MstSubject>(entity =>
            {
                entity.HasKey(e => e.PkSubjectId)
                    .HasName("PK__Mst_Subj__7C88CB222FDB1FC7");

                entity.ToTable("Mst_Subject", "SMS");

                entity.Property(e => e.PkSubjectId).HasColumnName("Pk_Subject_ID");

                entity.Property(e => e.FkSemId).HasColumnName("Fk_Sem_ID");

                entity.Property(e => e.IsActive).HasColumnName("Is_Active");

                entity.Property(e => e.SubjectName)
                    .HasMaxLength(50)
                    .HasColumnName("Subject_Name");

                entity.HasOne(d => d.FkSem)
                    .WithMany(p => p.MstSubjects)
                    .HasForeignKey(d => d.FkSemId)
                    .HasConstraintName("FK__Mst_Subje__Fk_Se__5165187F");
            });

            modelBuilder.Entity<MstUser>(entity =>
            {
                entity.HasKey(e => e.PkUserId)
                    .HasName("PK__Mst_User__CFD5DA40034FEB5C");

                entity.ToTable("Mst_User", "SMS");

                entity.HasIndex(e => e.Email, "UQ__Mst_User__A9D10534256FB304")
                    .IsUnique();

                entity.HasIndex(e => e.Contact, "UQ__Mst_User__F7C04665D29B4367")
                    .IsUnique();

                entity.Property(e => e.PkUserId).HasColumnName("Pk_User_ID");

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.FkRoleId).HasColumnName("Fk_Role_ID");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("FName");

                entity.Property(e => e.IsActive)
                    .HasColumnName("Is_Active")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("Is_Deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("LName");

                entity.Property(e => e.Pswd)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<StudentDetail>(entity =>
            {
                entity.HasKey(e => e.PkStudentId)
                    .HasName("PK__Student___62F8E085C1AD5D93");

                entity.ToTable("Student_Detail", "SMS");

                entity.HasIndex(e => e.Email, "UQ__Student___A9D105342F7E1A8E")
                    .IsUnique();

                entity.HasIndex(e => e.Contact, "UQ__Student___F7C04665CA2213D0")
                    .IsUnique();

                entity.Property(e => e.PkStudentId).HasColumnName("Pk_Student_ID");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Course).HasMaxLength(20);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_Of_Birth");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.EnrollId)
                    .HasMaxLength(100)
                    .HasColumnName("Enroll_ID");

                entity.Property(e => e.FatherName)
                    .HasMaxLength(50)
                    .HasColumnName("Father_Name");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("First_Name");

                entity.Property(e => e.IsActive)
                    .HasColumnName("Is_Active")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("Is_Deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.Pswd)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<WebApplication26.Models.Logincs> Logincs { get; set; }
    }
}
