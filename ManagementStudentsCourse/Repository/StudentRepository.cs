using Curso.Data;
using Curso.Models;
using Curso.Models.Dtos;
using Curso.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Curso.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<StudentDto> GetStudents()
        {
            return _context.Students.Include(s => s.Course).Select(x => new StudentDto
            {
                Id = x.Id,
                CPF = x.CPF,
                DateMatricula = x.DateMatricula,
                Email = x.Email,
                Name = x.Name,
                IsActive = x.IsActive,
                CourseId = x.Course.Id,
                CourseName = x.Course.Name,

            }).ToList();
        }

        public StudentDto GetStudent(int id)
        {
            return _context.Students.Include(s => s.Course).Select(x => new StudentDto
            {
                Id = x.Id,
                CPF = x.CPF,
                DateMatricula = x.DateMatricula,
                Email = x.Email,
                Name = x.Name,
                IsActive = x.IsActive,
                CourseId = x.Course.Id,
                CourseName = x.Course.Name,

            }).FirstOrDefault(s => s.Id == id);
        }

        public int CreateStudent(Student student)
        {
            student.DateMatricula = DateTime.Now;
            _context.Entry<Student>(student);
            _context.Entry(student).State = EntityState.Added;

            _context.SaveChanges();
            return student.Id;
        }

        public void DeleteStudent(int id)
        {
            var student = _context.Students.FirstOrDefault(x => x.Id == id);
            if(student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }

        public void UpdateStudent(int id, Student student)
        {
            student.Id = id;
            _context.Entry<Student>(student);
            _context.Entry(student).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void CreateStudentCourse(StudentCourse studentCourse)
        {
            _context.SaveChanges();
        }

        public void UpdateStudentCourse(int id, StudentCourse studentCourse)
        {
            _context.Entry<StudentCourse>(studentCourse);
            _context.Update(studentCourse);
            _context.SaveChanges();
        }
    }
}
