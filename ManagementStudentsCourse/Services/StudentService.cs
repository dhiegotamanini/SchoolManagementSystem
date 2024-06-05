using AutoMapper;
using Curso.Models;
using Curso.Models.Dtos;
using Curso.Repository.Interfaces;
using Curso.Services.Interfaces;

namespace Curso.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;
        public StudentService(IStudentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<StudentDto> GetStudents()
        {
            return _repository.GetStudents();
        }

        public StudentDto GetStudent(int id)
        {
            if (id == 0)
            {
                throw new Exception("Student dont exist");
            }

            return _repository.GetStudent(id);
        }

        public void CreateStudent(StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            _repository.CreateStudent(student);
        }

        public void UpdateStudent(int id, StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            _repository.UpdateStudent(id, student);
        }

        public void DeleteStudent(int id)
        {
            _repository.DeleteStudent(id);
        }
    }
}
