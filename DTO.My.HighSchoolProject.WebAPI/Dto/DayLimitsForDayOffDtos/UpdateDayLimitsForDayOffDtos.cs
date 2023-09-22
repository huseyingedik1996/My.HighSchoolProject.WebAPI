using DTO.My.HighSchoolProject.WebAPI.DtosInterfaces;


namespace DTO.My.HighSchoolProject.WebAPI.Dto.DayLimitsForDayOffDtos
{
    public class UpdateDayLimitsForDayOffDtos : IDtoDayLimitsForDayOffDyo
    {
        public int IdDayLimitsForDayOffs { get; set; }
        public int DayLimitForClass { get; set; }
        public int IdStudentMajorClasses { get; set; }
    }
}
