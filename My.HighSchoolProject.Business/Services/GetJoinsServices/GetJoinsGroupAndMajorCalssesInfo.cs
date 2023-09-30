using AutoMapper;
using DTO.My.HighSchoolProject.WebAPI.Dto.GroupByStudentsMajorAndClass;
using DTO.My.HighSchoolProject.WebAPI.Dto.StudentDtos;
using DTO.My.HighSchoolProject.WebAPI.GetDtos;
using DTO.My.HighSchoolProject.WebAPI.GetDtos.GroupByStudentsSmC;
using My.HighSchoolProject.Business.ServiceInterfaces.JoinInterFaces;
using My.HighSchoolProject.DataAccess.BaseEntities;
using My.HighSchoolProject.DataAccess.Models2;
using My.HighSchoolProject.DataAccess.UnitOfWork;
using Org.BouncyCastle.Asn1.IsisMtt.X509;

namespace My.HighSchoolProject.Business.Services.GetGroupByStudentMcDto
{
    public class GetJoinsGroupAndMajorCalssesInfo : IStudentMajorClassesService
    {
        private readonly HighSchoolDatabaseContext _context;

        public GetJoinsGroupAndMajorCalssesInfo(HighSchoolDatabaseContext context)
        {
         
            _context = context;
          
        }

        public IQueryable<SampleGetJoinDto> GetJoins()
        {
            var fullGroupJoin = from fullGroup in _context.Groupbystudentsmajorandclasses

                                join MajorClass in _context.Studentmajorclasses
                                on fullGroup.IdStudentMajorClasses equals MajorClass.IdStudentMajorClasses

                                join GroupCode in _context.Studentgroupsbyclassandmajors
                                on fullGroup.IdMajorClassGroups equals GroupCode.IdMajorClassGroups

                                join semesterInfo in _context.Semesters
                                on GroupCode.IdSemesters equals semesterInfo.IdSemesters

                                join studentInfo in _context.Students
                                on MajorClass.IdstudentNumber equals studentInfo.IdstudentNumber

                                join majorInfo in _context.Majors
                                on MajorClass.IdMajors equals majorInfo.IdMajors

                                join classInfo in _context.Classes
                                on MajorClass.IdClasses equals classInfo.IdClasses
                                select new SampleGetJoinDto
                                {
                                    semester = $"{semesterInfo.Period} // {semesterInfo.Semester1}",
                                    Majority = majorInfo.MajorsName,
                                    haveClass = classInfo.ClassNumber,
                                    groupCode = GroupCode.GroupCode,
                                    groupCapacity = fullGroup.GroupCapacity,
                                    studentNumber = studentInfo.IdstudentNumber,
                                    studentFullName = $"{studentInfo.Name} {studentInfo.Surname}",                                   
                                };
            return fullGroupJoin.AsQueryable();

        }

    }
}
