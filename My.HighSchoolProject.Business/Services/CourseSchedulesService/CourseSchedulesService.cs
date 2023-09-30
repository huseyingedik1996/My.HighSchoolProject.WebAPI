using AutoMapper;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassroomDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.ClassroomsGroupDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.CourseDto;
using DTO.My.HighSchoolProject.WebAPI.Dto.CourseHoursByMajorClassDto;
using DTO.My.HighSchoolProject.WebAPI.Dto.CourseShcedulesDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.GroupByStudentsMajorAndClass;
using DTO.My.HighSchoolProject.WebAPI.Dto.MajorHasCourseDto;
using DTO.My.HighSchoolProject.WebAPI.Dto.StudentClassMajorsDtos;
using DTO.My.HighSchoolProject.WebAPI.Dto.TeacherDtos;
using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using Microsoft.AspNetCore.Localization;
using My.HighSchoolProject.Business.ServiceInterfaces;
using My.HighSchoolProject.DataAccess.Models2;
using My.HighSchoolProject.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.HighSchoolProject.Business.Services.CourseSchedulesService
{
    public class CourseSchedulesService : ICourseSchedulesService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;

        public CourseSchedulesService(IMapper mapper, IUow uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task Create()
        {
            var classRoom = _mapper.Map<List<ListClassroomsGroupDto>>(_uow.GetRepository<Classroomsgroup>().GetAll);
            var course = _mapper.Map<List<ListCourseDto>>(_uow.GetRepository<Course>().GetAll());
            var teacher = _mapper.Map<List<ListTeacherDto>>(_uow.GetRepository<Teacher>().GetAll());
            var majorCourses = _mapper.Map<List<ListMajorHasCourseDto>>(_uow.GetRepository<MajorsHasCourse>().GetAll());
            var studentMajors = _mapper.Map<List<ListStudentMajorClassesDto>>(_uow.GetRepository<Studentmajorclass>().GetAll());
            var groupStudent = _mapper.Map<List<UpdateGroupByStudentsMajorAndClass>>(_uow.GetRepository<Groupbystudentsmajorandclass>().GetAll());
            var courseHours = _mapper.Map<List<ListCourseHoursByMajorClassDto>>(_uow.GetRepository<Coursehoursbymajorclass>().GetAll());
            var schedule = _mapper.Map<List<ListCourseSchedulesDto>>(_uow.GetRepository<Courseschedule>().GetAll());
            DayOfWeek currentDay = DayOfWeek.Monday;
            int numberOfDays = 5;
            int count = 0;

            CreateCourseSchedulesDto createSchedule = new CreateCourseSchedulesDto();
                    
            
            
                var courseCountsPerDay = createSchedule.CourseCountPerDay;

                for (int dayIndex = 0; dayIndex < numberOfDays; dayIndex++)
                {
                    int dailyCourseCount = courseCountsPerDay;
                    DayOfWeek currentDayOfWeek = (DayOfWeek)((int)DayOfWeek.Monday + dayIndex);

                    
                    foreach (var courseId in course)
                    {   
                        createSchedule.DayOfWeek = currentDayOfWeek.ToString();
                        int CalculateWeeklyCourseHours(int courseId)
                        {
                            int weeklyHours = 0;

                            foreach (var hour in courseHours)
                            {
                                if (hour.IdMajorsCourses == courseId)
                                {
                                    weeklyHours += Convert.ToInt32(hour.CourseHourPerWeek);
                                }
                            }

                            return weeklyHours;
                        }
                        
                        int scheduleHours = 0;
                        int CalculateScheduleCourseHours(int idCourse)
                        {
                            
                            foreach (var hour in schedule)
                            {
                                if(courseId.IdCourse == hour.IdCourse)
                                {
                                    scheduleHours += hour.IdCourse;

                                }  
                            }
                            return scheduleHours;
                        }
                        int weeklyHours = CalculateWeeklyCourseHours(courseId.IdCourse);
                        int scheduleHour = CalculateScheduleCourseHours(courseId.IdCourse);
                        if(scheduleHour <= weeklyHours)
                        {
                            createSchedule.IdCourse = courseId.IdCourse;
                            createSchedule.StartTime += createSchedule.EndTime + createSchedule.BreakTime;
                        }

                        foreach (var classroom in classRoom)
                        {
                            
                            createSchedule.IdClassGroup = classroom.IdClassGroup;
                        }

                        foreach (var teacherId in teacher)
                        {
                            if (courseId.IdBranches == teacherId.IdBranches)
                            {
                                createSchedule.IdTeachers = teacherId.IdTeachers;
                            }
                        }

                        foreach (var majorCourseId in majorCourses)
                        {
                            foreach (var majorStudent in studentMajors)
                            {
                                foreach (var group in groupStudent)
                                {
                                    if (majorStudent.IdClasses == majorCourseId.IdClasses &&
                                        majorStudent.IdMajors == majorCourseId.IdMajors &&
                                        majorCourseId.IdClasses == majorCourseId.IdCourse &&
                                        group.IdStudentMajorClasses == majorStudent.IdStudentMajorClasses)
                                    {
                                        createSchedule.IdGroupByStudentsMajorAndClasses = group.IdGroupByStudentsMajorAndClasses;
                                    }
                                }
                            }
                        }

                        if (dailyCourseCount > 0)
                        {
                           
                            dailyCourseCount--;
                        }
                    }
                }
            
            Courseschedule courseSchedule = new Courseschedule();
            createSchedule.IdClassGroup = courseSchedule.IdClassGroup;
            createSchedule.IdCourse = courseSchedule.IdCourse;
            createSchedule.IdGroupByStudentsMajorAndClasses = createSchedule.IdGroupByStudentsMajorAndClasses;
            createSchedule.IdTeachers = courseSchedule.IdTeachers;
            createSchedule.StartTime = courseSchedule.StartTime;
            createSchedule.EndTime = courseSchedule.EndTime;
            createSchedule.DayOfWeek = courseSchedule.DayOfWeek;

            var created = _uow.GetRepository<Courseschedule>().Create(courseSchedule);
            await _uow.SaveChanges();
            
        }
    }
}
