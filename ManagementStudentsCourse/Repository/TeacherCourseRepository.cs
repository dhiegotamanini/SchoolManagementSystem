using Curso.Data;
using Curso.Models;
using Curso.Models.Dtos;
using Curso.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Curso.Repository
{
    public class TeacherCourseRepository : ITeacherCourseRepository
    {
        private readonly AppDbContext _context;
        public TeacherCourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<TeacherCourse> GetTeacherCourse(int teacherId)
        {
            return _context.TeacherCourses
                                .Include(x => x.Teacher)
                                .Include(c => c.Course)
                                .Where(x => x.TeacherId == teacherId) .ToList();
        }

        public List<TeacherCourse> GetTeacherCourses()
        {
            return _context.TeacherCourses.Include( x => x.Teacher).Include(c => c.Course).ToList();
        }

        public void AddCoursesByTeacher(TeacherCourse teacherCourse)
        {
            throw new NotImplementedException();
        }

        public void UpdateTeacher(int id, Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            _context.SaveChanges();
        }

        public void CreateTeacher(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
        }

        public void CreateTeacherCourse(TeacherCourseDto teacherCourse)
        {
            throw new NotImplementedException();
        }

        public void DeleteTeacher(int id)
        {
            var teacher = _context.Teachers.FirstOrDefault(x => x.Id == id);
            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
                _context.SaveChanges();
            }
        }

        public List<Teacher> GetTeachers()
        {
            return _context.Teachers.ToList();
        }

        public Teacher GetTeacher(int id)
        {
            return _context.Teachers.FirstOrDefault(x=> x.Id ==id);
        }

        public void AddCoursesByTeacher(TeacherCourseDto teacherCourse)
        {
            throw new NotImplementedException();
        }

        public void ManagementTeacherCourse(TeacherCourse teacherCourse)
        {
            _context.Entry<TeacherCourse>(teacherCourse);
            _context.Entry(teacherCourse).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void ManagementTeacherCourse(List<TeacherCourse> teacherCourse)
        {
            DetachAllEntities();
            _context.TeacherCourses.AddRange(teacherCourse);
            _context.SaveChanges();
        }

        public void DeleteManagementTeacherCourse(List<TeacherCourse> teacherCourse)
        {
            var teacherCoursesToDelete = _context.TeacherCourses
                                         .Where(tc => tc.TeacherId == teacherCourse.FirstOrDefault().TeacherId)
                                         .ToList();

            _context.TeacherCourses.RemoveRange(teacherCoursesToDelete);
            _context.SaveChanges();
        }

        public void UpdateManagementTeacherCourse(List<TeacherCourse> teacherCourse)
        {
            foreach (var updatedTeacherCourse in teacherCourse)
            {
                var local = _context.TeacherCourses
                                    .Local
                                    .FirstOrDefault(tc => tc.Id == updatedTeacherCourse.Id);

                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                }
            }

            _context.TeacherCourses.UpdateRange(teacherCourse);
            _context.SaveChanges();
        }

        private void DetachAllEntities()
        {
            var entries = _context.ChangeTracker.Entries().ToList();
            foreach (var entry in entries)
            {
                entry.State = EntityState.Detached;
            }
        }

    }
}
