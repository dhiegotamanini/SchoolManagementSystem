using AutoMapper;
using Curso.Models;
using Curso.Models.Dtos;
using Curso.Repository.Interfaces;
using Curso.Services.Interfaces;

namespace Curso.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public List<CourseDto> GetCourses()
        {
           return _mapper.Map<List<CourseDto>>(_repository.GetCourses());
        }
        public CourseDto GetCourse(int id)
        {
            return _mapper.Map<CourseDto>(_repository.GetCourse(id));
        }
        public void DeleteCourse(int id)
        {
            _repository.DeleteCourse(id);
        }
        public void CreateCourse(CourseDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            _repository.CreateCourse(course);
        }
        public void UpdateCourse(int id, CourseDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            _repository.UpdateCourse(course);
        }
    }
}