using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace My.HighSchoolProject.DataAccess.Models2;

public partial class HighSchoolDatabaseContext : DbContext
{
    public HighSchoolDatabaseContext()
    {
    }

    public HighSchoolDatabaseContext(DbContextOptions<HighSchoolDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Classroom> Classrooms { get; set; }

    public virtual DbSet<Classroomsandcourse> Classroomsandcourses { get; set; }

    public virtual DbSet<Classroomsgroup> Classroomsgroups { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Coursehoursbymajorclass> Coursehoursbymajorclasses { get; set; }

    public virtual DbSet<Courseschedule> Courseschedules { get; set; }

    public virtual DbSet<Daylimitsfordayoff> Daylimitsfordayoffs { get; set; }

    public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Employeesdayoff> Employeesdayoffs { get; set; }

    public virtual DbSet<Endofsemesterexamscore> Endofsemesterexamscores { get; set; }

    public virtual DbSet<Endofsemesteropinionscore> Endofsemesteropinionscores { get; set; }

    public virtual DbSet<Endofsemesterreport> Endofsemesterreports { get; set; }

    public virtual DbSet<Examsschedule> Examsschedules { get; set; }

    public virtual DbSet<Generalofficer> Generalofficers { get; set; }

    public virtual DbSet<Groupbystudentsmajorandclass> Groupbystudentsmajorandclasses { get; set; }

    public virtual DbSet<Major> Majors { get; set; }

    public virtual DbSet<MajorsHasCourse> MajorsHasCourses { get; set; }

    public virtual DbSet<Nonofficeremployee> Nonofficeremployees { get; set; }

    public virtual DbSet<Responsibility> Responsibilities { get; set; }

    public virtual DbSet<Schoolgeneralinfo> Schoolgeneralinfos { get; set; }

    public virtual DbSet<Schoolmanagementattendant> Schoolmanagementattendants { get; set; }

    public virtual DbSet<Semester> Semesters { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Studentgroupsbyclassandmajor> Studentgroupsbyclassandmajors { get; set; }

    public virtual DbSet<Studentmajorclass> Studentmajorclasses { get; set; }

    public virtual DbSet<Studentsdayoff> Studentsdayoffs { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<TeachersHasCourse> TeachersHasCourses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;database=HighSchoolDatabase;user=root;password=shazee;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasKey(e => e.IdBranches).HasName("PRIMARY");

            entity.ToTable("branches");

            entity.HasIndex(e => e.BranchName, "BrancheName_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IdBranches, "idBranches_UNIQUE").IsUnique();

            entity.Property(e => e.IdBranches).HasColumnName("idBranches");
            entity.Property(e => e.BranchName).HasMaxLength(45);
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.IdClasses).HasName("PRIMARY");

            entity.ToTable("classes");

            entity.HasIndex(e => e.ClassNumber, "ClassNumber_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IdClasses, "Id_UNIQUE").IsUnique();
        });

        modelBuilder.Entity<Classroom>(entity =>
        {
            entity.HasKey(e => e.IdClassRooms).HasName("PRIMARY");

            entity.ToTable("classrooms");

            entity.HasIndex(e => e.ClassRoomName, "ClassRoomName_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IdClassRooms, "IdClassRooms_UNIQUE").IsUnique();

            entity.Property(e => e.ClassRoomName).HasMaxLength(20);
        });

        modelBuilder.Entity<Classroomsandcourse>(entity =>
        {
            entity.HasKey(e => new { e.IdClassRoomsAndGroups, e.IdClassGroup, e.IdMajorsCourses, e.IdGroupByStudentsMajorAndClasses }).HasName("PRIMARY");

            entity.ToTable("classroomsandcourses");

            entity.HasIndex(e => e.IdClassRoomsAndGroups, "ClassRoomsAndCoursescol_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IdGroupByStudentsMajorAndClasses, "fk_ClassRoomsAndCourses_GroupByStudentsMajorAndClasses1_idx");

            entity.HasIndex(e => e.IdClassGroup, "fk_ClassRoomsGroup_has_Majors_has_Courses_ClassRoomsGroup1_idx");

            entity.HasIndex(e => e.IdMajorsCourses, "fk_ClassRoomsGroup_has_Majors_has_Courses_Majors_has_Course_idx");

            entity.Property(e => e.IdClassRoomsAndGroups).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdClassGroupNavigation).WithMany(p => p.Classroomsandcourses)
                .HasPrincipalKey(p => p.IdClassGroup)
                .HasForeignKey(d => d.IdClassGroup)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ClassRoomsGroup_has_Majors_has_Courses_ClassRoomsGroup1");

            entity.HasOne(d => d.IdGroupByStudentsMajorAndClassesNavigation).WithMany(p => p.Classroomsandcourses)
                .HasPrincipalKey(p => p.IdGroupByStudentsMajorAndClasses)
                .HasForeignKey(d => d.IdGroupByStudentsMajorAndClasses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ClassRoomsAndCourses_GroupByStudentsMajorAndClasses1");

            entity.HasOne(d => d.IdMajorsCoursesNavigation).WithMany(p => p.Classroomsandcourses)
                .HasPrincipalKey(p => p.IdMajorsCourses)
                .HasForeignKey(d => d.IdMajorsCourses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ClassRoomsGroup_has_Majors_has_Courses_Majors_has_Courses1");
        });

        modelBuilder.Entity<Classroomsgroup>(entity =>
        {
            entity.HasKey(e => new { e.IdClassGroup, e.IdClass, e.IdClassRooms, e.IdSemesters, e.IdCourse }).HasName("PRIMARY");

            entity.ToTable("classroomsgroup");

            entity.HasIndex(e => e.IdClassGroup, "IdClassWithMajors_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IdClass, "fk_ClassRoomsAndMajors_Classes1_idx");

            entity.HasIndex(e => e.IdSemesters, "fk_ClassRoomsAndMajors_Semesters1_idx");

            entity.HasIndex(e => e.IdCourse, "fk_ClassRoomsGroup_Courses1_idx");

            entity.HasIndex(e => e.IdClassRooms, "fk_Classes_has_Classes_has_Majors_ClassRooms1_idx");

            entity.Property(e => e.IdClassGroup).ValueGeneratedOnAdd();
            entity.Property(e => e.IdSemesters).HasColumnName("idSemesters");
            entity.Property(e => e.IdCourse).HasColumnName("idCourse");

            entity.HasOne(d => d.IdClassNavigation).WithMany(p => p.Classroomsgroups)
                .HasForeignKey(d => d.IdClass)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ClassRoomsAndMajors_Classes1");

            entity.HasOne(d => d.IdClassRoomsNavigation).WithMany(p => p.Classroomsgroups)
                .HasForeignKey(d => d.IdClassRooms)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Classes_has_Classes_has_Majors_ClassRooms1");

            entity.HasOne(d => d.IdCourseNavigation).WithMany(p => p.Classroomsgroups)
                .HasPrincipalKey(p => p.IdCourse)
                .HasForeignKey(d => d.IdCourse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ClassRoomsGroup_Courses1");

            entity.HasOne(d => d.IdSemestersNavigation).WithMany(p => p.Classroomsgroups)
                .HasForeignKey(d => d.IdSemesters)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ClassRoomsAndMajors_Semesters1");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => new { e.IdContacts, e.IdstudentNumber }).HasName("PRIMARY");

            entity.ToTable("contacts");

            entity.HasIndex(e => e.StudentsEmail, "StudentEmail_UNIQUE").IsUnique();

            entity.HasIndex(e => e.StudentParentPhone, "StudentParentPhone_UNIQUE").IsUnique();

            entity.HasIndex(e => e.StudentsPhone, "StudentPhone_UNIQUE").IsUnique();

            entity.HasIndex(e => e.StudentsParentEmail, "StudentsParentEmail_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IdstudentNumber, "fk_Contacts_Students1_idx");

            entity.Property(e => e.IdContacts).ValueGeneratedOnAdd();
            entity.Property(e => e.City).HasMaxLength(45);
            entity.Property(e => e.ParentName).HasMaxLength(30);
            entity.Property(e => e.ParentSurname).HasMaxLength(15);
            entity.Property(e => e.Region).HasMaxLength(45);
            entity.Property(e => e.StudentParentPhone).HasMaxLength(12);
            entity.Property(e => e.StudentsAddress).HasMaxLength(250);
            entity.Property(e => e.StudentsEmail).HasMaxLength(45);
            entity.Property(e => e.StudentsParentEmail).HasMaxLength(45);
            entity.Property(e => e.StudentsPhone).HasMaxLength(12);

            entity.HasOne(d => d.IdstudentNumberNavigation).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.IdstudentNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Contacts_Students1");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => new { e.IdCourse, e.IdBranches }).HasName("PRIMARY");

            entity.ToTable("courses");

            entity.HasIndex(e => e.CourseName, "CourseName_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IdBranches, "fk_Courses_Branches1_idx");

            entity.HasIndex(e => e.IdCourse, "idCourse_UNIQUE").IsUnique();

            entity.Property(e => e.IdCourse)
                .ValueGeneratedOnAdd()
                .HasColumnName("idCourse");
            entity.Property(e => e.IdBranches).HasColumnName("idBranches");
            entity.Property(e => e.CourseName).HasMaxLength(30);

            entity.HasOne(d => d.IdBranchesNavigation).WithMany(p => p.Courses)
                .HasForeignKey(d => d.IdBranches)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Courses_Branches1");
        });

        modelBuilder.Entity<Coursehoursbymajorclass>(entity =>
        {
            entity.HasKey(e => new { e.IdCourseHoursByMajorClasses, e.IdMajorsCourses, e.IdStudentMajorClasses }).HasName("PRIMARY");

            entity.ToTable("coursehoursbymajorclasses");

            entity.HasIndex(e => e.IdMajorsCourses, "fk_CourseHoursByMajorClasses_Majors_has_Courses1_idx");

            entity.HasIndex(e => e.IdStudentMajorClasses, "fk_CourseHoursByMajorClasses_StudentMajorClasses1_idx");

            entity.HasIndex(e => e.IdCourseHoursByMajorClasses, "idCourseHoursByMajorClasses_UNIQUE").IsUnique();

            entity.Property(e => e.IdCourseHoursByMajorClasses)
                .ValueGeneratedOnAdd()
                .HasColumnName("idCourseHoursByMajorClasses");
            entity.Property(e => e.CourseHourPerWeek).HasMaxLength(45);

            entity.HasOne(d => d.IdMajorsCoursesNavigation).WithMany(p => p.Coursehoursbymajorclasses)
                .HasPrincipalKey(p => p.IdMajorsCourses)
                .HasForeignKey(d => d.IdMajorsCourses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_CourseHoursByMajorClasses_Majors_has_Courses1");

            entity.HasOne(d => d.IdStudentMajorClassesNavigation).WithMany(p => p.Coursehoursbymajorclasses)
                .HasPrincipalKey(p => p.IdStudentMajorClasses)
                .HasForeignKey(d => d.IdStudentMajorClasses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_CourseHoursByMajorClasses_StudentMajorClasses1");
        });

        modelBuilder.Entity<Courseschedule>(entity =>
        {
            entity.HasKey(e => new { e.IdCourseSchedules, e.IdClassGroup, e.IdTeachers, e.IdCourse, e.IdGroupByStudentsMajorAndClasses }).HasName("PRIMARY");

            entity.ToTable("courseschedules");

            entity.HasIndex(e => e.IdClassGroup, "fk_CourseSchedules_ClassRoomsGroup1_idx");

            entity.HasIndex(e => e.IdCourse, "fk_CourseSchedules_Courses1_idx");

            entity.HasIndex(e => e.IdGroupByStudentsMajorAndClasses, "fk_CourseSchedules_GroupByStudentsMajorAndClasses1_idx");

            entity.HasIndex(e => e.IdTeachers, "fk_CourseSchedules_Teachers1_idx");

            entity.HasIndex(e => e.IdCourseSchedules, "idCourseSchedules_UNIQUE").IsUnique();

            entity.Property(e => e.IdCourseSchedules)
                .ValueGeneratedOnAdd()
                .HasColumnName("idCourseSchedules");
            entity.Property(e => e.IdTeachers).HasColumnName("idTeachers");
            entity.Property(e => e.IdCourse).HasColumnName("idCourse");
            entity.Property(e => e.DayOfWeek).HasMaxLength(12);
            entity.Property(e => e.EndTime).HasColumnType("time");
            entity.Property(e => e.StartTime).HasColumnType("time");

            entity.HasOne(d => d.IdClassGroupNavigation).WithMany(p => p.Courseschedules)
                .HasPrincipalKey(p => p.IdClassGroup)
                .HasForeignKey(d => d.IdClassGroup)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_CourseSchedules_ClassRoomsGroup1");

            entity.HasOne(d => d.IdCourseNavigation).WithMany(p => p.Courseschedules)
                .HasPrincipalKey(p => p.IdCourse)
                .HasForeignKey(d => d.IdCourse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_CourseSchedules_Courses1");

            entity.HasOne(d => d.IdGroupByStudentsMajorAndClassesNavigation).WithMany(p => p.Courseschedules)
                .HasPrincipalKey(p => p.IdGroupByStudentsMajorAndClasses)
                .HasForeignKey(d => d.IdGroupByStudentsMajorAndClasses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_CourseSchedules_GroupByStudentsMajorAndClasses1");

            entity.HasOne(d => d.IdTeachersNavigation).WithMany(p => p.Courseschedules)
                .HasPrincipalKey(p => p.IdTeachers)
                .HasForeignKey(d => d.IdTeachers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_CourseSchedules_Teachers1");
        });

        modelBuilder.Entity<Daylimitsfordayoff>(entity =>
        {
            entity.HasKey(e => new { e.IdDayLimitsForDayOffs, e.IdStudentMajorClasses }).HasName("PRIMARY");

            entity.ToTable("daylimitsfordayoffs");

            entity.HasIndex(e => e.IdStudentMajorClasses, "fk_DayLimitsForDayOffs_StudentMajorClasses1_idx");

            entity.HasIndex(e => e.IdDayLimitsForDayOffs, "idDayLimitsForDayOffs_UNIQUE").IsUnique();

            entity.Property(e => e.IdDayLimitsForDayOffs)
                .ValueGeneratedOnAdd()
                .HasColumnName("idDayLimitsForDayOffs");

            entity.HasOne(d => d.IdStudentMajorClassesNavigation).WithMany(p => p.Daylimitsfordayoffs)
                .HasPrincipalKey(p => p.IdStudentMajorClasses)
                .HasForeignKey(d => d.IdStudentMajorClasses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_DayLimitsForDayOffs_StudentMajorClasses1");
        });

        modelBuilder.Entity<Efmigrationshistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__efmigrationshistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.IdEmployee).HasName("PRIMARY");

            entity.ToTable("employees");

            entity.HasIndex(e => e.ContactNumber, "ContactNumber_UNIQUE").IsUnique();

            entity.HasIndex(e => e.EmailAdress, "EmailAdress_UNIQUE").IsUnique();

            entity.HasIndex(e => e.PersonalTc, "TeachersTC_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IdEmployee, "idTeachers_UNIQUE").IsUnique();

            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");
            entity.Property(e => e.ContactNumber).HasMaxLength(12);
            entity.Property(e => e.EmailAdress).HasMaxLength(45);
            entity.Property(e => e.HomeAdress).HasMaxLength(250);
            entity.Property(e => e.LastEdit).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(25);
            entity.Property(e => e.PersonalTc)
                .HasMaxLength(11)
                .HasColumnName("PersonalTC");
            entity.Property(e => e.RegistryDate).HasColumnType("date");
            entity.Property(e => e.Surname).HasMaxLength(18);

            entity.HasMany(d => d.IdPersonalsDayoffs).WithMany(p => p.IdEmployees)
                .UsingEntity<Dictionary<string, object>>(
                    "Employeesdayoffinfo",
                    r => r.HasOne<Employeesdayoff>().WithMany()
                        .HasForeignKey("IdPersonalsDayoff")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Employees_has_EmployeesDayOff_EmployeesDayOff1"),
                    l => l.HasOne<Employee>().WithMany()
                        .HasForeignKey("IdEmployee")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Employees_has_EmployeesDayOff_Employees1"),
                    j =>
                    {
                        j.HasKey("IdEmployee", "IdPersonalsDayoff").HasName("PRIMARY");
                        j.ToTable("employeesdayoffinfos");
                        j.HasIndex(new[] { "IdEmployee" }, "fk_Employees_has_EmployeesDayOff_Employees1_idx");
                        j.HasIndex(new[] { "IdPersonalsDayoff" }, "fk_Employees_has_EmployeesDayOff_EmployeesDayOff1_idx");
                        j.IndexerProperty<int>("IdEmployee").HasColumnName("idEmployee");
                        j.IndexerProperty<int>("IdPersonalsDayoff").HasColumnName("idPersonalsDayoff");
                    });
        });

        modelBuilder.Entity<Employeesdayoff>(entity =>
        {
            entity.HasKey(e => e.IdEmployeesDayOff).HasName("PRIMARY");

            entity.ToTable("employeesdayoff");

            entity.HasIndex(e => e.IdEmployeesDayOff, "idStudentsDayoff_UNIQUE").IsUnique();

            entity.Property(e => e.IdEmployeesDayOff).HasColumnName("idEmployeesDayOff");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Reason).HasMaxLength(45);
        });

        modelBuilder.Entity<Endofsemesterexamscore>(entity =>
        {
            entity.HasKey(e => e.IdEndOfSemesterScores).HasName("PRIMARY");

            entity.ToTable("endofsemesterexamscores");

            entity.HasIndex(e => e.IdEndOfSemesterScores, "fk_EndOfSemesterScores_has_ExamScores_EndOfSemesterScores1_idx");

            entity.Property(e => e.IdExamsScore).HasColumnName("idExamsScore");

            entity.HasOne(d => d.IdEndOfSemesterScoresNavigation).WithOne(p => p.Endofsemesterexamscore)
                .HasPrincipalKey<Endofsemesterreport>(p => p.IdEndOfSemesterScores)
                .HasForeignKey<Endofsemesterexamscore>(d => d.IdEndOfSemesterScores)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_EndOfSemesterScores_has_ExamScores_EndOfSemesterScores1");
        });

        modelBuilder.Entity<Endofsemesteropinionscore>(entity =>
        {
            entity.HasKey(e => e.IdEndOfSemesterScores).HasName("PRIMARY");

            entity.ToTable("endofsemesteropinionscores");

            entity.HasIndex(e => e.IdEndOfSemesterScores, "fk_EndOfSemesterScores_has_Teacher'sOpinionScores_EndOfSeme_idx");

            entity.Property(e => e.IdTeachersOpinionScores).HasColumnName("idTeachersOpinionScores");

            entity.HasOne(d => d.IdEndOfSemesterScoresNavigation).WithOne(p => p.Endofsemesteropinionscore)
                .HasPrincipalKey<Endofsemesterreport>(p => p.IdEndOfSemesterScores)
                .HasForeignKey<Endofsemesteropinionscore>(d => d.IdEndOfSemesterScores)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_EndOfSemesterScores_has_Teacher'sOpinionScores_EndOfSemest1");
        });

        modelBuilder.Entity<Endofsemesterreport>(entity =>
        {
            entity.HasKey(e => new { e.IdEndOfSemesterScores, e.IdstudentNumber, e.IdSemester, e.IdCourse, e.IdSchoolGeneralInfo }).HasName("PRIMARY");

            entity.ToTable("endofsemesterreport");

            entity.HasIndex(e => e.IdEndOfSemesterScores, "IdExamResult_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IdSchoolGeneralInfo, "fk_EndOfSemesterReport_SchoolGeneralInfo1_idx");

            entity.HasIndex(e => e.IdstudentNumber, "fk_EndOfSemesterReport_Students1_idx");

            entity.HasIndex(e => e.IdCourse, "fk_ExamResults_Courses1_idx");

            entity.HasIndex(e => e.IdSemester, "fk_ExamResults_Semesters1_idx");

            entity.Property(e => e.IdEndOfSemesterScores).ValueGeneratedOnAdd();
            entity.Property(e => e.IdSemester).HasColumnName("idSemester");
            entity.Property(e => e.IdSchoolGeneralInfo).HasColumnName("idSchoolGeneralInfo");

            entity.HasOne(d => d.IdCourseNavigation).WithMany(p => p.Endofsemesterreports)
                .HasPrincipalKey(p => p.IdCourse)
                .HasForeignKey(d => d.IdCourse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ExamResults_Courses1");

            entity.HasOne(d => d.IdSchoolGeneralInfoNavigation).WithMany(p => p.Endofsemesterreports)
                .HasForeignKey(d => d.IdSchoolGeneralInfo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_EndOfSemesterReport_SchoolGeneralInfo1");

            entity.HasOne(d => d.IdSemesterNavigation).WithMany(p => p.Endofsemesterreports)
                .HasForeignKey(d => d.IdSemester)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ExamResults_Semesters1");

            entity.HasOne(d => d.IdstudentNumberNavigation).WithMany(p => p.Endofsemesterreports)
                .HasForeignKey(d => d.IdstudentNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_EndOfSemesterReport_Students1");
        });

        modelBuilder.Entity<Examsschedule>(entity =>
        {
            entity.HasKey(e => new { e.IdExams, e.IdCourse, e.IdSemesters, e.IdGroupByStudentsMajorAndClasses, e.IdClassGroup, e.IdTeachers }).HasName("PRIMARY");

            entity.ToTable("examsschedules");

            entity.HasIndex(e => e.IdClassGroup, "fk_Exams_ClassRoomsGroup1_idx");

            entity.HasIndex(e => e.IdCourse, "fk_Exams_Courses1_idx");

            entity.HasIndex(e => e.IdGroupByStudentsMajorAndClasses, "fk_Exams_GroupByStudentsMajorAndClasses1_idx");

            entity.HasIndex(e => e.IdSemesters, "fk_Exams_Semesters1_idx");

            entity.HasIndex(e => e.IdTeachers, "fk_Exams_Teachers1_idx");

            entity.HasIndex(e => e.IdExams, "idExams_UNIQUE").IsUnique();

            entity.Property(e => e.IdExams)
                .ValueGeneratedOnAdd()
                .HasColumnName("idExams");
            entity.Property(e => e.IdCourse).HasColumnName("idCourse");
            entity.Property(e => e.IdSemesters).HasColumnName("idSemesters");
            entity.Property(e => e.IdTeachers).HasColumnName("idTeachers");
            entity.Property(e => e.ExamDate).HasColumnType("date");
            entity.Property(e => e.ExamTime).HasColumnType("time");

            entity.HasOne(d => d.IdClassGroupNavigation).WithMany(p => p.Examsschedules)
                .HasPrincipalKey(p => p.IdClassGroup)
                .HasForeignKey(d => d.IdClassGroup)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Exams_ClassRoomsGroup1");

            entity.HasOne(d => d.IdCourseNavigation).WithMany(p => p.Examsschedules)
                .HasPrincipalKey(p => p.IdCourse)
                .HasForeignKey(d => d.IdCourse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Exams_Courses1");

            entity.HasOne(d => d.IdGroupByStudentsMajorAndClassesNavigation).WithMany(p => p.Examsschedules)
                .HasPrincipalKey(p => p.IdGroupByStudentsMajorAndClasses)
                .HasForeignKey(d => d.IdGroupByStudentsMajorAndClasses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Exams_GroupByStudentsMajorAndClasses1");

            entity.HasOne(d => d.IdSemestersNavigation).WithMany(p => p.Examsschedules)
                .HasForeignKey(d => d.IdSemesters)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Exams_Semesters1");

            entity.HasOne(d => d.IdTeachersNavigation).WithMany(p => p.Examsschedules)
                .HasPrincipalKey(p => p.IdTeachers)
                .HasForeignKey(d => d.IdTeachers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Exams_Teachers1");
        });

        modelBuilder.Entity<Generalofficer>(entity =>
        {
            entity.HasKey(e => new { e.IdGeneralOfficers, e.IdEmployee, e.IdResponsibilities }).HasName("PRIMARY");

            entity.ToTable("generalofficers");

            entity.HasIndex(e => e.IdEmployee, "fk_GeneralOfficers_Employees1_idx");

            entity.HasIndex(e => e.IdResponsibilities, "fk_GeneralOfficers_Responsibilities1_idx");

            entity.HasIndex(e => e.IdGeneralOfficers, "idGeneralOfficers_UNIQUE").IsUnique();

            entity.Property(e => e.IdGeneralOfficers)
                .ValueGeneratedOnAdd()
                .HasColumnName("idGeneralOfficers");
            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");
            entity.Property(e => e.IdResponsibilities).HasColumnName("idResponsibilities");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.Generalofficers)
                .HasForeignKey(d => d.IdEmployee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_GeneralOfficers_Employees1");

            entity.HasOne(d => d.IdResponsibilitiesNavigation).WithMany(p => p.Generalofficers)
                .HasForeignKey(d => d.IdResponsibilities)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_GeneralOfficers_Responsibilities1");
        });

        modelBuilder.Entity<Groupbystudentsmajorandclass>(entity =>
        {
            entity.HasKey(e => new { e.IdGroupByStudentsMajorAndClasses, e.IdStudentMajorClasses, e.IdMajorClassGroups }).HasName("PRIMARY");

            entity.ToTable("groupbystudentsmajorandclasses");

            entity.HasIndex(e => e.IdGroupByStudentsMajorAndClasses, "IdGroupByStudentsMajorAndClasses_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IdMajorClassGroups, "fk_StudentMajorClasses_has_StudentGroupsByClassAndMajor_Stu_idx");

            entity.HasIndex(e => e.IdStudentMajorClasses, "fk_StudentMajorClasses_has_StudentGroupsByClassAndMajor_Stu_idx1");

            entity.Property(e => e.IdGroupByStudentsMajorAndClasses).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdMajorClassGroupsNavigation).WithMany(p => p.Groupbystudentsmajorandclasses)
                .HasPrincipalKey(p => p.IdMajorClassGroups)
                .HasForeignKey(d => d.IdMajorClassGroups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_StudentMajorClasses_has_StudentGroupsByClassAndMajor_Stude2");

            entity.HasOne(d => d.IdStudentMajorClassesNavigation).WithMany(p => p.Groupbystudentsmajorandclasses)
                .HasPrincipalKey(p => p.IdStudentMajorClasses)
                .HasForeignKey(d => d.IdStudentMajorClasses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_StudentMajorClasses_has_StudentGroupsByClassAndMajor_Stude1");
        });

        modelBuilder.Entity<Major>(entity =>
        {
            entity.HasKey(e => e.IdMajors).HasName("PRIMARY");

            entity.ToTable("majors");

            entity.HasIndex(e => e.IdMajors, "IdMajors_UNIQUE").IsUnique();

            entity.HasIndex(e => e.MajorsName, "MajorsName_UNIQUE").IsUnique();

            entity.Property(e => e.MajorsName).HasMaxLength(45);
        });

        modelBuilder.Entity<MajorsHasCourse>(entity =>
        {
            entity.HasKey(e => new { e.IdMajorsCourses, e.IdMajors, e.IdCourse, e.IdClasses }).HasName("PRIMARY");

            entity.ToTable("majors_has_courses");

            entity.HasIndex(e => e.IdMajorsCourses, "IdMajorsCourses_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IdClasses, "fk_Majors_has_Courses_Classes1_idx");

            entity.HasIndex(e => e.IdCourse, "fk_Majors_has_Courses_Courses1_idx");

            entity.HasIndex(e => e.IdMajors, "fk_Majors_has_Courses_Majors1_idx");

            entity.Property(e => e.IdMajorsCourses).ValueGeneratedOnAdd();
            entity.Property(e => e.IdCourse).HasColumnName("idCourse");

            entity.HasOne(d => d.IdClassesNavigation).WithMany(p => p.MajorsHasCourses)
                .HasForeignKey(d => d.IdClasses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Majors_has_Courses_Classes1");

            entity.HasOne(d => d.IdCourseNavigation).WithMany(p => p.MajorsHasCourses)
                .HasPrincipalKey(p => p.IdCourse)
                .HasForeignKey(d => d.IdCourse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Majors_has_Courses_Courses1");

            entity.HasOne(d => d.IdMajorsNavigation).WithMany(p => p.MajorsHasCourses)
                .HasForeignKey(d => d.IdMajors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Majors_has_Courses_Majors1");
        });

        modelBuilder.Entity<Nonofficeremployee>(entity =>
        {
            entity.HasKey(e => new { e.IdNonOfficerEmployees, e.IdEmployee, e.IdResponsibilities }).HasName("PRIMARY");

            entity.ToTable("nonofficeremployees");

            entity.HasIndex(e => e.IdEmployee, "fk_Non-OfficerEmployees_Employees1_idx");

            entity.HasIndex(e => e.IdResponsibilities, "fk_Non-OfficerEmployees_Responsibilities1_idx");

            entity.HasIndex(e => e.IdNonOfficerEmployees, "idNon-OfficerEmployees_UNIQUE").IsUnique();

            entity.Property(e => e.IdNonOfficerEmployees)
                .ValueGeneratedOnAdd()
                .HasColumnName("idNon-OfficerEmployees");
            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");
            entity.Property(e => e.IdResponsibilities).HasColumnName("idResponsibilities");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.Nonofficeremployees)
                .HasForeignKey(d => d.IdEmployee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Non-OfficerEmployees_Employees1");

            entity.HasOne(d => d.IdResponsibilitiesNavigation).WithMany(p => p.Nonofficeremployees)
                .HasForeignKey(d => d.IdResponsibilities)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Non-OfficerEmployees_Responsibilities1");
        });

        modelBuilder.Entity<Responsibility>(entity =>
        {
            entity.HasKey(e => e.IdResponsibilities).HasName("PRIMARY");

            entity.ToTable("responsibilities");

            entity.HasIndex(e => e.IdResponsibilities, "idResponsibilities_UNIQUE").IsUnique();

            entity.Property(e => e.IdResponsibilities).HasColumnName("idResponsibilities");
            entity.Property(e => e.Respobsibility).HasMaxLength(45);
        });

        modelBuilder.Entity<Schoolgeneralinfo>(entity =>
        {
            entity.HasKey(e => e.IdSchoolGeneralInfo).HasName("PRIMARY");

            entity.ToTable("schoolgeneralinfo");

            entity.HasIndex(e => e.IdSchoolGeneralInfo, "idSchoolGeneralInfo_UNIQUE").IsUnique();

            entity.Property(e => e.IdSchoolGeneralInfo).HasColumnName("idSchoolGeneralInfo");
            entity.Property(e => e.SchoolAddress).HasMaxLength(250);
            entity.Property(e => e.SchoolDegree).HasMaxLength(45);
            entity.Property(e => e.SchoolName).HasMaxLength(45);
            entity.Property(e => e.SchoolWebSite).HasMaxLength(45);
        });

        modelBuilder.Entity<Schoolmanagementattendant>(entity =>
        {
            entity.HasKey(e => new { e.IdTeacher, e.IdEmployee, e.IdBranches }).HasName("PRIMARY");

            entity.ToTable("schoolmanagementattendants");

            entity.HasIndex(e => e.IdBranches, "fk_SchoolManagementAttendants_Branches1_idx");

            entity.HasIndex(e => e.IdEmployee, "fk_SchoolManagementAttendants_Employees1_idx");

            entity.HasIndex(e => e.IdTeacher, "idSchoolManagementAttendants_UNIQUE").IsUnique();

            entity.Property(e => e.IdTeacher)
                .ValueGeneratedOnAdd()
                .HasColumnName("idTeacher");
            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");
            entity.Property(e => e.IdBranches).HasColumnName("idBranches");

            entity.HasOne(d => d.IdBranchesNavigation).WithMany(p => p.Schoolmanagementattendants)
                .HasForeignKey(d => d.IdBranches)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_SchoolManagementAttendants_Branches1");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.Schoolmanagementattendants)
                .HasForeignKey(d => d.IdEmployee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_SchoolManagementAttendants_Employees1");

            entity.HasMany(d => d.IdResponsibilities).WithMany(p => p.IdTeachers)
                .UsingEntity<Dictionary<string, object>>(
                    "Schoolmanagementattendantsresponsibility",
                    r => r.HasOne<Responsibility>().WithMany()
                        .HasForeignKey("IdResponsibilities")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_SchoolManagementAttendants_has_Responsibilities_Responsibi1"),
                    l => l.HasOne<Schoolmanagementattendant>().WithMany()
                        .HasPrincipalKey("IdTeacher")
                        .HasForeignKey("IdTeacher")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_SchoolManagementAttendants_has_Responsibilities_SchoolMana1"),
                    j =>
                    {
                        j.HasKey("IdTeacher", "IdResponsibilities").HasName("PRIMARY");
                        j.ToTable("schoolmanagementattendantsresponsibilities");
                        j.HasIndex(new[] { "IdResponsibilities" }, "fk_SchoolManagementAttendants_has_Responsibilities_Responsi_idx");
                        j.HasIndex(new[] { "IdTeacher" }, "fk_SchoolManagementAttendants_has_Responsibilities_SchoolMa_idx");
                        j.IndexerProperty<int>("IdTeacher").HasColumnName("idTeacher");
                        j.IndexerProperty<int>("IdResponsibilities").HasColumnName("idResponsibilities");
                    });
        });

        modelBuilder.Entity<Semester>(entity =>
        {
            entity.HasKey(e => e.IdSemesters).HasName("PRIMARY");

            entity.ToTable("semesters");

            entity.HasIndex(e => e.IdSemesters, "idSemesters_UNIQUE").IsUnique();

            entity.Property(e => e.IdSemesters).HasColumnName("idSemesters");
            entity.Property(e => e.Period).HasMaxLength(20);
            entity.Property(e => e.Semester1)
                .HasMaxLength(30)
                .HasColumnName("Semester");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.IdstudentNumber).HasName("PRIMARY");

            entity.ToTable("students");

            entity.HasIndex(e => e.IdstudentNumber, "IdstudentNumber_UNIQUE").IsUnique();

            entity.HasIndex(e => e.StudentTc, "StudentTC_UNIQUE").IsUnique();

            entity.Property(e => e.LastEdit).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(25);
            entity.Property(e => e.RightToEducation).HasMaxLength(10);
            entity.Property(e => e.StudentTc)
                .HasMaxLength(11)
                .HasColumnName("StudentTC");
            entity.Property(e => e.Surname).HasMaxLength(15);
        });

        modelBuilder.Entity<Studentgroupsbyclassandmajor>(entity =>
        {
            entity.HasKey(e => new { e.IdMajorClassGroups, e.IdSemesters }).HasName("PRIMARY");

            entity.ToTable("studentgroupsbyclassandmajor");

            entity.HasIndex(e => e.GroupCode, "GroupCode_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IdMajorClassGroups, "IdMajorClassGroups_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IdSemesters, "fk_StudentGroupsByClassAndMajor_Semesters1_idx");

            entity.Property(e => e.IdMajorClassGroups).ValueGeneratedOnAdd();
            entity.Property(e => e.IdSemesters).HasColumnName("idSemesters");
            entity.Property(e => e.GroupCode).HasMaxLength(45);

            entity.HasOne(d => d.IdSemestersNavigation).WithMany(p => p.Studentgroupsbyclassandmajors)
                .HasForeignKey(d => d.IdSemesters)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_StudentGroupsByClassAndMajor_Semesters1");
        });

        modelBuilder.Entity<Studentmajorclass>(entity =>
        {
            entity.HasKey(e => new { e.IdStudentMajorClasses, e.IdClasses, e.IdMajors, e.IdstudentNumber }).HasName("PRIMARY");

            entity.ToTable("studentmajorclasses");

            entity.HasIndex(e => e.IdStudentMajorClasses, "IdStudentMajorClasses_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IdClasses, "fk_Majors_has_Students_has_Classes_Classes1_idx");

            entity.HasIndex(e => e.IdMajors, "fk_StudentMajorClasses_Majors1_idx");

            entity.HasIndex(e => e.IdstudentNumber, "fk_StudentMajorClasses_Students1_idx");

            entity.Property(e => e.IdStudentMajorClasses).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdClassesNavigation).WithMany(p => p.Studentmajorclasses)
                .HasForeignKey(d => d.IdClasses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Majors_has_Students_has_Classes_Classes1");

            entity.HasOne(d => d.IdMajorsNavigation).WithMany(p => p.Studentmajorclasses)
                .HasForeignKey(d => d.IdMajors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_StudentMajorClasses_Majors1");

            entity.HasOne(d => d.IdstudentNumberNavigation).WithMany(p => p.Studentmajorclasses)
                .HasForeignKey(d => d.IdstudentNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_StudentMajorClasses_Students1");
        });

        modelBuilder.Entity<Studentsdayoff>(entity =>
        {
            entity.HasKey(e => e.IdStudentsDayoff).HasName("PRIMARY");

            entity.ToTable("studentsdayoff");

            entity.HasIndex(e => e.IdstudentNumber, "IdstudentNumber");

            entity.HasIndex(e => e.IdStudentsDayoff, "idStudentsDayoff_UNIQUE").IsUnique();

            entity.Property(e => e.IdStudentsDayoff).HasColumnName("idStudentsDayoff");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Reason).HasMaxLength(45);

            entity.HasOne(d => d.IdstudentNumberNavigation).WithMany(p => p.Studentsdayoffs)
                .HasForeignKey(d => d.IdstudentNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdstudentNumber");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => new { e.IdTeachers, e.IdEmployee, e.IdBranches, e.IdResponsibilities }).HasName("PRIMARY");

            entity.ToTable("teachers");

            entity.HasIndex(e => e.IdBranches, "fk_Teachers_Branches1_idx");

            entity.HasIndex(e => e.IdEmployee, "fk_Teachers_Employees1_idx");

            entity.HasIndex(e => e.IdResponsibilities, "fk_Teachers_Responsibilities1_idx");

            entity.HasIndex(e => e.IdTeachers, "idTeachers_UNIQUE").IsUnique();

            entity.Property(e => e.IdTeachers)
                .ValueGeneratedOnAdd()
                .HasColumnName("idTeachers");
            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");
            entity.Property(e => e.IdBranches).HasColumnName("idBranches");
            entity.Property(e => e.IdResponsibilities).HasColumnName("idResponsibilities");

            entity.HasOne(d => d.IdBranchesNavigation).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.IdBranches)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Teachers_Branches1");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.IdEmployee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Teachers_Employees1");

            entity.HasOne(d => d.IdResponsibilitiesNavigation).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.IdResponsibilities)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Teachers_Responsibilities1");

        });

        modelBuilder.Entity<TeachersHasCourse>(entity =>
        {
            entity.HasKey(e => new { e.IdTeacherhasCourses, e.IdTeachers, e.IdCourse }).HasName("PRIMARY");

            entity.ToTable("teachers_has_courses");

            entity.HasIndex(e => e.IdCourse, "fk_Teachers_has_Courses_Courses1_idx");

            entity.HasIndex(e => e.IdTeachers, "fk_Teachers_has_Courses_Teachers1_idx");

            entity.HasIndex(e => e.IdTeacherhasCourses, "idTeacherhasCourses_UNIQUE").IsUnique();

            entity.Property(e => e.IdTeacherhasCourses)
                .ValueGeneratedOnAdd()
                .HasColumnName("idTeacherhasCourses");
            entity.Property(e => e.IdTeachers).HasColumnName("idTeachers");
            entity.Property(e => e.IdCourse).HasColumnName("idCourse");

            entity.HasOne(d => d.IdCourseNavigation).WithMany(p => p.TeachersHasCourses)
                .HasPrincipalKey(p => p.IdCourse)
                .HasForeignKey(d => d.IdCourse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Teachers_has_Courses_Courses1");

            entity.HasOne(d => d.IdTeachersNavigation).WithMany(p => p.TeachersHasCourses)
                .HasPrincipalKey(p => p.IdTeachers)
                .HasForeignKey(d => d.IdTeachers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Teachers_has_Courses_Teachers1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
