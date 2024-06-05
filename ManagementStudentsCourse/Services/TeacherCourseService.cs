using AutoMapper;
using Curso.Models;
using Curso.Models.Dtos;
using Curso.Repository.Interfaces;
using Curso.Services.Interfaces;

namespace Curso.Services
{
    public class TeacherCourseService : ITeacherCourseService
    {
        private readonly ITeacherCourseRepository _repository;
        private readonly IMapper _mapper;
        public TeacherCourseService(ITeacherCourseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public List<ManagementTeacherCourseDto> GetTeacherCourses()
        {
            var list = _repository.GetTeacherCourses();
            return list.GroupBy(x => x.TeacherId)
                            .Select(g => new ManagementTeacherCourseDto
                            {
                                TeacherId = g.Key,
                                Id = g.First().Id, 
                                TeacherName = g.FirstOrDefault().Teacher.Name, 
                                Teacher = g.FirstOrDefault().Teacher,
                                Course = g.FirstOrDefault().Course,
                                Courses = g.Select(x => x.Course).ToList(),
                                CoursesId = g.Select(tc => tc.CourseId).ToList() 
                            }).ToList();
        }

        public ManagementTeacherCourseDto GetTeacherCourse(int teacherId)
        {
            var list = _repository.GetTeacherCourse(teacherId);

            var listT = list.GroupBy(x => x.TeacherId)
                            .Select(g => new ManagementTeacherCourseDto
                            {
                                TeacherId = g.Key,
                                Id = g.FirstOrDefault().Id, 
                                TeacherName = g.FirstOrDefault().Teacher.Name, 
                                CoursesId = g.Select(tc => tc.CourseId).ToList() ,
                                Courses = g.Select(c => c.Course).ToList(),
                                Teacher = g.FirstOrDefault().Teacher,
                            }).ToList();
            return listT.FirstOrDefault();
        }
        public void CreateTeacher(TeacherDto teacherDto)
        {
            var existTeacher = _repository.GetTeachers();
            if(existTeacher.Any(x=> x.Email.ToString().Trim().ToLower() == teacherDto.Email.Trim().ToLower()))
            {
                throw new Exception("Already exist teacher in our records with this email. Please, change email.");
            }

            if (existTeacher.Any(x => x.CPF.ToString().Trim().ToLower() == teacherDto.CPF.Trim().ToLower()))
            {
                throw new Exception("Already exist teacher in our records with this cpf. Please, change cpf.");
            }

            var teacher = _mapper.Map<Teacher>(teacherDto);
            _repository.CreateTeacher(teacher);
        }

        public void UpdateTeacher(int id, TeacherDto teacherdto)
        {
            var teacher = _mapper.Map<Teacher>(teacherdto);
            _repository.UpdateTeacher(id, teacher);
        }

        public void CreateTeacherCourse(TeacherCourseDto teacherCourse)
        {
            throw new NotImplementedException();
        }

        public string DeleteTeacher(int id)
        {
            var teacher = _repository.GetTeacher(id);
            if (teacher == null)
            {
                return "Teacher dont exist";
            }

            _repository.DeleteTeacher(id);
            return "";
        }

        public void ManagementTeacherCourse(ManagementTeacherCourseDto teacherCourseDto)
        {
            var teacherCourse = _mapper.Map<TeacherCourse>(teacherCourseDto);
            var list = new List<TeacherCourse>();
            if(teacherCourseDto.CoursesId != null)
            {
                foreach (var courseId in teacherCourseDto.CoursesId)
                {
                    teacherCourse.CourseId = courseId;
                    list.Add(new TeacherCourse { TeacherId = teacherCourse.TeacherId, CourseId = courseId, Id = teacherCourseDto.Id });
                }
            }
            else
            {
                list.Add(new TeacherCourse { TeacherId = teacherCourse.TeacherId, CourseId = 0, Id = teacherCourseDto.Id });
                _repository.DeleteManagementTeacherCourse(list);
                return;
            }
            
            if(list.Count > 0)
            {
                _repository.DeleteManagementTeacherCourse(list);
                foreach (var item in list)
                {
                    item.Id = 0;
                }
                
                _repository.ManagementTeacherCourse(list);
            }
            
        }

        public List<TeacherDto> GetTeachers()
        {
            return _mapper.Map<List<TeacherDto>>( _repository.GetTeachers());
        }
        public TeacherDto GetTeacher(int id)
        {
            return _mapper.Map<TeacherDto>(_repository.GetTeacher(id));
        }

    }
}
