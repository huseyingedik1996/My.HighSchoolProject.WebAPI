using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace My.HighSchoolProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentsDayoffhasStudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "classrooms",
                columns: table => new
                {
                    IdClassRooms = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ClassRoomName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    ClassRoomCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.IdClassRooms);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    idEmployee = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Surname = table.Column<string>(type: "varchar(18)", maxLength: 18, nullable: false),
                    ContactNumber = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false),
                    EmailAdress = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    HomeAdress = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    PersonalTC = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    Wage = table.Column<float>(type: "float", nullable: true),
                    RegistryDate = table.Column<DateTime>(type: "date", nullable: true),
                    LastEdit = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idEmployee);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "employeesdayoff",
                columns: table => new
                {
                    idEmployeesDayOff = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Reason = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    DoctorReport = table.Column<sbyte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idEmployeesDayOff);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "majors",
                columns: table => new
                {
                    IdMajors = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    MajorsName = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    QuataLimit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.IdMajors);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "responsibilities",
                columns: table => new
                {
                    idResponsibilities = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Respobsibility = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idResponsibilities);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "schoolgeneralinfo",
                columns: table => new
                {
                    idSchoolGeneralInfo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SchoolName = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    SchoolAddress = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    SchoolDegree = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    FoundationYear = table.Column<int>(type: "int", nullable: false),
                    SchoolWebSite = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idSchoolGeneralInfo);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "semesters",
                columns: table => new
                {
                    idSemesters = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Semester = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    Period = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idSemesters);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    IdstudentNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Surname = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    RegistryYear = table.Column<int>(type: "int", nullable: false),
                    StudentTC = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    FailCount = table.Column<int>(type: "int", nullable: true),
                    RightToEducation = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    LastEdit = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.IdstudentNumber);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "studentsdayoff",
                columns: table => new
                {
                    idStudentsDayoff = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Reason = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    DoctorReport = table.Column<sbyte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idStudentsDayoff);
                })
                .Annotation("MySQL:Charset", "utf8mb4");


            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    idCourse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    idBranches = table.Column<int>(type: "int", nullable: false),
                    CourseName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.idCourse, x.idBranches });
                    table.UniqueConstraint("AK_courses_idCourse", x => x.idCourse);
                    table.ForeignKey(
                        name: "fk_Courses_Branches1",
                        column: x => x.idBranches,
                        principalTable: "branches",
                        principalColumn: "idBranches");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "schoolmanagementattendants",
                columns: table => new
                {
                    idTeacher = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    idEmployee = table.Column<int>(type: "int", nullable: false),
                    idBranches = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.idTeacher, x.idEmployee, x.idBranches });
                    table.UniqueConstraint("AK_schoolmanagementattendants_idTeacher", x => x.idTeacher);
                    table.ForeignKey(
                        name: "fk_SchoolManagementAttendants_Branches1",
                        column: x => x.idBranches,
                        principalTable: "branches",
                        principalColumn: "idBranches");
                    table.ForeignKey(
                        name: "fk_SchoolManagementAttendants_Employees1",
                        column: x => x.idEmployee,
                        principalTable: "employees",
                        principalColumn: "idEmployee");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "employeesdayoffinfos",
                columns: table => new
                {
                    idEmployee = table.Column<int>(type: "int", nullable: false),
                    idPersonalsDayoff = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.idEmployee, x.idPersonalsDayoff });
                    table.ForeignKey(
                        name: "fk_Employees_has_EmployeesDayOff_Employees1",
                        column: x => x.idEmployee,
                        principalTable: "employees",
                        principalColumn: "idEmployee");
                    table.ForeignKey(
                        name: "fk_Employees_has_EmployeesDayOff_EmployeesDayOff1",
                        column: x => x.idPersonalsDayoff,
                        principalTable: "employeesdayoff",
                        principalColumn: "idEmployeesDayOff");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "generalofficers",
                columns: table => new
                {
                    idGeneralOfficers = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    idEmployee = table.Column<int>(type: "int", nullable: false),
                    idResponsibilities = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.idGeneralOfficers, x.idEmployee, x.idResponsibilities });
                    table.ForeignKey(
                        name: "fk_GeneralOfficers_Employees1",
                        column: x => x.idEmployee,
                        principalTable: "employees",
                        principalColumn: "idEmployee");
                    table.ForeignKey(
                        name: "fk_GeneralOfficers_Responsibilities1",
                        column: x => x.idResponsibilities,
                        principalTable: "responsibilities",
                        principalColumn: "idResponsibilities");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "nonofficeremployees",
                columns: table => new
                {
                    idNonOfficerEmployees = table.Column<int>(name: "idNon-OfficerEmployees", type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    idEmployee = table.Column<int>(type: "int", nullable: false),
                    idResponsibilities = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.idNonOfficerEmployees, x.idEmployee, x.idResponsibilities });
                    table.ForeignKey(
                        name: "fk_Non-OfficerEmployees_Employees1",
                        column: x => x.idEmployee,
                        principalTable: "employees",
                        principalColumn: "idEmployee");
                    table.ForeignKey(
                        name: "fk_Non-OfficerEmployees_Responsibilities1",
                        column: x => x.idResponsibilities,
                        principalTable: "responsibilities",
                        principalColumn: "idResponsibilities");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "studentgroupsbyclassandmajor",
                columns: table => new
                {
                    IdMajorClassGroups = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    idSemesters = table.Column<int>(type: "int", nullable: false),
                    GroupCode = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.IdMajorClassGroups, x.idSemesters });
                    table.UniqueConstraint("AK_studentgroupsbyclassandmajor_IdMajorClassGroups", x => x.IdMajorClassGroups);
                    table.ForeignKey(
                        name: "fk_StudentGroupsByClassAndMajor_Semesters1",
                        column: x => x.idSemesters,
                        principalTable: "semesters",
                        principalColumn: "idSemesters");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    IdContacts = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdstudentNumber = table.Column<int>(type: "int", nullable: false),
                    StudentsPhone = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false),
                    StudentsEmail = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    StudentParentPhone = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false),
                    StudentsParentEmail = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    StudentsAddress = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    ParentName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    ParentSurname = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    City = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true),
                    Region = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.IdContacts, x.IdstudentNumber });
                    table.ForeignKey(
                        name: "fk_Contacts_Students1",
                        column: x => x.IdstudentNumber,
                        principalTable: "students",
                        principalColumn: "IdstudentNumber");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "studentmajorclasses",
                columns: table => new
                {
                    IdStudentMajorClasses = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdClasses = table.Column<int>(type: "int", nullable: false),
                    IdMajors = table.Column<int>(type: "int", nullable: false),
                    IdstudentNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.IdStudentMajorClasses, x.IdClasses, x.IdMajors, x.IdstudentNumber });
                    table.UniqueConstraint("AK_studentmajorclasses_IdStudentMajorClasses", x => x.IdStudentMajorClasses);
                    table.ForeignKey(
                        name: "fk_Majors_has_Students_has_Classes_Classes1",
                        column: x => x.IdClasses,
                        principalTable: "classes",
                        principalColumn: "IdClasses");
                    table.ForeignKey(
                        name: "fk_StudentMajorClasses_Majors1",
                        column: x => x.IdMajors,
                        principalTable: "majors",
                        principalColumn: "IdMajors");
                    table.ForeignKey(
                        name: "fk_StudentMajorClasses_Students1",
                        column: x => x.IdstudentNumber,
                        principalTable: "students",
                        principalColumn: "IdstudentNumber");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "studentsdayoff_has_students",
                columns: table => new
                {
                    idStudentsDayoff = table.Column<int>(type: "int", nullable: false),
                    IdstudentNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.idStudentsDayoff, x.IdstudentNumber });
                    table.ForeignKey(
                        name: "fk_StudentsDayoff_has_Students_Students1",
                        column: x => x.IdstudentNumber,
                        principalTable: "students",
                        principalColumn: "IdstudentNumber");
                    table.ForeignKey(
                        name: "fk_StudentsDayoff_has_Students_StudentsDayoff1",
                        column: x => x.idStudentsDayoff,
                        principalTable: "studentsdayoff",
                        principalColumn: "idStudentsDayoff");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "classroomsgroup",
                columns: table => new
                {
                    IdClassGroup = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdClass = table.Column<int>(type: "int", nullable: false),
                    IdClassRooms = table.Column<int>(type: "int", nullable: false),
                    idSemesters = table.Column<int>(type: "int", nullable: false),
                    idCourse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.IdClassGroup, x.IdClass, x.IdClassRooms, x.idSemesters, x.idCourse });
                    table.UniqueConstraint("AK_classroomsgroup_IdClassGroup", x => x.IdClassGroup);
                    table.ForeignKey(
                        name: "fk_ClassRoomsAndMajors_Classes1",
                        column: x => x.IdClass,
                        principalTable: "classes",
                        principalColumn: "IdClasses");
                    table.ForeignKey(
                        name: "fk_ClassRoomsAndMajors_Semesters1",
                        column: x => x.idSemesters,
                        principalTable: "semesters",
                        principalColumn: "idSemesters");
                    table.ForeignKey(
                        name: "fk_ClassRoomsGroup_Courses1",
                        column: x => x.idCourse,
                        principalTable: "courses",
                        principalColumn: "idCourse");
                    table.ForeignKey(
                        name: "fk_Classes_has_Classes_has_Majors_ClassRooms1",
                        column: x => x.IdClassRooms,
                        principalTable: "classrooms",
                        principalColumn: "IdClassRooms");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "endofsemesterreport",
                columns: table => new
                {
                    IdEndOfSemesterScores = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdstudentNumber = table.Column<int>(type: "int", nullable: false),
                    idSemester = table.Column<int>(type: "int", nullable: false),
                    IdCourse = table.Column<int>(type: "int", nullable: false),
                    idSchoolGeneralInfo = table.Column<int>(type: "int", nullable: false),
                    AvarageScore = table.Column<int>(type: "int", nullable: true),
                    TotalDayOffWithReport = table.Column<int>(type: "int", nullable: true),
                    TotalDayOfWithoutReport = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.IdEndOfSemesterScores, x.IdstudentNumber, x.idSemester, x.IdCourse, x.idSchoolGeneralInfo });
                    table.UniqueConstraint("AK_endofsemesterreport_IdEndOfSemesterScores", x => x.IdEndOfSemesterScores);
                    table.ForeignKey(
                        name: "fk_EndOfSemesterReport_SchoolGeneralInfo1",
                        column: x => x.idSchoolGeneralInfo,
                        principalTable: "schoolgeneralinfo",
                        principalColumn: "idSchoolGeneralInfo");
                    table.ForeignKey(
                        name: "fk_EndOfSemesterReport_Students1",
                        column: x => x.IdstudentNumber,
                        principalTable: "students",
                        principalColumn: "IdstudentNumber");
                    table.ForeignKey(
                        name: "fk_ExamResults_Courses1",
                        column: x => x.IdCourse,
                        principalTable: "courses",
                        principalColumn: "idCourse");
                    table.ForeignKey(
                        name: "fk_ExamResults_Semesters1",
                        column: x => x.idSemester,
                        principalTable: "semesters",
                        principalColumn: "idSemesters");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "majors_has_courses",
                columns: table => new
                {
                    IdMajorsCourses = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdMajors = table.Column<int>(type: "int", nullable: false),
                    idCourse = table.Column<int>(type: "int", nullable: false),
                    IdClasses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.IdMajorsCourses, x.IdMajors, x.idCourse, x.IdClasses });
                    table.UniqueConstraint("AK_majors_has_courses_IdMajorsCourses", x => x.IdMajorsCourses);
                    table.ForeignKey(
                        name: "fk_Majors_has_Courses_Classes1",
                        column: x => x.IdClasses,
                        principalTable: "classes",
                        principalColumn: "IdClasses");
                    table.ForeignKey(
                        name: "fk_Majors_has_Courses_Courses1",
                        column: x => x.idCourse,
                        principalTable: "courses",
                        principalColumn: "idCourse");
                    table.ForeignKey(
                        name: "fk_Majors_has_Courses_Majors1",
                        column: x => x.IdMajors,
                        principalTable: "majors",
                        principalColumn: "IdMajors");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "schoolmanagementattendantsresponsibilities",
                columns: table => new
                {
                    idTeacher = table.Column<int>(type: "int", nullable: false),
                    idResponsibilities = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.idTeacher, x.idResponsibilities });
                    table.ForeignKey(
                        name: "fk_SchoolManagementAttendants_has_Responsibilities_Responsibi1",
                        column: x => x.idResponsibilities,
                        principalTable: "responsibilities",
                        principalColumn: "idResponsibilities");
                    table.ForeignKey(
                        name: "fk_SchoolManagementAttendants_has_Responsibilities_SchoolMana1",
                        column: x => x.idTeacher,
                        principalTable: "schoolmanagementattendants",
                        principalColumn: "idTeacher");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "teachers",
                columns: table => new
                {
                    idTeachers = table.Column<int>(type: "int", nullable: false),
                    idEmployee = table.Column<int>(type: "int", nullable: false),
                    idBranches = table.Column<int>(type: "int", nullable: false),
                    idResponsibilities = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.idTeachers, x.idEmployee, x.idBranches, x.idResponsibilities });
                    table.UniqueConstraint("AK_teachers_idTeachers", x => x.idTeachers);
                    table.ForeignKey(
                        name: "fk_Teachers_Branches1",
                        column: x => x.idBranches,
                        principalTable: "branches",
                        principalColumn: "idBranches");
                    table.ForeignKey(
                        name: "fk_Teachers_Employees1",
                        column: x => x.idEmployee,
                        principalTable: "employees",
                        principalColumn: "idEmployee");
                    table.ForeignKey(
                        name: "fk_Teachers_Responsibilities1",
                        column: x => x.idResponsibilities,
                        principalTable: "responsibilities",
                        principalColumn: "idResponsibilities");
                    table.ForeignKey(
                        name: "fk_Teachers_SchoolManagementAttendants1",
                        column: x => x.idTeachers,
                        principalTable: "schoolmanagementattendants",
                        principalColumn: "idTeacher");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "daylimitsfordayoffs",
                columns: table => new
                {
                    idDayLimitsForDayOffs = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdStudentMajorClasses = table.Column<int>(type: "int", nullable: false),
                    DayLimitForClass = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.idDayLimitsForDayOffs, x.IdStudentMajorClasses });
                    table.ForeignKey(
                        name: "fk_DayLimitsForDayOffs_StudentMajorClasses1",
                        column: x => x.IdStudentMajorClasses,
                        principalTable: "studentmajorclasses",
                        principalColumn: "IdStudentMajorClasses");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "groupbystudentsmajorandclasses",
                columns: table => new
                {
                    IdGroupByStudentsMajorAndClasses = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdStudentMajorClasses = table.Column<int>(type: "int", nullable: false),
                    IdMajorClassGroups = table.Column<int>(type: "int", nullable: false),
                    GroupCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.IdGroupByStudentsMajorAndClasses, x.IdStudentMajorClasses, x.IdMajorClassGroups });
                    table.UniqueConstraint("AK_groupbystudentsmajorandclasses_IdGroupByStudentsMajorAndClas~", x => x.IdGroupByStudentsMajorAndClasses);
                    table.ForeignKey(
                        name: "fk_StudentMajorClasses_has_StudentGroupsByClassAndMajor_Stude1",
                        column: x => x.IdStudentMajorClasses,
                        principalTable: "studentmajorclasses",
                        principalColumn: "IdStudentMajorClasses");
                    table.ForeignKey(
                        name: "fk_StudentMajorClasses_has_StudentGroupsByClassAndMajor_Stude2",
                        column: x => x.IdMajorClassGroups,
                        principalTable: "studentgroupsbyclassandmajor",
                        principalColumn: "IdMajorClassGroups");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "endofsemesterexamscores",
                columns: table => new
                {
                    IdEndOfSemesterScores = table.Column<int>(type: "int", nullable: false),
                    idExamsScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.IdEndOfSemesterScores);
                    table.ForeignKey(
                        name: "fk_EndOfSemesterScores_has_ExamScores_EndOfSemesterScores1",
                        column: x => x.IdEndOfSemesterScores,
                        principalTable: "endofsemesterreport",
                        principalColumn: "IdEndOfSemesterScores");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "endofsemesteropinionscores",
                columns: table => new
                {
                    IdEndOfSemesterScores = table.Column<int>(type: "int", nullable: false),
                    idTeachersOpinionScores = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.IdEndOfSemesterScores);
                    table.ForeignKey(
                        name: "fk_EndOfSemesterScores_has_Teacher'sOpinionScores_EndOfSemest1",
                        column: x => x.IdEndOfSemesterScores,
                        principalTable: "endofsemesterreport",
                        principalColumn: "IdEndOfSemesterScores");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "coursehoursbymajorclasses",
                columns: table => new
                {
                    idCourseHoursByMajorClasses = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdMajorsCourses = table.Column<int>(type: "int", nullable: false),
                    IdStudentMajorClasses = table.Column<int>(type: "int", nullable: false),
                    CourseHourPerWeek = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.idCourseHoursByMajorClasses, x.IdMajorsCourses, x.IdStudentMajorClasses });
                    table.ForeignKey(
                        name: "fk_CourseHoursByMajorClasses_Majors_has_Courses1",
                        column: x => x.IdMajorsCourses,
                        principalTable: "majors_has_courses",
                        principalColumn: "IdMajorsCourses");
                    table.ForeignKey(
                        name: "fk_CourseHoursByMajorClasses_StudentMajorClasses1",
                        column: x => x.IdStudentMajorClasses,
                        principalTable: "studentmajorclasses",
                        principalColumn: "IdStudentMajorClasses");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "teachers_has_courses",
                columns: table => new
                {
                    idTeachers = table.Column<int>(type: "int", nullable: false),
                    idCourse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.idTeachers, x.idCourse });
                    table.ForeignKey(
                        name: "fk_Teachers_has_Courses_Courses1",
                        column: x => x.idCourse,
                        principalTable: "courses",
                        principalColumn: "idCourse");
                    table.ForeignKey(
                        name: "fk_Teachers_has_Courses_Teachers1",
                        column: x => x.idTeachers,
                        principalTable: "teachers",
                        principalColumn: "idTeachers");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "classroomsandcourses",
                columns: table => new
                {
                    IdClassRoomsAndGroups = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdClassGroup = table.Column<int>(type: "int", nullable: false),
                    IdMajorsCourses = table.Column<int>(type: "int", nullable: false),
                    IdGroupByStudentsMajorAndClasses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.IdClassRoomsAndGroups, x.IdClassGroup, x.IdMajorsCourses, x.IdGroupByStudentsMajorAndClasses });
                    table.ForeignKey(
                        name: "fk_ClassRoomsAndCourses_GroupByStudentsMajorAndClasses1",
                        column: x => x.IdGroupByStudentsMajorAndClasses,
                        principalTable: "groupbystudentsmajorandclasses",
                        principalColumn: "IdGroupByStudentsMajorAndClasses");
                    table.ForeignKey(
                        name: "fk_ClassRoomsGroup_has_Majors_has_Courses_ClassRoomsGroup1",
                        column: x => x.IdClassGroup,
                        principalTable: "classroomsgroup",
                        principalColumn: "IdClassGroup");
                    table.ForeignKey(
                        name: "fk_ClassRoomsGroup_has_Majors_has_Courses_Majors_has_Courses1",
                        column: x => x.IdMajorsCourses,
                        principalTable: "majors_has_courses",
                        principalColumn: "IdMajorsCourses");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "courseschedules",
                columns: table => new
                {
                    idCourseSchedules = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdClassGroup = table.Column<int>(type: "int", nullable: false),
                    idTeachers = table.Column<int>(type: "int", nullable: false),
                    idCourse = table.Column<int>(type: "int", nullable: false),
                    IdGroupByStudentsMajorAndClasses = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    DayOfWeek = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.idCourseSchedules, x.IdClassGroup, x.idTeachers, x.idCourse, x.IdGroupByStudentsMajorAndClasses });
                    table.ForeignKey(
                        name: "fk_CourseSchedules_ClassRoomsGroup1",
                        column: x => x.IdClassGroup,
                        principalTable: "classroomsgroup",
                        principalColumn: "IdClassGroup");
                    table.ForeignKey(
                        name: "fk_CourseSchedules_Courses1",
                        column: x => x.idCourse,
                        principalTable: "courses",
                        principalColumn: "idCourse");
                    table.ForeignKey(
                        name: "fk_CourseSchedules_GroupByStudentsMajorAndClasses1",
                        column: x => x.IdGroupByStudentsMajorAndClasses,
                        principalTable: "groupbystudentsmajorandclasses",
                        principalColumn: "IdGroupByStudentsMajorAndClasses");
                    table.ForeignKey(
                        name: "fk_CourseSchedules_Teachers1",
                        column: x => x.idTeachers,
                        principalTable: "teachers",
                        principalColumn: "idTeachers");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "examsschedules",
                columns: table => new
                {
                    idExams = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    idCourse = table.Column<int>(type: "int", nullable: false),
                    idSemesters = table.Column<int>(type: "int", nullable: false),
                    IdGroupByStudentsMajorAndClasses = table.Column<int>(type: "int", nullable: false),
                    IdClassGroup = table.Column<int>(type: "int", nullable: false),
                    idTeachers = table.Column<int>(type: "int", nullable: false),
                    ExamDate = table.Column<DateTime>(type: "date", nullable: false),
                    ExamTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.idExams, x.idCourse, x.idSemesters, x.IdGroupByStudentsMajorAndClasses, x.IdClassGroup, x.idTeachers });
                    table.ForeignKey(
                        name: "fk_Exams_ClassRoomsGroup1",
                        column: x => x.IdClassGroup,
                        principalTable: "classroomsgroup",
                        principalColumn: "IdClassGroup");
                    table.ForeignKey(
                        name: "fk_Exams_Courses1",
                        column: x => x.idCourse,
                        principalTable: "courses",
                        principalColumn: "idCourse");
                    table.ForeignKey(
                        name: "fk_Exams_GroupByStudentsMajorAndClasses1",
                        column: x => x.IdGroupByStudentsMajorAndClasses,
                        principalTable: "groupbystudentsmajorandclasses",
                        principalColumn: "IdGroupByStudentsMajorAndClasses");
                    table.ForeignKey(
                        name: "fk_Exams_Semesters1",
                        column: x => x.idSemesters,
                        principalTable: "semesters",
                        principalColumn: "idSemesters");
                    table.ForeignKey(
                        name: "fk_Exams_Teachers1",
                        column: x => x.idTeachers,
                        principalTable: "teachers",
                        principalColumn: "idTeachers");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "BrancheName_UNIQUE",
                table: "branches",
                column: "BranchName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idBranches_UNIQUE",
                table: "branches",
                column: "idBranches",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ClassNumber_UNIQUE",
                table: "classes",
                column: "ClassNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Id_UNIQUE",
                table: "classes",
                column: "IdClasses",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ClassRoomName_UNIQUE",
                table: "classrooms",
                column: "ClassRoomName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IdClassRooms_UNIQUE",
                table: "classrooms",
                column: "IdClassRooms",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ClassRoomsAndCoursescol_UNIQUE",
                table: "classroomsandcourses",
                column: "IdClassRoomsAndGroups",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_ClassRoomsAndCourses_GroupByStudentsMajorAndClasses1_idx",
                table: "classroomsandcourses",
                column: "IdGroupByStudentsMajorAndClasses");

            migrationBuilder.CreateIndex(
                name: "fk_ClassRoomsGroup_has_Majors_has_Courses_ClassRoomsGroup1_idx",
                table: "classroomsandcourses",
                column: "IdClassGroup");

            migrationBuilder.CreateIndex(
                name: "fk_ClassRoomsGroup_has_Majors_has_Courses_Majors_has_Course_idx",
                table: "classroomsandcourses",
                column: "IdMajorsCourses");

            migrationBuilder.CreateIndex(
                name: "fk_Classes_has_Classes_has_Majors_ClassRooms1_idx",
                table: "classroomsgroup",
                column: "IdClassRooms");

            migrationBuilder.CreateIndex(
                name: "fk_ClassRoomsAndMajors_Classes1_idx",
                table: "classroomsgroup",
                column: "IdClass");

            migrationBuilder.CreateIndex(
                name: "fk_ClassRoomsAndMajors_Semesters1_idx",
                table: "classroomsgroup",
                column: "idSemesters");

            migrationBuilder.CreateIndex(
                name: "fk_ClassRoomsGroup_Courses1_idx",
                table: "classroomsgroup",
                column: "idCourse");

            migrationBuilder.CreateIndex(
                name: "IdClassWithMajors_UNIQUE",
                table: "classroomsgroup",
                column: "IdClassGroup",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_Contacts_Students1_idx",
                table: "contacts",
                column: "IdstudentNumber");

            migrationBuilder.CreateIndex(
                name: "StudentEmail_UNIQUE",
                table: "contacts",
                column: "StudentsEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "StudentParentPhone_UNIQUE",
                table: "contacts",
                column: "StudentParentPhone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "StudentPhone_UNIQUE",
                table: "contacts",
                column: "StudentsPhone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "StudentsParentEmail_UNIQUE",
                table: "contacts",
                column: "StudentsParentEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_CourseHoursByMajorClasses_Majors_has_Courses1_idx",
                table: "coursehoursbymajorclasses",
                column: "IdMajorsCourses");

            migrationBuilder.CreateIndex(
                name: "fk_CourseHoursByMajorClasses_StudentMajorClasses1_idx",
                table: "coursehoursbymajorclasses",
                column: "IdStudentMajorClasses");

            migrationBuilder.CreateIndex(
                name: "idCourseHoursByMajorClasses_UNIQUE",
                table: "coursehoursbymajorclasses",
                column: "idCourseHoursByMajorClasses",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "CourseName_UNIQUE",
                table: "courses",
                column: "CourseName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_Courses_Branches1_idx",
                table: "courses",
                column: "idBranches");

            migrationBuilder.CreateIndex(
                name: "idCourse_UNIQUE",
                table: "courses",
                column: "idCourse",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_CourseSchedules_ClassRoomsGroup1_idx",
                table: "courseschedules",
                column: "IdClassGroup");

            migrationBuilder.CreateIndex(
                name: "fk_CourseSchedules_Courses1_idx",
                table: "courseschedules",
                column: "idCourse");

            migrationBuilder.CreateIndex(
                name: "fk_CourseSchedules_GroupByStudentsMajorAndClasses1_idx",
                table: "courseschedules",
                column: "IdGroupByStudentsMajorAndClasses");

            migrationBuilder.CreateIndex(
                name: "fk_CourseSchedules_Teachers1_idx",
                table: "courseschedules",
                column: "idTeachers");

            migrationBuilder.CreateIndex(
                name: "idCourseSchedules_UNIQUE",
                table: "courseschedules",
                column: "idCourseSchedules",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_DayLimitsForDayOffs_StudentMajorClasses1_idx",
                table: "daylimitsfordayoffs",
                column: "IdStudentMajorClasses");

            migrationBuilder.CreateIndex(
                name: "idDayLimitsForDayOffs_UNIQUE",
                table: "daylimitsfordayoffs",
                column: "idDayLimitsForDayOffs",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ContactNumber_UNIQUE",
                table: "employees",
                column: "ContactNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EmailAdress_UNIQUE",
                table: "employees",
                column: "EmailAdress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idTeachers_UNIQUE",
                table: "employees",
                column: "idEmployee",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "TeachersTC_UNIQUE",
                table: "employees",
                column: "PersonalTC",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idStudentsDayoff_UNIQUE",
                table: "employeesdayoff",
                column: "idEmployeesDayOff",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_Employees_has_EmployeesDayOff_Employees1_idx",
                table: "employeesdayoffinfos",
                column: "idEmployee");

            migrationBuilder.CreateIndex(
                name: "fk_Employees_has_EmployeesDayOff_EmployeesDayOff1_idx",
                table: "employeesdayoffinfos",
                column: "idPersonalsDayoff");

            migrationBuilder.CreateIndex(
                name: "fk_EndOfSemesterScores_has_ExamScores_EndOfSemesterScores1_idx",
                table: "endofsemesterexamscores",
                column: "IdEndOfSemesterScores");

            migrationBuilder.CreateIndex(
                name: "fk_EndOfSemesterScores_has_Teacher'sOpinionScores_EndOfSeme_idx",
                table: "endofsemesteropinionscores",
                column: "IdEndOfSemesterScores");

            migrationBuilder.CreateIndex(
                name: "fk_EndOfSemesterReport_SchoolGeneralInfo1_idx",
                table: "endofsemesterreport",
                column: "idSchoolGeneralInfo");

            migrationBuilder.CreateIndex(
                name: "fk_EndOfSemesterReport_Students1_idx",
                table: "endofsemesterreport",
                column: "IdstudentNumber");

            migrationBuilder.CreateIndex(
                name: "fk_ExamResults_Courses1_idx",
                table: "endofsemesterreport",
                column: "IdCourse");

            migrationBuilder.CreateIndex(
                name: "fk_ExamResults_Semesters1_idx",
                table: "endofsemesterreport",
                column: "idSemester");

            migrationBuilder.CreateIndex(
                name: "IdExamResult_UNIQUE",
                table: "endofsemesterreport",
                column: "IdEndOfSemesterScores",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_Exams_ClassRoomsGroup1_idx",
                table: "examsschedules",
                column: "IdClassGroup");

            migrationBuilder.CreateIndex(
                name: "fk_Exams_Courses1_idx",
                table: "examsschedules",
                column: "idCourse");

            migrationBuilder.CreateIndex(
                name: "fk_Exams_GroupByStudentsMajorAndClasses1_idx",
                table: "examsschedules",
                column: "IdGroupByStudentsMajorAndClasses");

            migrationBuilder.CreateIndex(
                name: "fk_Exams_Semesters1_idx",
                table: "examsschedules",
                column: "idSemesters");

            migrationBuilder.CreateIndex(
                name: "fk_Exams_Teachers1_idx",
                table: "examsschedules",
                column: "idTeachers");

            migrationBuilder.CreateIndex(
                name: "idExams_UNIQUE",
                table: "examsschedules",
                column: "idExams",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_GeneralOfficers_Employees1_idx",
                table: "generalofficers",
                column: "idEmployee");

            migrationBuilder.CreateIndex(
                name: "fk_GeneralOfficers_Responsibilities1_idx",
                table: "generalofficers",
                column: "idResponsibilities");

            migrationBuilder.CreateIndex(
                name: "idGeneralOfficers_UNIQUE",
                table: "generalofficers",
                column: "idGeneralOfficers",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_StudentMajorClasses_has_StudentGroupsByClassAndMajor_Stu_idx",
                table: "groupbystudentsmajorandclasses",
                column: "IdMajorClassGroups");

            migrationBuilder.CreateIndex(
                name: "fk_StudentMajorClasses_has_StudentGroupsByClassAndMajor_Stu_idx1",
                table: "groupbystudentsmajorandclasses",
                column: "IdStudentMajorClasses");

            migrationBuilder.CreateIndex(
                name: "IdGroupByStudentsMajorAndClasses_UNIQUE",
                table: "groupbystudentsmajorandclasses",
                column: "IdGroupByStudentsMajorAndClasses",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IdMajors_UNIQUE",
                table: "majors",
                column: "IdMajors",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "MajorsName_UNIQUE",
                table: "majors",
                column: "MajorsName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_Majors_has_Courses_Classes1_idx",
                table: "majors_has_courses",
                column: "IdClasses");

            migrationBuilder.CreateIndex(
                name: "fk_Majors_has_Courses_Courses1_idx",
                table: "majors_has_courses",
                column: "idCourse");

            migrationBuilder.CreateIndex(
                name: "fk_Majors_has_Courses_Majors1_idx",
                table: "majors_has_courses",
                column: "IdMajors");

            migrationBuilder.CreateIndex(
                name: "IdMajorsCourses_UNIQUE",
                table: "majors_has_courses",
                column: "IdMajorsCourses",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_Non-OfficerEmployees_Employees1_idx",
                table: "nonofficeremployees",
                column: "idEmployee");

            migrationBuilder.CreateIndex(
                name: "fk_Non-OfficerEmployees_Responsibilities1_idx",
                table: "nonofficeremployees",
                column: "idResponsibilities");

            migrationBuilder.CreateIndex(
                name: "idNon-OfficerEmployees_UNIQUE",
                table: "nonofficeremployees",
                column: "idNon-OfficerEmployees",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idResponsibilities_UNIQUE",
                table: "responsibilities",
                column: "idResponsibilities",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idSchoolGeneralInfo_UNIQUE",
                table: "schoolgeneralinfo",
                column: "idSchoolGeneralInfo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_SchoolManagementAttendants_Branches1_idx",
                table: "schoolmanagementattendants",
                column: "idBranches");

            migrationBuilder.CreateIndex(
                name: "fk_SchoolManagementAttendants_Employees1_idx",
                table: "schoolmanagementattendants",
                column: "idEmployee");

            migrationBuilder.CreateIndex(
                name: "idSchoolManagementAttendants_UNIQUE",
                table: "schoolmanagementattendants",
                column: "idTeacher",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_SchoolManagementAttendants_has_Responsibilities_Responsi_idx",
                table: "schoolmanagementattendantsresponsibilities",
                column: "idResponsibilities");

            migrationBuilder.CreateIndex(
                name: "fk_SchoolManagementAttendants_has_Responsibilities_SchoolMa_idx",
                table: "schoolmanagementattendantsresponsibilities",
                column: "idTeacher");

            migrationBuilder.CreateIndex(
                name: "idSemesters_UNIQUE",
                table: "semesters",
                column: "idSemesters",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_StudentGroupsByClassAndMajor_Semesters1_idx",
                table: "studentgroupsbyclassandmajor",
                column: "idSemesters");

            migrationBuilder.CreateIndex(
                name: "GroupCode_UNIQUE",
                table: "studentgroupsbyclassandmajor",
                column: "GroupCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IdMajorClassGroups_UNIQUE",
                table: "studentgroupsbyclassandmajor",
                column: "IdMajorClassGroups",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_Majors_has_Students_has_Classes_Classes1_idx",
                table: "studentmajorclasses",
                column: "IdClasses");

            migrationBuilder.CreateIndex(
                name: "fk_StudentMajorClasses_Majors1_idx",
                table: "studentmajorclasses",
                column: "IdMajors");

            migrationBuilder.CreateIndex(
                name: "fk_StudentMajorClasses_Students1_idx",
                table: "studentmajorclasses",
                column: "IdstudentNumber");

            migrationBuilder.CreateIndex(
                name: "IdStudentMajorClasses_UNIQUE",
                table: "studentmajorclasses",
                column: "IdStudentMajorClasses",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IdstudentNumber_UNIQUE",
                table: "students",
                column: "IdstudentNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "StudentTC_UNIQUE",
                table: "students",
                column: "StudentTC",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idStudentsDayoff_UNIQUE1",
                table: "studentsdayoff",
                column: "idStudentsDayoff",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_StudentsDayoff_has_Students_Students1_idx",
                table: "studentsdayoff_has_students",
                column: "IdstudentNumber");

            migrationBuilder.CreateIndex(
                name: "fk_StudentsDayoff_has_Students_StudentsDayoff1_idx",
                table: "studentsdayoff_has_students",
                column: "idStudentsDayoff");

            migrationBuilder.CreateIndex(
                name: "fk_Teachers_Branches1_idx",
                table: "teachers",
                column: "idBranches");

            migrationBuilder.CreateIndex(
                name: "fk_Teachers_Employees1_idx",
                table: "teachers",
                column: "idEmployee");

            migrationBuilder.CreateIndex(
                name: "fk_Teachers_Responsibilities1_idx",
                table: "teachers",
                column: "idResponsibilities");

            migrationBuilder.CreateIndex(
                name: "idTeachers_UNIQUE1",
                table: "teachers",
                column: "idTeachers",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_Teachers_has_Courses_Courses1_idx",
                table: "teachers_has_courses",
                column: "idCourse");

            migrationBuilder.CreateIndex(
                name: "fk_Teachers_has_Courses_Teachers1_idx",
                table: "teachers_has_courses",
                column: "idTeachers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "classroomsandcourses");

            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.DropTable(
                name: "coursehoursbymajorclasses");

            migrationBuilder.DropTable(
                name: "courseschedules");

            migrationBuilder.DropTable(
                name: "daylimitsfordayoffs");

            migrationBuilder.DropTable(
                name: "employeesdayoffinfos");

            migrationBuilder.DropTable(
                name: "endofsemesterexamscores");

            migrationBuilder.DropTable(
                name: "endofsemesteropinionscores");

            migrationBuilder.DropTable(
                name: "examsschedules");

            migrationBuilder.DropTable(
                name: "generalofficers");

            migrationBuilder.DropTable(
                name: "nonofficeremployees");

            migrationBuilder.DropTable(
                name: "schoolmanagementattendantsresponsibilities");

            migrationBuilder.DropTable(
                name: "studentsdayoff_has_students");

            migrationBuilder.DropTable(
                name: "StudentsDayoff_has_Students");

            migrationBuilder.DropTable(
                name: "teachers_has_courses");

            migrationBuilder.DropTable(
                name: "majors_has_courses");

            migrationBuilder.DropTable(
                name: "employeesdayoff");

            migrationBuilder.DropTable(
                name: "endofsemesterreport");

            migrationBuilder.DropTable(
                name: "classroomsgroup");

            migrationBuilder.DropTable(
                name: "groupbystudentsmajorandclasses");

            migrationBuilder.DropTable(
                name: "studentsdayoff");

            migrationBuilder.DropTable(
                name: "teachers");

            migrationBuilder.DropTable(
                name: "schoolgeneralinfo");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "classrooms");

            migrationBuilder.DropTable(
                name: "studentmajorclasses");

            migrationBuilder.DropTable(
                name: "studentgroupsbyclassandmajor");

            migrationBuilder.DropTable(
                name: "responsibilities");

            migrationBuilder.DropTable(
                name: "schoolmanagementattendants");

            migrationBuilder.DropTable(
                name: "classes");

            migrationBuilder.DropTable(
                name: "majors");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "semesters");

            migrationBuilder.DropTable(
                name: "branches");

            migrationBuilder.DropTable(
                name: "employees");
        }
    }
}
