﻿using System;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using My.HighSchoolProject.DataAccess.Models2;

#nullable disable

namespace My.HighSchoolProject.DataAccess.Migrations
{
    [DbContext(typeof(HighSchoolDatabaseContext))]
    partial class HighSchoolDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            

            modelBuilder
            .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Employeesdayoffinfo", b =>
                {
                    b.Property<int>("IdEmployee")
                        .HasColumnType("int")
                        .HasColumnName("idEmployee");

                    b.Property<int>("IdPersonalsDayoff")
                        .HasColumnType("int")
                        .HasColumnName("idPersonalsDayoff");

                    b.HasKey("IdEmployee", "IdPersonalsDayoff")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdEmployee" }, "fk_Employees_has_EmployeesDayOff_Employees1_idx");

                    b.HasIndex(new[] { "IdPersonalsDayoff" }, "fk_Employees_has_EmployeesDayOff_EmployeesDayOff1_idx");

                    b.ToTable("employeesdayoffinfos", (string)null);
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.BaseEntities.Student", b =>
                {
                    b.Property<int>("IdstudentNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("FailCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastEdit")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<int>("RegistryYear")
                        .HasColumnType("int");

                    b.Property<string>("RightToEducation")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("StudentTc")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)")
                        .HasColumnName("StudentTC");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.HasKey("IdstudentNumber")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdstudentNumber" }, "IdstudentNumber_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "StudentTc" }, "StudentTC_UNIQUE")
                        .IsUnique();

                    b.ToTable("students", (string)null);
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Branch", b =>
                {
                    b.Property<int>("IdBranches")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idBranches");

                    b.Property<string>("BranchName")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("IdBranches")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "BranchName" }, "BrancheName_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "IdBranches" }, "idBranches_UNIQUE")
                        .IsUnique();

                    b.ToTable("branches", (string)null);
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Class", b =>
                {
                    b.Property<int>("IdClasses")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClassNumber")
                        .HasColumnType("int");

                    b.HasKey("IdClasses")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "ClassNumber" }, "ClassNumber_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "IdClasses" }, "Id_UNIQUE")
                        .IsUnique();

                    b.ToTable("classes", (string)null);
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Classroom", b =>
                {
                    b.Property<int>("IdClassRooms")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClassRoomCapacity")
                        .HasColumnType("int");

                    b.Property<string>("ClassRoomName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("IdClassRooms")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "ClassRoomName" }, "ClassRoomName_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "IdClassRooms" }, "IdClassRooms_UNIQUE")
                        .IsUnique();

