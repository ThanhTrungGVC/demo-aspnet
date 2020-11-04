using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ManagementStudent.Models
{
    public partial class ApplicationdbContext : DbContext
    {
        public ApplicationdbContext()
        {
        }

        public ApplicationdbContext(DbContextOptions<ApplicationdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Point> Point { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=nttrung;password=12345678@Abc;database=demo_php_devolop_student", x => x.ServerVersion("10.4.14-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Point>(entity =>
            {
                entity.ToTable("point");

                entity.HasIndex(e => e.SubjectId)
                    .HasName("SubjectID");

                entity.HasIndex(e => new { e.StudentId, e.SubjectId })
                    .HasName("StudentID")
                    .IsUnique();

                entity.Property(e => e.PointId)
                    .HasColumnName("PointID")
                    .HasComment("ID điểm thi")
                    .ValueGeneratedNever()
                    .HasCollation("utf8_vietnamese_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày tạo");

                entity.Property(e => e.EndPoint).HasComment("Điểm thi cuối kỳ");

                entity.Property(e => e.ModifideDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày sửa");

                entity.Property(e => e.PracticePoint).HasComment("Điểm thực hành");

                entity.Property(e => e.StudentId)
                    .HasColumnName("StudentID")
                    .HasComment("ID sinh viên")
                    .HasCollation("utf8_vietnamese_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.SubjectId)
                    .HasColumnName("SubjectID")
                    .HasComment("ID môn học")
                    .HasCollation("utf8_vietnamese_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Term)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasComment("Kỳ học")
                    .HasCollation("utf8_vietnamese_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Point)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("point_ibfk_1");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Point)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("point_ibfk_2");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");

                entity.Property(e => e.StudentId)
                    .HasColumnName("StudentID")
                    .HasComment("ID sinh viên")
                    .ValueGeneratedNever()
                    .HasCollation("utf8_vietnamese_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("Địa chỉ")
                    .HasCollation("utf8_vietnamese_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasComment("Ngày sinh");

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasComment("Tên lớp học")
                    .HasCollation("utf8_vietnamese_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày tạo");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasComment("Địa chỉ Email")
                    .HasCollation("utf8_vietnamese_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Faculty)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasComment("Khoa")
                    .HasCollation("utf8_vietnamese_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasComment("Họ đệm")
                    .HasCollation("utf8_vietnamese_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasComment("Họ và tên")
                    .HasCollation("utf8_vietnamese_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Gender)
                    .HasColumnType("int(1)")
                    .HasComment("Giới tính (0-nữ; 1 - nam; 2 - khác)");

                entity.Property(e => e.Gpa)
                    .HasColumnName("GPA")
                    .HasComment("Trung bình tích luỹ");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasComment("Tên")
                    .HasCollation("utf8_vietnamese_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ModifideDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày sửa đổi");

                entity.Property(e => e.StudentCode)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    .HasComment("Mã sinh viên")
                    .HasCollation("utf8_vietnamese_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("subject");

                entity.Property(e => e.SubjectId)
                    .HasColumnName("SubjectID")
                    .HasComment("ID môn học")
                    .ValueGeneratedNever()
                    .HasCollation("utf8_vietnamese_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày tạo");

                entity.Property(e => e.Credit)
                    .HasColumnType("int(11)")
                    .HasComment("Số tín chỉ");

                entity.Property(e => e.ModifideDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày sửa");

                entity.Property(e => e.SubjectCode)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasComment("Mã môn học")
                    .HasCollation("utf8_vietnamese_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.SubjectName)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasComment("Tên môn học")
                    .HasCollation("utf8_vietnamese_ci")
                    .HasCharSet("utf8");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
