using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;
using DTO.My.HighSchoolProject.WebAPI.GetDtos;
using DTO.My.HighSchoolProject.WebAPI.GetDtos.StudentJoinDtos;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using My.HighSchoolProject.Business.ServiceInterfaces.JoinInterFaces;
using My.HighSchoolProject.DataAccess.Models;
using My.HighSchoolProject.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace My.HighSchoolProject.Business.Services.GetJoinsServices
{
    public class StudentGetJoinsServices : IGeneralGetJoinsServiceDto
    {
        private readonly HighSchoolDatabaseContext _context;
        private readonly tryContact _contact2;
        private readonly IUow _uow;

        public StudentGetJoinsServices(HighSchoolDatabaseContext context, tryContact contact2, IUow uow)
        {
            _context = context;
            _contact2 = contact2;
            _uow = uow;
        }

        public IQueryable<StudentJoins> GetJoins()
        {

            var fullGroupJoin = from _fullGroupInfo in _context.Groupbystudentsmajorandclasses

                                 join _groupCode in _context.Studentgroupsbyclassandmajors
                                 on _fullGroupInfo.IdMajorClassGroups equals _groupCode.IdMajorClassGroups

                                 join _majorClasses in _context.Studentmajorclasses
                                 on _fullGroupInfo.IdStudentMajorClasses equals _majorClasses.IdStudentMajorClasses

                                 join fullStudent in _context.Students
                                 on _majorClasses.IdstudentNumber equals fullStudent.IdstudentNumber

                                 join Contact in _context.Contacts on fullStudent.IdstudentNumber equals Contact.IdstudentNumber into contactGroup
                                 from Contact in contactGroup.DefaultIfEmpty()

                                 join _major in _context.Majors
                                 on _majorClasses.IdMajors equals _major.IdMajors

                                 join _class in _context.Classes
                                 on _majorClasses.IdClasses equals _class.IdClasses

                                 

                                 select new StudentJoins
                                 {
                                     studentTC = fullStudent.StudentTc,
                                     studentNumber = fullStudent.IdstudentNumber,
                                     studentFullname = $"{fullStudent.Name} {fullStudent.Surname}",
                                     studentFailCount = fullStudent.FailCount,
                                     studentEducationRight = fullStudent.RightToEducation,
                                     studentMajor = _major.MajorsName,
                                     studentClass = _class.ClassNumber,
                                     studentGroup = _groupCode.GroupCode,
                                     StudentContactInfo = new StudentContactInfo
                                     {
                                         StudentContact = Contact.StudentsPhone,
                                         StudentEmail = Contact.StudentsEmail,
                                         StudentAddress = $"City: {Contact.City} / Region: {Contact.Region} / Address: {Contact.StudentsAddress}",
                                         StudentParent = $"{Contact.ParentName} {Contact.ParentSurname}",
                                         ParentContact = Contact.StudentParentPhone,
                                         ParentEmail = Contact.StudentsParentEmail,
                                     },
                                     
                                 }; 
            
               

            return fullGroupJoin.AsQueryable();
        }

        public List<StudentGetDayOffJoin> GetDayOffs()
        {
            var dayOff = from fullStudent in _context.Students
                             // Diğer join işlemleri

                         join _dayOffs in _context.Studentsdayoffs on fullStudent.IdstudentNumber equals _dayOffs.IdstudentNumber into dayOffGroup
                         where dayOffGroup.Any(d => d.DoctorReport == 0 || d.DoctorReport > 0) 
                         select new StudentGetDayOffJoin
                         {
                             studentNumber = fullStudent.IdstudentNumber,
                             studentFullname = $"{fullStudent.Name} {fullStudent.Surname}",
                             DayOffs = dayOffGroup.Take(10).Select(d => new DayOffInfo
                             {
                                 DayOffDate = d.Date,
                                 DayOffReport = d.DoctorReport,
                                 DayOffReason = d.Reason
                             }).ToList(),
                             TotalDayOffsWithoutReport = dayOffGroup.Count(d => d.DoctorReport == 0),
                             TotalDayOffsWithReport = dayOffGroup.Count(d => d.DoctorReport > 0)
                         };

            var results = dayOff.ToList();
            return results;
        }
    }
}
