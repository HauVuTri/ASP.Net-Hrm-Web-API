using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HRMAspNet.Models
{
    public partial class HRMContext : DbContext
    {
        public HRMContext()
        {
        }

        public HRMContext(DbContextOptions<HRMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aministrativearea> Aministrativearea { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Employeedetail> Employeedetail { get; set; }
        public virtual DbSet<Nationality> Nationality { get; set; }
        public virtual DbSet<Provincial> Provincial { get; set; }
        public virtual DbSet<Rollcall> Rollcall { get; set; }
        public virtual DbSet<Timekeeping> Timekeeping { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=3306;database=huho_develop;user=root", x => x.ServerVersion("10.4.18-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aministrativearea>(entity =>
            {
                entity.HasKey(e => e.AdministrativeAreaId)
                    .HasName("PRIMARY");

                entity.ToTable("aministrativearea");

                entity.Property(e => e.AdministrativeAreaId)
                    .HasColumnName("AdministrativeAreaID")
                    .ValueGeneratedNever()
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AdministrativeAreaCode)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DistrictCode)
                    .HasColumnType("int(11)")
                    .HasComment("mã quận/ huyện");

                entity.Property(e => e.DistrictName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("tên quận huyện")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProvincialCode)
                    .HasColumnType("int(11)")
                    .HasComment("mã tỉnh");

                entity.Property(e => e.ProvincialName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("tên tỉnh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.WardCode)
                    .HasColumnType("int(11)")
                    .HasComment("mã xã");

                entity.Property(e => e.WardName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("tên xã")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .ValueGeneratedNever()
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BirthDay)
                    .HasColumnType("varchar(255)")
                    .HasComment("Ngày sinh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ContractTypeName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên loại hợp đồng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmployeeCode)
                    .HasColumnType("varchar(255)")
                    .HasComment("mã lao động")
                    .HasCharSet("armscii8")
                    .HasCollation("armscii8_general_ci");

                entity.Property(e => e.EmployeeStatusId)
                    .HasColumnName("EmployeeStatusID")
                    .HasColumnType("int(11)")
                    .HasComment("ID trạng thái lao động");

                entity.Property(e => e.EmployeeStatusName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên trạng thái lao động")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FullName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên đầy đủ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Gender)
                    .HasColumnType("int(11)")
                    .HasComment(@"Giới tính:
0:nữ
1:Nam");

                entity.Property(e => e.HeallthnsuranceNumber)
                    .HasColumnType("varchar(45)")
                    .HasComment("Số bảo hiểm y tế")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HireDate)
                    .HasColumnType("varchar(255)")
                    .HasComment("Ngày thuê")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.InsuranceRate)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tỷ lệ đóng bhxh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.JobPositionId)
                    .HasColumnName("JobPositionID")
                    .HasColumnType("int(11)")
                    .HasComment("ID vị trí");

                entity.Property(e => e.JobPositionName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên vị trí")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Mobile)
                    .HasColumnType("varchar(255)")
                    .HasComment("Số đt")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OfficeEmail)
                    .HasColumnType("varchar(255)")
                    .HasComment("Địa chỉ email")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ReceiveDate)
                    .HasColumnType("varchar(255)")
                    .HasComment("Ngày nhận")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SocialInsuranceCode)
                    .HasColumnType("varchar(255)")
                    .HasComment("Mã BHXH")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SocialInsuranceNumber)
                    .HasColumnType("varchar(255)")
                    .HasComment("Số BHXH")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StatusId)
                    .HasColumnName("StatusID")
                    .HasColumnType("int(11)")
                    .HasComment(@"ID trạng thái
1:Theo dõi
0:Không theo dõi");

                entity.Property(e => e.SupervisorId)
                    .HasColumnName("SupervisorID")
                    .HasColumnType("int(11)")
                    .HasComment("Id người giám sát");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasColumnType("int(11)")
                    .HasComment("ID người dùng");

                entity.Property(e => e.UserName)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên người dùng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Employeedetail>(entity =>
            {
                entity.ToTable("employeedetail");

                entity.Property(e => e.EmployeeDetailId)
                    .HasColumnName("EmployeeDetailID")
                    .HasComment("Khóa chính bảng EmployeeDetail")
                    .ValueGeneratedNever()
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BirthDay)
                    .HasColumnType("datetime")
                    .HasComment("Ngày sinh");

                entity.Property(e => e.ClassificationLearn)
                    .HasColumnType("varchar(255)")
                    .HasComment("Xếp loại học lực")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EducationalLevel)
                    .HasColumnType("varchar(255)")
                    .HasComment("Trình độ văn hóa")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(255)")
                    .HasComment("Email cá nhân")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmployeeCode)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("Mã nhân viên")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Ethnic)
                    .HasColumnType("varchar(255)")
                    .HasComment("Dân tộc")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Facebook)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên đầy đủ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Gender)
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("Giới tính");

                entity.Property(e => e.GraduationYear).HasColumnType("datetime");

                entity.Property(e => e.HomePhone)
                    .HasColumnType("varchar(255)")
                    .HasComment("Điện thoại nhà riêng")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IdentifyCardNumber)
                    .HasColumnType("varchar(255)")
                    .HasComment("Số CMT")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IdentityCardDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày cấp CMT/TCC");

                entity.Property(e => e.IdentityCardEndDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày hết hạn CMT");

                entity.Property(e => e.IdentityCardPlace)
                    .HasColumnType("varchar(255)")
                    .HasComment("Nơi cấp CMT")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.MaritalStatus)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tình trạng hôn nhân")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.MobilePhone)
                    .HasColumnType("varchar(255)")
                    .HasComment("Điện thoại di động")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NationalityId)
                    .HasColumnName("NationalityID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NationalityName)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OfficeEmail)
                    .HasColumnType("varchar(255)")
                    .HasComment("Email Cơ quan")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OfficePhone)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OtherEmail)
                    .HasColumnType("varchar(255)")
                    .HasComment("Email khác")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OtherPhone)
                    .HasColumnType("varchar(255)")
                    .HasComment("Điện thoại khác")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PassportDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày cấp hộ chiếu");

                entity.Property(e => e.PassportEndDate).HasColumnType("datetime");

                entity.Property(e => e.PassportNumber)
                    .HasColumnType("varchar(255)")
                    .HasComment("Số hộ chiếu")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PassportPlace)
                    .HasColumnType("varchar(255)")
                    .HasComment("Nơi cấp hộ chiếu")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PersonalTaxCode)
                    .HasColumnType("varchar(255)")
                    .HasComment("mã số thuế cá nhân")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PlaceOfBirth)
                    .HasColumnType("varchar(255)")
                    .HasComment("Nơi sinh")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Religion)
                    .HasColumnType("varchar(255)")
                    .HasComment("Tôn giáo")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ResidenceCountry)
                    .HasColumnType("varchar(255)")
                    .HasComment("Địa chỉ thường trú QUỐC TỊCH")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ResidenceDistrict)
                    .HasColumnType("varchar(255)")
                    .HasComment("Địa chỉ thường trú QUẬN/HUYỆN")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ResidenceFullAddress)
                    .HasColumnType("varchar(255)")
                    .HasComment("Địa chỉ thường trú ĐỊA CHỈ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ResidenceProvince)
                    .HasColumnType("varchar(255)")
                    .HasComment("Địa chỉ thường trú TỈNH")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ResidenceStreet)
                    .HasColumnType("varchar(255)")
                    .HasComment("Địa chỉ thường trú ĐƯỜNG,SỐ NHÀ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ResidenceWard)
                    .HasColumnType("varchar(255)")
                    .HasComment(@"Địa chỉ thường trú PHƯỜNG/XÃ
")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SchoolYear)
                    .HasColumnType("varchar(255)")
                    .HasComment("Niên khóa")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Skype)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Specialized)
                    .HasColumnType("varchar(255)")
                    .HasComment("Chuyên ngành")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TrainingLevel)
                    .HasColumnType("varchar(255)")
                    .HasComment("Trình độ đào tạo")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TrainingPlace)
                    .HasColumnType("varchar(255)")
                    .HasComment("Nơi đào tạo")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UrgentContactAddress)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UrgentContactEmail)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UrgentContactName)
                    .HasColumnType("varchar(255)")
                    .HasComment(@"LIÊN HỆ KHẨN CẤP: TÊN
")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UrgentContactPhone)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UrgentContactRelationship)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Nationality>(entity =>
            {
                entity.ToTable("nationality");

                entity.Property(e => e.NationalityId)
                    .HasColumnName("NationalityID")
                    .ValueGeneratedNever()
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NationalityName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Provincial>(entity =>
            {
                entity.ToTable("provincial");

                entity.Property(e => e.ProvincialId)
                    .HasColumnName("ProvincialID")
                    .ValueGeneratedNever()
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProvincialCode).HasColumnType("int(11)");

                entity.Property(e => e.ProvincialName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Rollcall>(entity =>
            {
                entity.ToTable("rollcall");

                entity.HasComment("Bảng điểm danh");

                entity.HasIndex(e => e.EmployeeDetailId)
                    .HasName("Reference key EmployeeDetail");

                entity.Property(e => e.RollCallId)
                    .HasColumnName("RollCallID")
                    .ValueGeneratedNever()
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmployeeCode)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmployeeDetailId)
                    .HasColumnName("EmployeeDetailID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RollCallTimeCode)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TimeCheckin).HasColumnType("datetime");

                entity.HasOne(d => d.EmployeeDetail)
                    .WithMany(p => p.Rollcall)
                    .HasForeignKey(d => d.EmployeeDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Reference key EmployeeDetail");
            });

            modelBuilder.Entity<Timekeeping>(entity =>
            {
                entity.ToTable("timekeeping");

                entity.HasComment("Bảng chấm công");

                entity.HasIndex(e => e.EmployeeDetailId)
                    .HasName("FK_timekeeping_EmployeeDetailID");

                entity.Property(e => e.TimeKeepingId)
                    .HasColumnName("TimeKeepingID")
                    .HasComment("Khóa chính bảng chấm công")
                    .ValueGeneratedNever()
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmployeeCode)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("Mã nhân viên")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EmployeeDetailId)
                    .HasColumnName("EmployeeDetailID")
                    .HasComment("Khóa chính bảng thôgn tin chi tiết nhân viên")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("Tên nhân viên")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Period)
                    .HasColumnType("datetime")
                    .HasComment("Kỳ chấm công");

                entity.Property(e => e.TimeCode)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.EmployeeDetail)
                    .WithMany(p => p.Timekeeping)
                    .HasForeignKey(d => d.EmployeeDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_timekeeping_EmployeeDetailID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.UserCode)
                    .HasName("UserCode")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .ValueGeneratedNever()
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserCode)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
