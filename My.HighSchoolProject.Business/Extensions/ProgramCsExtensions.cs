using AutoMapper;
using DTO.My.HighSchoolProject.WebAPI.Dto.BranchDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassroomAndCourseDto;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassroomDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassroomsGroupDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.ContactDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.CourseDto;
using DTO.My.HighSchoolProject.WebAPI.Dto.CourseHoursByMajorClassDto;
using DTO.My.HighSchoolProject.WebAPI.Dto.DayLimitsForDayOffDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.EmployeeDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.GeneralOfficerDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.GroupByStudentsMajorAndClass;
using DTO.My.HighSchoolProject.WebAPI.Dto.GroupCodeDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.MajorDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.NonOfficerEmployeeDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.ResponsibilityDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.SemesterDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.StudentClassMajorsDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.StudentDayOffDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.StudentDayOffHasStudentsDto;
using DTO.My.HighSchoolProject.WebAPI.Dto.StudentDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.TeacherDtos;
using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using DTO.My.HighSchoolProject.WebAPI.GetDtos;
using DTO.My.HighSchoolProject.WebAPI.GetDtos.GroupByStudentsSmC;
using DTO.My.HighSchoolProject.WebAPI.GetDtos.StudentJoinDtos;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using My.HighSchoolProject.Business.Mapping;
using My.HighSchoolProject.Business.ServiceInterfaces;
using My.HighSchoolProject.Business.ServiceInterfaces.JoinInterFaces;
using My.HighSchoolProject.Business.Services;
using My.HighSchoolProject.Business.Services.BranchService;
using My.HighSchoolProject.Business.Services.ClassroomService;
using My.HighSchoolProject.Business.Services.ClassService;
using My.HighSchoolProject.Business.Services.ContactService;
using My.HighSchoolProject.Business.Services.CourseHoursByMajorClassService;
using My.HighSchoolProject.Business.Services.CourseSchedulesService;
using My.HighSchoolProject.Business.Services.CourseService;
using My.HighSchoolProject.Business.Services.DayLimitsForDayOffService;
using My.HighSchoolProject.Business.Services.EmployeeService;
using My.HighSchoolProject.Business.Services.GeneralOfficerService;
using My.HighSchoolProject.Business.Services.GetGroupByStudentMcDto;
using My.HighSchoolProject.Business.Services.GetJoinsServices;
using My.HighSchoolProject.Business.Services.GroupByStundentsMajorAndClassesService;
using My.HighSchoolProject.Business.Services.GroupCodeService;
using My.HighSchoolProject.Business.Services.MajorService;
using My.HighSchoolProject.Business.Services.MajorsHasCourseDto;
using My.HighSchoolProject.Business.Services.NonOfficerEmployeeService;
using My.HighSchoolProject.Business.Services.ResponsibilityService;
using My.HighSchoolProject.Business.Services.SemesterService;
using My.HighSchoolProject.Business.Services.StudentDayOffService;
using My.HighSchoolProject.Business.Services.StudentService;
using My.HighSchoolProject.Business.Services.TeacherService;
using My.HighSchoolProject.Business.ValidationRules.BranchValidation;
using My.HighSchoolProject.Business.ValidationRules.ClassroomAndCourseValidations;
using My.HighSchoolProject.Business.ValidationRules.ClassroomsGroupValidation;
using My.HighSchoolProject.Business.ValidationRules.ClassroomValidations;
using My.HighSchoolProject.Business.ValidationRules.ClassValidations;
using My.HighSchoolProject.Business.ValidationRules.ContactValidations;
using My.HighSchoolProject.Business.ValidationRules.CourseValidations;
using My.HighSchoolProject.Business.ValidationRules.CoursHoursByMajorClass;
using My.HighSchoolProject.Business.ValidationRules.CoursHoursByMajorClassValidation;
using My.HighSchoolProject.Business.ValidationRules.DayLimitsForDayOffsDtoValidation;
using My.HighSchoolProject.Business.ValidationRules.EmployeeValidations;
using My.HighSchoolProject.Business.ValidationRules.GeneralOfficerValidations;
using My.HighSchoolProject.Business.ValidationRules.GroupByStudentsMajorAndClassesValidation;
using My.HighSchoolProject.Business.ValidationRules.GroupCodeValidation;
using My.HighSchoolProject.Business.ValidationRules.MajorValidations;
using My.HighSchoolProject.Business.ValidationRules.NonOfficerEmployeeValidations;
using My.HighSchoolProject.Business.ValidationRules.ResponsiblityValidations;
using My.HighSchoolProject.Business.ValidationRules.SemesterValidations;
using My.HighSchoolProject.Business.ValidationRules.StudentDayOffValidation;
using My.HighSchoolProject.Business.ValidationRules.StudentMajorclassesValidations;
using My.HighSchoolProject.Business.ValidationRules.StudentValidations;
using My.HighSchoolProject.Business.ValidationRules.TeacherValidations;
using My.HighSchoolProject.DataAccess.Models;
using My.HighSchoolProject.DataAccess.UnitOfWork;
namespace My.HighSchoolProject.Business.Extensions
{
    public static class ProgramCsExtensions
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<HighSchoolDatabaseContext>(options =>
            {
                options.UseMySQL("server=localhost;database=HighSchoolDatabase;user=root;password=shazee;");
                options.LogTo(Console.WriteLine, LogLevel.Information);
            });

