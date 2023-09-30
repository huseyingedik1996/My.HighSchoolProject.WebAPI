using AutoMapper;
using Common.My.HighSchoolProject.WebAPI.Response;
using Common.My.HighSchoolProject.WebAPI.ResponseInterface;
using DTO.My.HighSchoolProject.WebAPI.Dto.TeacherDtos;
using FluentValidation;
using My.HighSchoolProject.Business.ServiceInterfaces;
using My.HighSchoolProject.DataAccess.Models2;
using My.HighSchoolProject.DataAccess.UnitOfWork;

namespace My.HighSchoolProject.Business.Services.TeacherService
{
    public class TeacherService : ITeacherService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<CreateTeacherDto> _createValidator;
        private readonly IValidator<UpdateTeacherDto> _updateValidator;

        public TeacherService(IMapper mapper, IUow uow, IValidator<CreateTeacherDto> createValidator, IValidator<UpdateTeacherDto> updateValidator)
        {
            _mapper = mapper;
            _uow = uow;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<CreateTeacherDto>> Create(CreateTeacherDto createDto)
        {
            var validationResult = _createValidator.Validate(createDto);
            if (validationResult.IsValid)
            {
                await _uow.GetRepository<Teacher>().Create(_mapper.Map<Teacher>(createDto));
                await _uow.SaveChanges();
                return new ResponseT<CreateTeacherDto>(ResponseType.Success, createDto);
            }
            else
            {
                List<CustomValidationError> errors = new();
                foreach (var error in validationResult.Errors)
                {
                    errors.Add(new()
                    {
                        ErrorMessage = error.ErrorMessage,
                        PropertyName = error.PropertyName
                    });
                }
                return new ResponseT<CreateTeacherDto>(ResponseType.ValidationError, createDto, errors);
            }
        }

        public async Task<IResponse<List<ListTeacherDto>>> GetAll()
        {
            var data = _mapper.Map<List<ListTeacherDto>>(await _uow.GetRepository<Teacher>().GetAll());
            return new ResponseT<List<ListTeacherDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<ListTeacherDto>> GetById(int id)
        {
            var data = _mapper.Map<ListTeacherDto>(await _uow.GetRepository<Teacher>().GetByFilter(x => x.IdTeachers == id));
            return new ResponseT<ListTeacherDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntry = await _uow.GetRepository<Teacher>().GetByFilter(x => x.IdTeachers == id);
            if (removedEntry != null)
            {
                _uow.GetRepository<Teacher>().Remove(removedEntry);
                await _uow.SaveChanges();
                return new ResponseT<bool>(ResponseType.Success, removedEntry != null);
            }
            return new ResponseT<bool>(ResponseType.NotFound, $"{id} not found.");
        }

        public async Task<IResponse<List<UpdateTeacherDto>>> UpdateDtos(UpdateTeacherDto updateDto)
        {
            var validationResult = _updateValidator.Validate(updateDto);
            if (!validationResult.IsValid)
            {
                List<CustomValidationError> errors = validationResult.Errors.Select(error => new CustomValidationError
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                }).ToList();
                return new ResponseT<List<UpdateTeacherDto>>(ResponseType.NotFound, "Teacher not found.");
            }

            var updatedEntity = await _uow.GetRepository<UpdateTeacherDto>().GetById(updateDto.IdTeachers);
            if (updatedEntity != null)
            {
                _uow.GetRepository<UpdateTeacherDto>().Update(_mapper.Map<UpdateTeacherDto>(updateDto), updatedEntity);
                await _uow.SaveChanges();
                return new ResponseT<List<UpdateTeacherDto>>(ResponseType.Success, "Teacher updated successfully.");
            }
            else
            {
                return new ResponseT<List<UpdateTeacherDto>>(ResponseType.NotFound, "Teacher not found.");
            }
        }
    }
}
