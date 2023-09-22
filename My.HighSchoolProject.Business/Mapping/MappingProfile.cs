using AutoMapper;
using DTO.My.HighSchoolProject.WebAPI.Dto.BranchDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassroomDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassroomsGroupDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.ContactDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.CourseDto;
using DTO.My.HighSchoolProject.WebAPI.Dto.CourseHoursByMajorClassDto;
using DTO.My.HighSchoolProject.WebAPI.Dto.CourseShcedulesDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.DayLimitsForDayOffDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.EmployeeDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.GeneralOfficerDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.GroupByStudentsMajorAndClass;
using DTO.My.HighSchoolProject.WebAPI.Dto.GroupCodeDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.MajorDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.MajorHasCourseDto;
using DTO.My.HighSchoolProject.WebAPI.Dto.NonOfficerEmployeeDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.ResponsibilityDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.SemesterDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.StudentClassMajorsDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.StudentDayOffDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.StudentDayOffHasStudentsDto;
using DTO.My.HighSchoolProject.WebAPI.Dto.StudentDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.TeacherDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.TeacherHasCoursesDtos;
using My.HighSchoolProject.DataAccess.BaseEntities;
using My.HighSchoolProject.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Student Maps
            CreateMap<Student, StudentCreateDto>().ReverseMap();
            CreateMap<Student, StudentUpdateDto>().ReverseMap();
            CreateMap<StudentListDtos, StudentUpdateDto>().ReverseMap();
            CreateMap<Student, StudentListDtos>().ReverseMap();
            #endregion

            #region Contact Maps
            CreateMap<Contact, ContactCreateDtos>().ReverseMap();
            CreateMap<Contact, ContactUpdateDtos>().ReverseMap();
            CreateMap<ContactListDtos, ContactUpdateDtos>().ReverseMap();
            CreateMap<Contact, ContactListDtos>().ReverseMap();
            #endregion

            #region Major Maps
            CreateMap<Major, MajorCreateDto>().ReverseMap();
            CreateMap<Major, MajorUpdateDto>().ReverseMap();
            CreateMap<MajorListDto, MajorUpdateDto>().ReverseMap();
            CreateMap<Major, MajorListDto>().ReverseMap();
            #endregion

            #region Class Maps
            CreateMap<Class, ClassCreateDto>().ReverseMap();
            CreateMap<Class, ClassUpdateDto>().ReverseMap();
            CreateMap<ClassListDto, ClassUpdateDto>().ReverseMap();
            CreateMap<Class, ClassListDto>().ReverseMap();
            #endregion

            #region Semester Maps
            CreateMap<Semester, SemesterCreateDto>().ReverseMap();
            CreateMap<Semester, SemesterUpdateDto>().ReverseMap();
            CreateMap<Semester, SemesterListDto>().ReverseMap();
            CreateMap<SemesterListDto, SemesterUpdateDto>().ReverseMap();
            #endregion

            #region StudentClassMajor Maps
            CreateMap<Studentmajorclass, CreateStudentMajorClassesDto>().ReverseMap();
            CreateMap<Studentmajorclass, UpdateStudonMajorClassesDto>().ReverseMap();
            CreateMap<Studentmajorclass, ListStudentMajorClassesDto>().ReverseMap();
            CreateMap<ListStudentMajorClassesDto, UpdateStudonMajorClassesDto>().ReverseMap();
            #endregion

            #region GroupByStudentsMajorAndClasses Maps
            CreateMap<Groupbystudentsmajorandclass, CreateGroupByStudentsMajorAndClass>().ReverseMap();
            CreateMap<Groupbystudentsmajorandclass, UpdateGroupByStudentsMajorAndClass>().ReverseMap();
            CreateMap<Groupbystudentsmajorandclass, IListGroupByStudentsMajorAndClass>().ReverseMap();
            CreateMap<IListGroupByStudentsMajorAndClass, UpdateGroupByStudentsMajorAndClass>().ReverseMap();
            #endregion

            #region GroupCode Maps
            CreateMap<Studentgroupsbyclassandmajor, CreateGroupCodeDto>().ReverseMap();
            CreateMap<Studentgroupsbyclassandmajor, UpdateGroupCodeDto>().ReverseMap();
            CreateMap<Studentgroupsbyclassandmajor, ListGroupCodeDto>().ReverseMap();
            CreateMap<ListGroupCodeDto, UpdateGroupCodeDto>().ReverseMap();
            #endregion

            #region DayLimitsforDayOffs
            CreateMap<Daylimitsfordayoff, CreateDayLimitsForDayOffDto>().ReverseMap();  
            CreateMap<Daylimitsfordayoff, UpdateDayLimitsForDayOffDtos>().ReverseMap();
            CreateMap<Daylimitsfordayoff, ListDayLimitsForDayOffDtos>().ReverseMap();
            CreateMap<ListDayLimitsForDayOffDtos, UpdateDayLimitsForDayOffDtos>().ReverseMap();
            #endregion

            #region StudentDayOffs
            CreateMap<Studentsdayoff, CreateStudentDayOffDto>().ReverseMap();
            CreateMap<Studentsdayoff, UpdateStudentDayOfDto>().ReverseMap();
            CreateMap<Studentsdayoff, ListStudentDayOffDto>().ReverseMap();
            CreateMap<ListStudentDayOffDto, UpdateStudentDayOfDto>().ReverseMap();
            #endregion

            #region Classroom
            CreateMap<Classroom, CreateClassroomDto>().ReverseMap();   
            CreateMap<Classroom, UpdateClassroomDto>().ReverseMap();
            CreateMap<Classroom, ListClassroomDto>().ReverseMap();
            CreateMap<UpdateClassroomDto, ListClassroomDto>().ReverseMap();
            #endregion

            #region Branch
            CreateMap<Branch, CreateBranchDtos>().ReverseMap();
            CreateMap<Branch, UpdateBranchDtos>().ReverseMap();
            CreateMap<Branch, ListBranchDtos>().ReverseMap();
            CreateMap<ListBranchDtos, UpdateBranchDtos>().ReverseMap();
            #endregion

            #region Course
            CreateMap<Course, CreateCourseDto>().ReverseMap();
            CreateMap<Course, UpdateCourseDto>().ReverseMap();
            CreateMap<Course, ListCourseDto>().ReverseMap();
            CreateMap<ListCourseDto, UpdateCourseDto>().ReverseMap();
            #endregion

            #region MajorHasCourse
            CreateMap<MajorsHasCourse, CreateMajorHasCourseDto>().ReverseMap();
            CreateMap<MajorsHasCourse, UpdateMajorHasCouseDto>().ReverseMap();
            CreateMap<MajorsHasCourse, ListMajorHasCourseDto>().ReverseMap();
            CreateMap<ListMajorHasCourseDto, UpdateMajorHasCouseDto>().ReverseMap();
            #endregion

            #region ClassroomsGroup
            CreateMap<Classroomsgroup, CreateClassroomsGroupDto>().ReverseMap();
            CreateMap<Classroomsgroup, UpdateClassroomsGroupDto>().ReverseMap();
            CreateMap<Classroomsgroup,  ListClassroomsGroupDto>().ReverseMap();
            CreateMap<ListClassroomsGroupDto, UpdateClassroomsGroupDto>().ReverseMap();
            #endregion

            #region CourseHoursByMajorclass
            CreateMap<Coursehoursbymajorclass, CreateCourseHoursByMajorClassDto>().ReverseMap();
            CreateMap<Coursehoursbymajorclass, UpdateCourseHoursByMajorClassDto>().ReverseMap();
            CreateMap<Coursehoursbymajorclass, ListCourseHoursByMajorClassDto>().ReverseMap();
            CreateMap<ListCourseHoursByMajorClassDto, UpdateCourseHoursByMajorClassDto>().ReverseMap();
            #endregion

            #region
            CreateMap<Employee, CreateEmployeeDto>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeDto>().ReverseMap();
            CreateMap<Employee, ListEmployeeDto>().ReverseMap();
            CreateMap<ListEmployeeDto, UpdateEmployeeDto>().ReverseMap();
            #endregion

            #region Responsibility
            CreateMap<Responsibility, CreateResponsibilityDto>().ReverseMap();
            CreateMap<Responsibility, UpdateResponsibilityDto>().ReverseMap();
            CreateMap<Responsibility, ListResponsibilityDto>().ReverseMap();
            CreateMap<ListResponsibilityDto, UpdateResponsibilityDto>().ReverseMap();
            #endregion

            #region GeneralOfficer
            CreateMap<Generalofficer, CreateGeneralOfficerDto>().ReverseMap();
            CreateMap<Generalofficer, UpdateGeneralOfficerDto>().ReverseMap();
            CreateMap<Generalofficer, ListGeneralOfficerDto>().ReverseMap();
            CreateMap<ListGeneralOfficerDto, UpdateGeneralOfficerDto>().ReverseMap();
            #endregion

            #region NonOfficerEmployee
            CreateMap<Nonofficeremployee, CreateNonOfficerEmployee>().ReverseMap();
            CreateMap<Nonofficeremployee, UpdateNonOfficerEmployeeDto>().ReverseMap();
            CreateMap<Nonofficeremployee, ListNonOfficerEmployeeDto>().ReverseMap();
            CreateMap<ListNonOfficerEmployeeDto, UpdateNonOfficerEmployeeDto>().ReverseMap();
            #endregion

            #region Teacher
            CreateMap<Teacher, CreateTeacherDto>().ReverseMap();
            CreateMap<Teacher,  UpdateTeacherDto>().ReverseMap();
            CreateMap<Teacher, ListTeacherDto>().ReverseMap();
            CreateMap<ListTeacherDto, UpdateTeacherDto>().ReverseMap();
            #endregion

            #region TeacherHasCourses
            CreateMap<ListTeacherHasCoursesDto, UpdateTeacherHasCoursesDto>().ReverseMap();
            CreateMap<ListTeacherHasCoursesDto, Teacher>().ReverseMap();
            CreateMap<ListTeacherHasCoursesDto, Course>().ReverseMap();
            #endregion

            #region CourseSchedule
            CreateMap<Courseschedule, CreateCourseSchedulesDto>().ReverseMap();
            CreateMap<Courseschedule, UpdateCourseSchedulesDto>().ReverseMap();
            CreateMap<Courseschedule, ListCourseSchedulesDto>().ReverseMap();
            CreateMap<ListCourseSchedulesDto, UpdateCourseSchedulesDto>().ReverseMap();
            #endregion
        }
    }
}