            var configuration = new MapperConfiguration(options =>
            {
                options.AddProfile(new MappingProfile());
            });
            var mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);

           
            services.AddScoped<IUow, Uow>();

            #region Student
            services.AddTransient<IValidator<StudentCreateDto>, StudentCreateDtoValidator>();
            services.AddTransient<IValidator<StudentUpdateDto>, StudentUpdateDtoValidator>();

            services.AddScoped<IStudentService, StudentService>();
            #endregion

            #region Contact
            services.AddTransient<IValidator<ContactCreateDtos>, ContactCreateDtoValidator>();
            services.AddTransient<IValidator<ContactUpdateDtos>, ContactUpdateDtoValidator>();

            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<tryContact, tryContactt>();
            #endregion

            #region Major
            services.AddTransient<IValidator<MajorCreateDto>, MajorCreateDtoValidator>();
            services.AddTransient<IValidator<MajorUpdateDto>, MajorUpdateDtoValidator>();

            services.AddScoped<IMajorService, MajorService>();
            #endregion

            #region Class
            services.AddTransient<IValidator<ClassCreateDto>, ClassCreateDtoValidation>();
            services.AddTransient<IValidator<ClassUpdateDto>, ClassUpdateValidationDto>();

            services.AddScoped<IClassService, ClassService>();
            #endregion

            #region Semester
            services.AddTransient<IValidator<SemesterCreateDto>, SemesterCreateDtoValidation>();
            services.AddTransient<IValidator<SemesterUpdateDto>, SemesterUpdateDtoValidator>();

            services.AddScoped<ISemesterService, SemesterService>();
            #endregion

            #region StudentMajorClasses
            services.AddTransient<IValidator<CreateStudentMajorClassesDto>, StudentMajorClassesCreateValidator>();
            services.AddTransient<IValidator<UpdateStudonMajorClassesDto>, StudentMajorClassesUpdateValidator>();

            services.AddScoped<IDtoStudentMajorClasses, CreateStudentMajorClassesDto>();
            #endregion

            #region GroupByStudentsMajorAndClass
            services.AddTransient<IValidator<CreateGroupByStudentsMajorAndClass>, CreateGroupByStudentsMajorsAndClassesValidator>();
            services.AddTransient<IValidator<UpdateGroupByStudentsMajorAndClass>, UpdateGroupByStudentsMajorsAndClassesValidator>();

            services.AddScoped<IGroupByStundentsMajorAndClasses, GroupByStudentsMajorandClassesService>();
            services.AddScoped<IdoListGroupByStudentsMajorAndClass, IListGroupByStudentsMajorAndClass>();
            #endregion

            #region GroupCode 
            services.AddTransient<IValidator<CreateGroupCodeDto>, CreateGroupCodeValidation>();
            services.AddTransient<IValidator<UpdateGroupCodeDto>, UpdateGrupCodeValidator>();

            services.AddScoped<IGroupCodeService, GroupCodeService>();

            #endregion

            #region GetJoins
            services.AddScoped<ISampleGetJoinDtos, SampleGetJoinDto>();
            #endregion
            services.AddScoped<IStudentMajorClassesService, GetJoinsGroupAndMajorCalssesInfo>();

            services.AddScoped<IGeneralGetJoinsServiceDto, StudentGetJoinsServices>();
            #region DayLimitsforDayOffs
            services.AddTransient<IValidator<CreateDayLimitsForDayOffDto>, CreateDayLimitsForDayOffsDtoValidator>();
            services.AddTransient<IValidator<UpdateDayLimitsForDayOffDtos>, UpdateDayLimitsForDayOffsDtoValidator>();

            services.AddScoped<IDayLimitsForDayOffService, DayLimitsForDayOffService>();
            #endregion

            #region StudentDayOffs
            services.AddTransient<IValidator<CreateStudentDayOffDto>, CreateStudentDayOffValidator>();
            services.AddTransient<IValidator<UpdateStudentDayOfDto>, UpdateStudentDayOffValidator>();

            services.AddScoped<IStudentDayOffService, StudentDayOffService>();
            services.AddScoped<IDtoStudentDayOffHasStudent, StudentDayOffHasStudentsDto>();
            #endregion

            #region Classroom
            services.AddTransient<IValidator<CreateClassroomDto>, CreateClassroomValidator>();
            services.AddTransient<IValidator<UpdateClassroomDto>, UpdateClassroomValidator>();

            services.AddScoped<IClassroomService, ClassroomService>();
            #endregion

            #region Branch
            services.AddTransient<IValidator<CreateBranchDtos>, CreateBranchValidation>();
            services.AddTransient<IValidator<UpdateBranchDtos>, UpdateBranchValidation>();  

            services.AddScoped<IBranchService, BranchService>();
            #endregion

            #region Course
            services.AddTransient<IValidator<CreateCourseDto>, CreateCourseValidator>();
            services.AddTransient<IValidator<UpdateCourseDto>, UpdateCourseValidator>();

            services.AddScoped<ICourseService, CourseService>();
            #endregion

            #region MajorsHasCourse
            services.AddScoped<IMajorsHasCourseService, MajorsHasCourseService>();
            #endregion

            #region ClassroomsGroup
            services.AddTransient<IValidator<CreateClassroomsGroupDto>, CreateClassroomsGroupValidatior>();
            services.AddTransient<IValidator<UpdateClassroomsGroupDto>, UpdateClassroomsGroupValidator>();

            services.AddScoped<IClassroomsGroupService, ClassroomsGroupService>();
            #endregion

            #region ClassroomAndCourse
            services.AddTransient<IValidator<CreateClassroomAndCourseDto>, CreateClassroomAndCourseValidatior>();
            services.AddTransient<IValidator<UpdateClassroomAndCourseDto>, UpdateClassroomAndCourseValidator>();

            services.AddScoped<IClassroomAndGroupService, ClassroomAndCourseService>();
            #endregion

            #region CourseHoursByMajorClass
            services.AddTransient<IValidator<CreateCourseHoursByMajorClassDto>, CreateCourseHoursByMajorClassValidator>();
            services.AddTransient<IValidator<UpdateCourseHoursByMajorClassDto>, UpdateCourseHoursByMajorClassValidator>();

            services.AddScoped<ICourseHoursByMajorClassService, CourseHoursByMajorClassService>();
            #endregion

            #region Employee
            services.AddTransient<IValidator<CreateEmployeeDto>, CreateEmployeeValidator>();
            services.AddTransient<IValidator<UpdateEmployeeDto>, UpdateEmployeeValidator>();

            services.AddScoped<IEmployeeService, EmployeeService>();
            #endregion

            #region Responsibility
            services.AddTransient<IValidator<CreateResponsibilityDto>, CreateResponsibilityValidator>();
            services.AddTransient<IValidator<UpdateResponsibilityDto>, UpdateResponsiblityValidator>();

            services.AddScoped<IResponsibilityService, ResponsibilityService>();
            #endregion

            #region
            services.AddTransient<IValidator<CreateGeneralOfficerDto>, CreateGeneralOfficerValidator>();
            services.AddTransient<IValidator<UpdateGeneralOfficerDto>, UpdateGeneralOfficerValidator>();

            services.AddScoped<IGeneralOfficerService, GeneralOfficerService>();
            #endregion

            #region NonOfficerEmployee
            services.AddTransient<IValidator<CreateNonOfficerEmployee>, CreateNonOfficerEmployeeValidator>();
            services.AddTransient<IValidator<UpdateNonOfficerEmployeeDto>, UpdateNonOfficerEmployeeValidator>();

            services.AddScoped<INonOfficerEmployeeService, NonOfficerEmployeeService>();
            #endregion

            #region Teacher
            services.AddTransient<IValidator<CreateTeacherDto>, CreateTeacherValidator>();
            services.AddTransient<IValidator<UpdateTeacherDto>, UpdateTeacherValidator>();

            services.AddScoped<ITeacherService, TeacherService>();
            #endregion

            services.AddScoped<IDtoCourseSchedules, CourseSchedulesService>();
        }

    }
}