                    b.ToTable("classrooms", (string)null);
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Classroomsandcourse", b =>
                {
                    b.Property<int>("IdClassRoomsAndGroups")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdClassGroup")
                        .HasColumnType("int");

                    b.Property<int>("IdMajorsCourses")
                        .HasColumnType("int");

                    b.Property<int>("IdGroupByStudentsMajorAndClasses")
                        .HasColumnType("int");

                    b.HasKey("IdClassRoomsAndGroups", "IdClassGroup", "IdMajorsCourses", "IdGroupByStudentsMajorAndClasses")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdClassRoomsAndGroups" }, "ClassRoomsAndCoursescol_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "IdGroupByStudentsMajorAndClasses" }, "fk_ClassRoomsAndCourses_GroupByStudentsMajorAndClasses1_idx");

                    b.HasIndex(new[] { "IdClassGroup" }, "fk_ClassRoomsGroup_has_Majors_has_Courses_ClassRoomsGroup1_idx");

                    b.HasIndex(new[] { "IdMajorsCourses" }, "fk_ClassRoomsGroup_has_Majors_has_Courses_Majors_has_Course_idx");

                    b.ToTable("classroomsandcourses", (string)null);
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Classroomsgroup", b =>
                {
                    b.Property<int>("IdClassGroup")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdClass")
                        .HasColumnType("int");

                    b.Property<int>("IdClassRooms")
                        .HasColumnType("int");

                    b.Property<int>("IdSemesters")
                        .HasColumnType("int")
                        .HasColumnName("idSemesters");

                    b.Property<int>("IdCourse")
                        .HasColumnType("int")
                        .HasColumnName("idCourse");

                    b.HasKey("IdClassGroup", "IdClass", "IdClassRooms", "IdSemesters", "IdCourse")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdClassGroup" }, "IdClassWithMajors_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "IdClass" }, "fk_ClassRoomsAndMajors_Classes1_idx");

                    b.HasIndex(new[] { "IdSemesters" }, "fk_ClassRoomsAndMajors_Semesters1_idx");

                    b.HasIndex(new[] { "IdCourse" }, "fk_ClassRoomsGroup_Courses1_idx");

                    b.HasIndex(new[] { "IdClassRooms" }, "fk_Classes_has_Classes_has_Majors_ClassRooms1_idx");

                    b.ToTable("classroomsgroup", (string)null);
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Contact", b =>
                {
                    b.Property<int>("IdContacts")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdstudentNumber")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("ParentName")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("ParentSurname")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Region")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("StudentParentPhone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)");

                    b.Property<string>("StudentsAddress")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("StudentsEmail")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("StudentsParentEmail")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("StudentsPhone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)");

                    b.HasKey("IdContacts", "IdstudentNumber")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "StudentsEmail" }, "StudentEmail_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "StudentParentPhone" }, "StudentParentPhone_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "StudentsPhone" }, "StudentPhone_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "StudentsParentEmail" }, "StudentsParentEmail_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "IdstudentNumber" }, "fk_Contacts_Students1_idx");

                    b.ToTable("contacts", (string)null);
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Course", b =>
                {
                    b.Property<int>("IdCourse")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idCourse");

                    b.Property<int>("IdBranches")
                        .HasColumnType("int")
                        .HasColumnName("idBranches");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("IdCourse", "IdBranches")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "CourseName" }, "CourseName_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "IdBranches" }, "fk_Courses_Branches1_idx");

                    b.HasIndex(new[] { "IdCourse" }, "idCourse_UNIQUE")
                        .IsUnique();

                    b.ToTable("courses", (string)null);
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Coursehoursbymajorclass", b =>
                {
                    b.Property<int>("IdCourseHoursByMajorClasses")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idCourseHoursByMajorClasses");

                    b.Property<int>("IdMajorsCourses")
                        .HasColumnType("int");

                    b.Property<int>("IdStudentMajorClasses")
                        .HasColumnType("int");

                    b.Property<string>("CourseHourPerWeek")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("IdCourseHoursByMajorClasses", "IdMajorsCourses", "IdStudentMajorClasses")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdMajorsCourses" }, "fk_CourseHoursByMajorClasses_Majors_has_Courses1_idx");

                    b.HasIndex(new[] { "IdStudentMajorClasses" }, "fk_CourseHoursByMajorClasses_StudentMajorClasses1_idx");

                    b.HasIndex(new[] { "IdCourseHoursByMajorClasses" }, "idCourseHoursByMajorClasses_UNIQUE")
                        .IsUnique();

                    b.ToTable("coursehoursbymajorclasses", (string)null);
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Courseschedule", b =>
                {
                    b.Property<int>("IdCourseSchedules")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idCourseSchedules");

                    b.Property<int>("IdClassGroup")
                        .HasColumnType("int");

                    b.Property<int>("IdTeachers")
                        .HasColumnType("int")
                        .HasColumnName("idTeachers");

                    b.Property<int>("IdCourse")
                        .HasColumnType("int")
                        .HasColumnName("idCourse");

                    b.Property<int>("IdGroupByStudentsMajorAndClasses")
                        .HasColumnType("int");

                    b.Property<string>("DayOfWeek")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("IdCourseSchedules", "IdClassGroup", "IdTeachers", "IdCourse", "IdGroupByStudentsMajorAndClasses")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdClassGroup" }, "fk_CourseSchedules_ClassRoomsGroup1_idx");

                    b.HasIndex(new[] { "IdCourse" }, "fk_CourseSchedules_Courses1_idx");

                    b.HasIndex(new[] { "IdGroupByStudentsMajorAndClasses" }, "fk_CourseSchedules_GroupByStudentsMajorAndClasses1_idx");

                    b.HasIndex(new[] { "IdTeachers" }, "fk_CourseSchedules_Teachers1_idx");

                    b.HasIndex(new[] { "IdCourseSchedules" }, "idCourseSchedules_UNIQUE")
                        .IsUnique();

                    b.ToTable("courseschedules", (string)null);
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Daylimitsfordayoff", b =>
                {
                    b.Property<int>("IdDayLimitsForDayOffs")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idDayLimitsForDayOffs");

                    b.Property<int>("IdStudentMajorClasses")
                        .HasColumnType("int");

                    b.Property<int>("DayLimitForClass")
                        .HasColumnType("int");

                    b.HasKey("IdDayLimitsForDayOffs", "IdStudentMajorClasses")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdStudentMajorClasses" }, "fk_DayLimitsForDayOffs_StudentMajorClasses1_idx");

                    b.HasIndex(new[] { "IdDayLimitsForDayOffs" }, "idDayLimitsForDayOffs_UNIQUE")
                        .IsUnique();

                    b.ToTable("daylimitsfordayoffs", (string)null);
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Employee", b =>
                {
                    b.Property<int>("IdEmployee")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idEmployee");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)");

                    b.Property<string>("EmailAdress")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("HomeAdress")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime?>("LastEdit")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("PersonalTc")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)")
                        .HasColumnName("PersonalTC");

                    b.Property<DateTime?>("RegistryDate")
                        .HasColumnType("date");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("varchar(18)");

                    b.Property<float?>("Wage")
                        .HasColumnType("float");

                    b.HasKey("IdEmployee")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "ContactNumber" }, "ContactNumber_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "EmailAdress" }, "EmailAdress_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "PersonalTc" }, "TeachersTC_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "IdEmployee" }, "idTeachers_UNIQUE")
                        .IsUnique();

                    b.ToTable("employees", (string)null);
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Employeesdayoff", b =>
                {
                    b.Property<int>("IdEmployeesDayOff")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idEmployeesDayOff");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<sbyte>("DoctorReport")
                        .HasColumnType("tinyint");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("IdEmployeesDayOff")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdEmployeesDayOff" }, "idStudentsDayoff_UNIQUE")
                        .IsUnique();

                    b.ToTable("employeesdayoff", (string)null);
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Endofsemesterexamscore", b =>
                {
                    b.Property<int>("IdEndOfSemesterScores")
                        .HasColumnType("int");

                    b.Property<int>("IdExamsScore")
                        .HasColumnType("int")
                        .HasColumnName("idExamsScore");

                    b.HasKey("IdEndOfSemesterScores")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdEndOfSemesterScores" }, "fk_EndOfSemesterScores_has_ExamScores_EndOfSemesterScores1_idx");

                    b.ToTable("endofsemesterexamscores", (string)null);
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Endofsemesteropinionscore", b =>
                {
                    b.Property<int>("IdEndOfSemesterScores")
                        .HasColumnType("int");

                    b.Property<int>("IdTeachersOpinionScores")
                        .HasColumnType("int")
                        .HasColumnName("idTeachersOpinionScores");

                    b.HasKey("IdEndOfSemesterScores")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdEndOfSemesterScores" }, "fk_EndOfSemesterScores_has_Teacher'sOpinionScores_EndOfSeme_idx");

                    b.ToTable("endofsemesteropinionscores", (string)null);
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Endofsemesterreport", b =>
                {
                    b.Property<int>("IdEndOfSemesterScores")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdstudentNumber")
                        .HasColumnType("int");

                    b.Property<int>("IdSemester")
                        .HasColumnType("int")
                        .HasColumnName("idSemester");

                    b.Property<int>("IdCourse")
                        .HasColumnType("int");

                    b.Property<int>("IdSchoolGeneralInfo")
                        .HasColumnType("int")
                        .HasColumnName("idSchoolGeneralInfo");

                    b.Property<int?>("AvarageScore")
                        .HasColumnType("int");

                    b.Property<int?>("TotalDayOfWithoutReport")
                        .HasColumnType("int");

                    b.Property<int?>("TotalDayOffWithReport")
                        .HasColumnType("int");

                    b.HasKey("IdEndOfSemesterScores", "IdstudentNumber", "IdSemester", "IdCourse", "IdSchoolGeneralInfo")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdEndOfSemesterScores" }, "IdExamResult_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "IdSchoolGeneralInfo" }, "fk_EndOfSemesterReport_SchoolGeneralInfo1_idx");

                    b.HasIndex(new[] { "IdstudentNumber" }, "fk_EndOfSemesterReport_Students1_idx");

                    b.HasIndex(new[] { "IdCourse" }, "fk_ExamResults_Courses1_idx");

                    b.HasIndex(new[] { "IdSemester" }, "fk_ExamResults_Semesters1_idx");

                    b.ToTable("endofsemesterreport", (string)null);
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Examsschedule", b =>
                {
                    b.Property<int>("IdExams")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idExams");

                    b.Property<int>("IdCourse")
                        .HasColumnType("int")
                        .HasColumnName("idCourse");

                    b.Property<int>("IdSemesters")
                        .HasColumnType("int")
                        .HasColumnName("idSemesters");

                    b.Property<int>("IdGroupByStudentsMajorAndClasses")
                        .HasColumnType("int");

                    b.Property<int>("IdClassGroup")
                        .HasColumnType("int");

                    b.Property<int>("IdTeachers")
                        .HasColumnType("int")
                        .HasColumnName("idTeachers");

                    b.Property<DateTime>("ExamDate")
                        .HasColumnType("date");

                    b.Property<TimeSpan>("ExamTime")
                        .HasColumnType("time");

                    b.HasKey("IdExams", "IdCourse", "IdSemesters", "IdGroupByStudentsMajorAndClasses", "IdClassGroup", "IdTeachers")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdClassGroup" }, "fk_Exams_ClassRoomsGroup1_idx");

                    b.HasIndex(new[] { "IdCourse" }, "fk_Exams_Courses1_idx");

                    b.HasIndex(new[] { "IdGroupByStudentsMajorAndClasses" }, "fk_Exams_GroupByStudentsMajorAndClasses1_idx");

                    b.HasIndex(new[] { "IdSemesters" }, "fk_Exams_Semesters1_idx");

                    b.HasIndex(new[] { "IdTeachers" }, "fk_Exams_Teachers1_idx");

                    b.HasIndex(new[] { "IdExams" }, "idExams_UNIQUE")
                        .IsUnique();

                    b.ToTable("examsschedules", (string)null);
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Generalofficer", b =>
                {
                    b.Property<int>("IdGeneralOfficers")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idGeneralOfficers");

                    b.Property<int>("IdEmployee")
                        .HasColumnType("int")
                        .HasColumnName("idEmployee");

                    b.Property<int>("IdResponsibilities")
                        .HasColumnType("int")
                        .HasColumnName("idResponsibilities");

                    b.HasKey("IdGeneralOfficers", "IdEmployee", "IdResponsibilities")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdEmployee" }, "fk_GeneralOfficers_Employees1_idx");

                    b.HasIndex(new[] { "IdResponsibilities" }, "fk_GeneralOfficers_Responsibilities1_idx");

                    b.HasIndex(new[] { "IdGeneralOfficers" }, "idGeneralOfficers_UNIQUE")
                        .IsUnique();

                    b.ToTable("generalofficers", (string)null);
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Groupbystudentsmajorandclass", b =>
                {
                    b.Property<int>("IdGroupByStudentsMajorAndClasses")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdStudentMajorClasses")
                        .HasColumnType("int");

                    b.Property<int>("IdMajorClassGroups")
                        .HasColumnType("int");

                    b.Property<int>("GroupCapacity")
                        .HasColumnType("int");

                    b.HasKey("IdGroupByStudentsMajorAndClasses", "IdStudentMajorClasses", "IdMajorClassGroups")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdGroupByStudentsMajorAndClasses" }, "IdGroupByStudentsMajorAndClasses_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "IdMajorClassGroups" }, "fk_StudentMajorClasses_has_StudentGroupsByClassAndMajor_Stu_idx");

                    b.HasIndex(new[] { "IdStudentMajorClasses" }, "fk_StudentMajorClasses_has_StudentGroupsByClassAndMajor_Stu_idx1");

                    b.ToTable("groupbystudentsmajorandclasses", (string)null);
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Major", b =>
                {
                    b.Property<int>("IdMajors")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("MajorsName")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<int>("QuataLimit")
                        .HasColumnType("int");

                    b.HasKey("IdMajors")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdMajors" }, "IdMajors_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "MajorsName" }, "MajorsName_UNIQUE")
                        .IsUnique();

                    b.ToTable("majors", (string)null);
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.MajorsHasCourse", b =>
                {
                    b.Property<int>("IdMajorsCourses")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdMajors")
                        .HasColumnType("int");

                    b.Property<int>("IdCourse")
                        .HasColumnType("int")
                        .HasColumnName("idCourse");

                    b.Property<int>("IdClasses")
                        .HasColumnType("int");

                    b.HasKey("IdMajorsCourses", "IdMajors", "IdCourse", "IdClasses")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdMajorsCourses" }, "IdMajorsCourses_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "IdClasses" }, "fk_Majors_has_Courses_Classes1_idx");

                    b.HasIndex(new[] { "IdCourse" }, "fk_Majors_has_Courses_Courses1_idx");

                    b.HasIndex(new[] { "IdMajors" }, "fk_Majors_has_Courses_Majors1_idx");

                    b.ToTable("majors_has_courses", (string)null);
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Nonofficeremployee", b =>
                {
                    b.Property<int>("IdNonOfficerEmployees")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idNon-OfficerEmployees");

                    b.Property<int>("IdEmployee")
                        .HasColumnType("int")
                        .HasColumnName("idEmployee");

                    b.Property<int>("IdResponsibilities")
                        .HasColumnType("int")
                        .HasColumnName("idResponsibilities");

                    b.HasKey("IdNonOfficerEmployees", "IdEmployee", "IdResponsibilities")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdEmployee" }, "fk_Non-OfficerEmployees_Employees1_idx");

                    b.HasIndex(new[] { "IdResponsibilities" }, "fk_Non-OfficerEmployees_Responsibilities1_idx");

                    b.HasIndex(new[] { "IdNonOfficerEmployees" }, "idNon-OfficerEmployees_UNIQUE")
                        .IsUnique();

                    b.ToTable("nonofficeremployees", (string)null);
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Responsibility", b =>
                {
                    b.Property<int>("IdResponsibilities")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idResponsibilities");

                    b.Property<string>("Respobsibility")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("IdResponsibilities")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdResponsibilities" }, "idResponsibilities_UNIQUE")
                        .IsUnique();

                    b.ToTable("responsibilities", (string)null);
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Schoolgeneralinfo", b =>
                {
                    b.Property<int>("IdSchoolGeneralInfo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idSchoolGeneralInfo");

                    b.Property<int>("FoundationYear")
                        .HasColumnType("int");

                    b.Property<string>("SchoolAddress")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("SchoolDegree")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("SchoolName")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("SchoolWebSite")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("IdSchoolGeneralInfo")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdSchoolGeneralInfo" }, "idSchoolGeneralInfo_UNIQUE")
                        .IsUnique();

                    b.ToTable("schoolgeneralinfo", (string)null);
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Schoolmanagementattendant", b =>
                {
                    b.Property<int>("IdTeacher")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idTeacher");

                    b.Property<int>("IdEmployee")
                        .HasColumnType("int")
                        .HasColumnName("idEmployee");

                    b.Property<int>("IdBranches")
                        .HasColumnType("int")
                        .HasColumnName("idBranches");

                    b.HasKey("IdTeacher", "IdEmployee", "IdBranches")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdBranches" }, "fk_SchoolManagementAttendants_Branches1_idx");

                    b.HasIndex(new[] { "IdEmployee" }, "fk_SchoolManagementAttendants_Employees1_idx");

                    b.HasIndex(new[] { "IdTeacher" }, "idSchoolManagementAttendants_UNIQUE")
                        .IsUnique();

                    b.ToTable("schoolmanagementattendants", (string)null);
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Semester", b =>
                {
                    b.Property<int>("IdSemesters")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idSemesters");

                    b.Property<string>("Period")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Semester1")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Semester");

                    b.HasKey("IdSemesters")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdSemesters" }, "idSemesters_UNIQUE")
                        .IsUnique();

                    b.ToTable("semesters", (string)null);
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Studentgroupsbyclassandmajor", b =>
                {
                    b.Property<int>("IdMajorClassGroups")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdSemesters")
                        .HasColumnType("int")
                        .HasColumnName("idSemesters");

                    b.Property<string>("GroupCode")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("IdMajorClassGroups", "IdSemesters")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "GroupCode" }, "GroupCode_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "IdMajorClassGroups" }, "IdMajorClassGroups_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "IdSemesters" }, "fk_StudentGroupsByClassAndMajor_Semesters1_idx");

                    b.ToTable("studentgroupsbyclassandmajor", (string)null);
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Studentmajorclass", b =>
                {
                    b.Property<int>("IdStudentMajorClasses")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdClasses")
                        .HasColumnType("int");

                    b.Property<int>("IdMajors")
                        .HasColumnType("int");

                    b.Property<int>("IdstudentNumber")
                        .HasColumnType("int");

                    b.HasKey("IdStudentMajorClasses", "IdClasses", "IdMajors", "IdstudentNumber")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdStudentMajorClasses" }, "IdStudentMajorClasses_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "IdClasses" }, "fk_Majors_has_Students_has_Classes_Classes1_idx");

                    b.HasIndex(new[] { "IdMajors" }, "fk_StudentMajorClasses_Majors1_idx");

                    b.HasIndex(new[] { "IdstudentNumber" }, "fk_StudentMajorClasses_Students1_idx");

                    b.ToTable("studentmajorclasses", (string)null);
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Studentsdayoff", b =>
                {
                    b.Property<int>("IdStudentsDayoff")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idStudentsDayoff");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<sbyte>("DoctorReport")
                        .HasColumnType("tinyint");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<int>("IdstudentNumber")
                        .HasColumnType("int")
                        .HasColumnName("IdStudentNumber");

                    b.HasKey("IdStudentsDayoff")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdstudentNumber" }, "fk_StudentDayOff_has_Student1_idx");

                    b.HasIndex(new[] { "IdStudentsDayoff" }, "idStudentsDayoff_UNIQUE")
                        .IsUnique()
                        .HasDatabaseName("idStudentsDayoff_UNIQUE1");

                    b.ToTable("studentsdayoff", (string)null);
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Teacher", b =>
                {
                    b.Property<int>("IdTeachers")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idTeachers");

                    b.Property<int>("IdEmployee")
                        .HasColumnType("int")
                        .HasColumnName("idEmployee");

                    b.Property<int>("IdBranches")
                        .HasColumnType("int")
                        .HasColumnName("idBranches");

                    b.Property<int>("IdResponsibilities")
                        .HasColumnType("int")
                        .HasColumnName("idResponsibilities");

                    b.HasKey("IdTeachers", "IdEmployee", "IdBranches", "IdResponsibilities")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdBranches" }, "fk_Teachers_Branches1_idx");

                    b.HasIndex(new[] { "IdEmployee" }, "fk_Teachers_Employees1_idx");

                    b.HasIndex(new[] { "IdResponsibilities" }, "fk_Teachers_Responsibilities1_idx");

                    b.HasIndex(new[] { "IdTeachers" }, "idTeachers_UNIQUE")
                        .IsUnique()
                        .HasDatabaseName("idTeachers_UNIQUE1");

                    b.ToTable("teachers", (string)null);
                });

            modelBuilder.Entity("Schoolmanagementattendantsresponsibility", b =>
                {
                    b.Property<int>("IdTeacher")
                        .HasColumnType("int")
                        .HasColumnName("idTeacher");

                    b.Property<int>("IdResponsibilities")
                        .HasColumnType("int")
                        .HasColumnName("idResponsibilities");

                    b.HasKey("IdTeacher", "IdResponsibilities")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdResponsibilities" }, "fk_SchoolManagementAttendants_has_Responsibilities_Responsi_idx");

                    b.HasIndex(new[] { "IdTeacher" }, "fk_SchoolManagementAttendants_has_Responsibilities_SchoolMa_idx");

                    b.ToTable("schoolmanagementattendantsresponsibilities", (string)null);
                });

          

            modelBuilder.Entity("TeachersHasCourse", b =>
                {
                    b.Property<int>("IdTeachers")
                        .HasColumnType("int")
                        .HasColumnName("idTeachers");

                    b.Property<int>("IdCourse")
                        .HasColumnType("int")
                        .HasColumnName("idCourse");

                    b.HasKey("IdTeachers", "IdCourse")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdCourse" }, "fk_Teachers_has_Courses_Courses1_idx");

                    b.HasIndex(new[] { "IdTeachers" }, "fk_Teachers_has_Courses_Teachers1_idx");

                    b.ToTable("teachers_has_courses", (string)null);
                });

            modelBuilder.Entity("Employeesdayoffinfo", b =>
                {
                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("IdEmployee")
                        .IsRequired()
                        .HasConstraintName("fk_Employees_has_EmployeesDayOff_Employees1");

                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Employeesdayoff", null)
                        .WithMany()
                        .HasForeignKey("IdPersonalsDayoff")
                        .IsRequired()
                        .HasConstraintName("fk_Employees_has_EmployeesDayOff_EmployeesDayOff1");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Classroomsandcourse", b =>
                {
                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Classroomsgroup", "IdClassGroupNavigation")
                        .WithMany("Classroomsandcourses")
                        .HasForeignKey("IdClassGroup")
                        .HasPrincipalKey("IdClassGroup")
                        .IsRequired()
                        .HasConstraintName("fk_ClassRoomsGroup_has_Majors_has_Courses_ClassRoomsGroup1");

                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Groupbystudentsmajorandclass", "IdGroupByStudentsMajorAndClassesNavigation")
                        .WithMany("Classroomsandcourses")
                        .HasForeignKey("IdGroupByStudentsMajorAndClasses")
                        .HasPrincipalKey("IdGroupByStudentsMajorAndClasses")
                        .IsRequired()
                        .HasConstraintName("fk_ClassRoomsAndCourses_GroupByStudentsMajorAndClasses1");

                    b.HasOne("My.HighSchoolProject.DataAccess.Models.MajorsHasCourse", "IdMajorsCoursesNavigation")
                        .WithMany("Classroomsandcourses")
                        .HasForeignKey("IdMajorsCourses")
                        .HasPrincipalKey("IdMajorsCourses")
                        .IsRequired()
                        .HasConstraintName("fk_ClassRoomsGroup_has_Majors_has_Courses_Majors_has_Courses1");

                    b.Navigation("IdClassGroupNavigation");

                    b.Navigation("IdGroupByStudentsMajorAndClassesNavigation");

                    b.Navigation("IdMajorsCoursesNavigation");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Classroomsgroup", b =>
                {
                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Class", "IdClassNavigation")
                        .WithMany("Classroomsgroups")
                        .HasForeignKey("IdClass")
                        .IsRequired()
                        .HasConstraintName("fk_ClassRoomsAndMajors_Classes1");

                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Classroom", "IdClassRoomsNavigation")
                        .WithMany("Classroomsgroups")
                        .HasForeignKey("IdClassRooms")
                        .IsRequired()
                        .HasConstraintName("fk_Classes_has_Classes_has_Majors_ClassRooms1");

                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Course", "IdCourseNavigation")
                        .WithMany("Classroomsgroups")
                        .HasForeignKey("IdCourse")
                        .HasPrincipalKey("IdCourse")
                        .IsRequired()
                        .HasConstraintName("fk_ClassRoomsGroup_Courses1");

                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Semester", "IdSemestersNavigation")
                        .WithMany("Classroomsgroups")
                        .HasForeignKey("IdSemesters")
                        .IsRequired()
                        .HasConstraintName("fk_ClassRoomsAndMajors_Semesters1");

                    b.Navigation("IdClassNavigation");

                    b.Navigation("IdClassRoomsNavigation");

                    b.Navigation("IdCourseNavigation");

                    b.Navigation("IdSemestersNavigation");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Contact", b =>
                {
                    b.HasOne("My.HighSchoolProject.DataAccess.BaseEntities.Student", "IdstudentNumberNavigation")
                        .WithMany("Contacts")
                        .HasForeignKey("IdstudentNumber")
                        .IsRequired()
                        .HasConstraintName("fk_Contacts_Students1");

                    b.Navigation("IdstudentNumberNavigation");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Course", b =>
                {
                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Branch", "IdBranchesNavigation")
                        .WithMany("Courses")
                        .HasForeignKey("IdBranches")
                        .IsRequired()
                        .HasConstraintName("fk_Courses_Branches1");

                    b.Navigation("IdBranchesNavigation");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Coursehoursbymajorclass", b =>
                {
                    b.HasOne("My.HighSchoolProject.DataAccess.Models.MajorsHasCourse", "IdMajorsCoursesNavigation")
                        .WithMany("Coursehoursbymajorclasses")
                        .HasForeignKey("IdMajorsCourses")
                        .HasPrincipalKey("IdMajorsCourses")
                        .IsRequired()
                        .HasConstraintName("fk_CourseHoursByMajorClasses_Majors_has_Courses1");

                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Studentmajorclass", "IdStudentMajorClassesNavigation")
                        .WithMany("Coursehoursbymajorclasses")
                        .HasForeignKey("IdStudentMajorClasses")
                        .HasPrincipalKey("IdStudentMajorClasses")
                        .IsRequired()
                        .HasConstraintName("fk_CourseHoursByMajorClasses_StudentMajorClasses1");

                    b.Navigation("IdMajorsCoursesNavigation");

                    b.Navigation("IdStudentMajorClassesNavigation");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Courseschedule", b =>
                {
                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Classroomsgroup", "IdClassGroupNavigation")
                        .WithMany("Courseschedules")
                        .HasForeignKey("IdClassGroup")
                        .HasPrincipalKey("IdClassGroup")
                        .IsRequired()
                        .HasConstraintName("fk_CourseSchedules_ClassRoomsGroup1");

                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Course", "IdCourseNavigation")
                        .WithMany("Courseschedules")
                        .HasForeignKey("IdCourse")
                        .HasPrincipalKey("IdCourse")
                        .IsRequired()
                        .HasConstraintName("fk_CourseSchedules_Courses1");

                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Groupbystudentsmajorandclass", "IdGroupByStudentsMajorAndClassesNavigation")
                        .WithMany("Courseschedules")
                        .HasForeignKey("IdGroupByStudentsMajorAndClasses")
                        .HasPrincipalKey("IdGroupByStudentsMajorAndClasses")
                        .IsRequired()
                        .HasConstraintName("fk_CourseSchedules_GroupByStudentsMajorAndClasses1");

                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Teacher", "IdTeachersNavigation")
                        .WithMany("Courseschedules")
                        .HasForeignKey("IdTeachers")
                        .HasPrincipalKey("IdTeachers")
                        .IsRequired()
                        .HasConstraintName("fk_CourseSchedules_Teachers1");

                    b.Navigation("IdClassGroupNavigation");

                    b.Navigation("IdCourseNavigation");

                    b.Navigation("IdGroupByStudentsMajorAndClassesNavigation");

                    b.Navigation("IdTeachersNavigation");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Daylimitsfordayoff", b =>
                {
                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Studentmajorclass", "IdStudentMajorClassesNavigation")
                        .WithMany("Daylimitsfordayoffs")
                        .HasForeignKey("IdStudentMajorClasses")
                        .HasPrincipalKey("IdStudentMajorClasses")
                        .IsRequired()
                        .HasConstraintName("fk_DayLimitsForDayOffs_StudentMajorClasses1");

                    b.Navigation("IdStudentMajorClassesNavigation");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Endofsemesterexamscore", b =>
                {
                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Endofsemesterreport", "IdEndOfSemesterScoresNavigation")
                        .WithOne("Endofsemesterexamscore")
                        .HasForeignKey("My.HighSchoolProject.DataAccess.Models.Endofsemesterexamscore", "IdEndOfSemesterScores")
                        .HasPrincipalKey("My.HighSchoolProject.DataAccess.Models.Endofsemesterreport", "IdEndOfSemesterScores")
                        .IsRequired()
                        .HasConstraintName("fk_EndOfSemesterScores_has_ExamScores_EndOfSemesterScores1");

                    b.Navigation("IdEndOfSemesterScoresNavigation");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Endofsemesteropinionscore", b =>
                {
                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Endofsemesterreport", "IdEndOfSemesterScoresNavigation")
                        .WithOne("Endofsemesteropinionscore")
                        .HasForeignKey("My.HighSchoolProject.DataAccess.Models.Endofsemesteropinionscore", "IdEndOfSemesterScores")
                        .HasPrincipalKey("My.HighSchoolProject.DataAccess.Models.Endofsemesterreport", "IdEndOfSemesterScores")
                        .IsRequired()
                        .HasConstraintName("fk_EndOfSemesterScores_has_Teacher'sOpinionScores_EndOfSemest1");

                    b.Navigation("IdEndOfSemesterScoresNavigation");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Endofsemesterreport", b =>
                {
                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Course", "IdCourseNavigation")
                        .WithMany("Endofsemesterreports")
                        .HasForeignKey("IdCourse")
                        .HasPrincipalKey("IdCourse")
                        .IsRequired()
                        .HasConstraintName("fk_ExamResults_Courses1");

                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Schoolgeneralinfo", "IdSchoolGeneralInfoNavigation")
                        .WithMany("Endofsemesterreports")
                        .HasForeignKey("IdSchoolGeneralInfo")
                        .IsRequired()
                        .HasConstraintName("fk_EndOfSemesterReport_SchoolGeneralInfo1");

                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Semester", "IdSemesterNavigation")
                        .WithMany("Endofsemesterreports")
                        .HasForeignKey("IdSemester")
                        .IsRequired()
                        .HasConstraintName("fk_ExamResults_Semesters1");

                    b.HasOne("My.HighSchoolProject.DataAccess.BaseEntities.Student", "IdstudentNumberNavigation")
                        .WithMany("Endofsemesterreports")
                        .HasForeignKey("IdstudentNumber")
                        .IsRequired()
                        .HasConstraintName("fk_EndOfSemesterReport_Students1");

                    b.Navigation("IdCourseNavigation");

                    b.Navigation("IdSchoolGeneralInfoNavigation");

                    b.Navigation("IdSemesterNavigation");

                    b.Navigation("IdstudentNumberNavigation");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Examsschedule", b =>
                {
                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Classroomsgroup", "IdClassGroupNavigation")
                        .WithMany("Examsschedules")
                        .HasForeignKey("IdClassGroup")
                        .HasPrincipalKey("IdClassGroup")
                        .IsRequired()
                        .HasConstraintName("fk_Exams_ClassRoomsGroup1");

                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Course", "IdCourseNavigation")
                        .WithMany("Examsschedules")
                        .HasForeignKey("IdCourse")
                        .HasPrincipalKey("IdCourse")
                        .IsRequired()
                        .HasConstraintName("fk_Exams_Courses1");

                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Groupbystudentsmajorandclass", "IdGroupByStudentsMajorAndClassesNavigation")
                        .WithMany("Examsschedules")
                        .HasForeignKey("IdGroupByStudentsMajorAndClasses")
                        .HasPrincipalKey("IdGroupByStudentsMajorAndClasses")
                        .IsRequired()
                        .HasConstraintName("fk_Exams_GroupByStudentsMajorAndClasses1");

                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Semester", "IdSemestersNavigation")
                        .WithMany("Examsschedules")
                        .HasForeignKey("IdSemesters")
                        .IsRequired()
                        .HasConstraintName("fk_Exams_Semesters1");

                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Teacher", "IdTeachersNavigation")
                        .WithMany("Examsschedules")
                        .HasForeignKey("IdTeachers")
                        .HasPrincipalKey("IdTeachers")
                        .IsRequired()
                        .HasConstraintName("fk_Exams_Teachers1");

                    b.Navigation("IdClassGroupNavigation");

                    b.Navigation("IdCourseNavigation");

                    b.Navigation("IdGroupByStudentsMajorAndClassesNavigation");

                    b.Navigation("IdSemestersNavigation");

                    b.Navigation("IdTeachersNavigation");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Generalofficer", b =>
                {
                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Employee", "IdEmployeeNavigation")
                        .WithMany("Generalofficers")
                        .HasForeignKey("IdEmployee")
                        .IsRequired()
                        .HasConstraintName("fk_GeneralOfficers_Employees1");

                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Responsibility", "IdResponsibilitiesNavigation")
                        .WithMany("Generalofficers")
                        .HasForeignKey("IdResponsibilities")
                        .IsRequired()
                        .HasConstraintName("fk_GeneralOfficers_Responsibilities1");

                    b.Navigation("IdEmployeeNavigation");

                    b.Navigation("IdResponsibilitiesNavigation");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Groupbystudentsmajorandclass", b =>
                {
                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Studentgroupsbyclassandmajor", "IdMajorClassGroupsNavigation")
                        .WithMany("Groupbystudentsmajorandclasses")
                        .HasForeignKey("IdMajorClassGroups")
                        .HasPrincipalKey("IdMajorClassGroups")
                        .IsRequired()
                        .HasConstraintName("fk_StudentMajorClasses_has_StudentGroupsByClassAndMajor_Stude2");

                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Studentmajorclass", "IdStudentMajorClassesNavigation")
                        .WithMany("Groupbystudentsmajorandclasses")
                        .HasForeignKey("IdStudentMajorClasses")
                        .HasPrincipalKey("IdStudentMajorClasses")
                        .IsRequired()
                        .HasConstraintName("fk_StudentMajorClasses_has_StudentGroupsByClassAndMajor_Stude1");

                    b.Navigation("IdMajorClassGroupsNavigation");

                    b.Navigation("IdStudentMajorClassesNavigation");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.MajorsHasCourse", b =>
                {
                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Class", "IdClassesNavigation")
                        .WithMany("MajorsHasCourses")
                        .HasForeignKey("IdClasses")
                        .IsRequired()
                        .HasConstraintName("fk_Majors_has_Courses_Classes1");

                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Course", "IdCourseNavigation")
                        .WithMany("MajorsHasCourses")
                        .HasForeignKey("IdCourse")
                        .HasPrincipalKey("IdCourse")
                        .IsRequired()
                        .HasConstraintName("fk_Majors_has_Courses_Courses1");

                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Major", "IdMajorsNavigation")
                        .WithMany("MajorsHasCourses")
                        .HasForeignKey("IdMajors")
                        .IsRequired()
                        .HasConstraintName("fk_Majors_has_Courses_Majors1");

                    b.Navigation("IdClassesNavigation");

                    b.Navigation("IdCourseNavigation");

                    b.Navigation("IdMajorsNavigation");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Nonofficeremployee", b =>
                {
                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Employee", "IdEmployeeNavigation")
                        .WithMany("Nonofficeremployees")
                        .HasForeignKey("IdEmployee")
                        .IsRequired()
                        .HasConstraintName("fk_Non-OfficerEmployees_Employees1");

                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Responsibility", "IdResponsibilitiesNavigation")
                        .WithMany("Nonofficeremployees")
                        .HasForeignKey("IdResponsibilities")
                        .IsRequired()
                        .HasConstraintName("fk_Non-OfficerEmployees_Responsibilities1");

                    b.Navigation("IdEmployeeNavigation");

                    b.Navigation("IdResponsibilitiesNavigation");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Schoolmanagementattendant", b =>
                {
                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Branch", "IdBranchesNavigation")
                        .WithMany("Schoolmanagementattendants")
                        .HasForeignKey("IdBranches")
                        .IsRequired()
                        .HasConstraintName("fk_SchoolManagementAttendants_Branches1");

                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Employee", "IdEmployeeNavigation")
                        .WithMany("Schoolmanagementattendants")
                        .HasForeignKey("IdEmployee")
                        .IsRequired()
                        .HasConstraintName("fk_SchoolManagementAttendants_Employees1");

                    b.Navigation("IdBranchesNavigation");

                    b.Navigation("IdEmployeeNavigation");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Studentgroupsbyclassandmajor", b =>
                {
                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Semester", "IdSemestersNavigation")
                        .WithMany("Studentgroupsbyclassandmajors")
                        .HasForeignKey("IdSemesters")
                        .IsRequired()
                        .HasConstraintName("fk_StudentGroupsByClassAndMajor_Semesters1");

                    b.Navigation("IdSemestersNavigation");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Studentmajorclass", b =>
                {
                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Class", "IdClassesNavigation")
                        .WithMany("Studentmajorclasses")
                        .HasForeignKey("IdClasses")
                        .IsRequired()
                        .HasConstraintName("fk_Majors_has_Students_has_Classes_Classes1");

                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Major", "IdMajorsNavigation")
                        .WithMany("Studentmajorclasses")
                        .HasForeignKey("IdMajors")
                        .IsRequired()
                        .HasConstraintName("fk_StudentMajorClasses_Majors1");

                    b.HasOne("My.HighSchoolProject.DataAccess.BaseEntities.Student", "IdstudentNumberNavigation")
                        .WithMany("Studentmajorclasses")
                        .HasForeignKey("IdstudentNumber")
                        .IsRequired()
                        .HasConstraintName("fk_StudentMajorClasses_Students1");

                    b.Navigation("IdClassesNavigation");

                    b.Navigation("IdMajorsNavigation");

                    b.Navigation("IdstudentNumberNavigation");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Teacher", b =>
                {
                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Branch", "IdBranchesNavigation")
                        .WithMany("Teachers")
                        .HasForeignKey("IdBranches")
                        .IsRequired()
                        .HasConstraintName("fk_Teachers_Branches1");

                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Employee", "IdEmployeeNavigation")
                        .WithMany("Teachers")
                        .HasForeignKey("IdEmployee")
                        .IsRequired()
                        .HasConstraintName("fk_Teachers_Employees1");

                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Responsibility", "IdResponsibilitiesNavigation")
                        .WithMany("Teachers")
                        .HasForeignKey("IdResponsibilities")
                        .IsRequired()
                        .HasConstraintName("fk_Teachers_Responsibilities1");

                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Schoolmanagementattendant", "IdTeachersNavigation")
                        .WithOne("Teacher")
                        .HasForeignKey("My.HighSchoolProject.DataAccess.Models.Teacher", "IdTeachers")
                        .HasPrincipalKey("My.HighSchoolProject.DataAccess.Models.Schoolmanagementattendant", "IdTeacher")
                        .IsRequired()
                        .HasConstraintName("fk_Teachers_SchoolManagementAttendants1");

                    b.Navigation("IdBranchesNavigation");

                    b.Navigation("IdEmployeeNavigation");

                    b.Navigation("IdResponsibilitiesNavigation");

                    b.Navigation("IdTeachersNavigation");
                });

            modelBuilder.Entity("Schoolmanagementattendantsresponsibility", b =>
                {
                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Responsibility", null)
                        .WithMany()
                        .HasForeignKey("IdResponsibilities")
                        .IsRequired()
                        .HasConstraintName("fk_SchoolManagementAttendants_has_Responsibilities_Responsibi1");

                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Schoolmanagementattendant", null)
                        .WithMany()
                        .HasForeignKey("IdTeacher")
                        .HasPrincipalKey("IdTeacher")
                        .IsRequired()
                        .HasConstraintName("fk_SchoolManagementAttendants_has_Responsibilities_SchoolMana1");
                });

            modelBuilder.Entity("StudentsdayoffHasStudent", b =>
                {
                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Studentsdayoff", null)
                        .WithMany()
                        .HasForeignKey("IdStudentsDayoff")
                        .IsRequired()
                        .HasConstraintName("fk_StudentsDayoff_has_Students_StudentsDayoff1");

                    b.HasOne("My.HighSchoolProject.DataAccess.BaseEntities.Student", null)
                        .WithMany()
                        .HasForeignKey("IdstudentNumber")
                        .IsRequired()
                        .HasConstraintName("fk_StudentsDayoff_has_Students_Students1");
                });

            modelBuilder.Entity("TeachersHasCourse", b =>
                {
                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("IdCourse")
                        .HasPrincipalKey("IdCourse")
                        .IsRequired()
                        .HasConstraintName("fk_Teachers_has_Courses_Courses1");

                    b.HasOne("My.HighSchoolProject.DataAccess.Models.Teacher", null)
                        .WithMany()
                        .HasForeignKey("IdTeachers")
                        .HasPrincipalKey("IdTeachers")
                        .IsRequired()
                        .HasConstraintName("fk_Teachers_has_Courses_Teachers1");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.BaseEntities.Student", b =>
                {
                    b.Navigation("Contacts");

                    b.Navigation("Endofsemesterreports");

                    b.Navigation("Studentmajorclasses");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Branch", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Schoolmanagementattendants");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Class", b =>
                {
                    b.Navigation("Classroomsgroups");

                    b.Navigation("MajorsHasCourses");

                    b.Navigation("Studentmajorclasses");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Classroom", b =>
                {
                    b.Navigation("Classroomsgroups");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Classroomsgroup", b =>
                {
                    b.Navigation("Classroomsandcourses");

                    b.Navigation("Courseschedules");

                    b.Navigation("Examsschedules");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Course", b =>
                {
                    b.Navigation("Classroomsgroups");

                    b.Navigation("Courseschedules");

                    b.Navigation("Endofsemesterreports");

                    b.Navigation("Examsschedules");

                    b.Navigation("MajorsHasCourses");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Employee", b =>
                {
                    b.Navigation("Generalofficers");

                    b.Navigation("Nonofficeremployees");

                    b.Navigation("Schoolmanagementattendants");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Endofsemesterreport", b =>
                {
                    b.Navigation("Endofsemesterexamscore");

                    b.Navigation("Endofsemesteropinionscore");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Groupbystudentsmajorandclass", b =>
                {
                    b.Navigation("Classroomsandcourses");

                    b.Navigation("Courseschedules");

                    b.Navigation("Examsschedules");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Major", b =>
                {
                    b.Navigation("MajorsHasCourses");

                    b.Navigation("Studentmajorclasses");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.MajorsHasCourse", b =>
                {
                    b.Navigation("Classroomsandcourses");

                    b.Navigation("Coursehoursbymajorclasses");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Responsibility", b =>
                {
                    b.Navigation("Generalofficers");

                    b.Navigation("Nonofficeremployees");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Schoolgeneralinfo", b =>
                {
                    b.Navigation("Endofsemesterreports");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Schoolmanagementattendant", b =>
                {
                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Semester", b =>
                {
                    b.Navigation("Classroomsgroups");

                    b.Navigation("Endofsemesterreports");

                    b.Navigation("Examsschedules");

                    b.Navigation("Studentgroupsbyclassandmajors");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Studentgroupsbyclassandmajor", b =>
                {
                    b.Navigation("Groupbystudentsmajorandclasses");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Studentmajorclass", b =>
                {
                    b.Navigation("Coursehoursbymajorclasses");

                    b.Navigation("Daylimitsfordayoffs");

                    b.Navigation("Groupbystudentsmajorandclasses");
                });

            modelBuilder.Entity("My.HighSchoolProject.DataAccess.Models.Teacher", b =>
                {
                    b.Navigation("Courseschedules");

                    b.Navigation("Examsschedules");
                });
        }
    }
}
