﻿namespace Curso.Models
{
    public class Course
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<TeacherCourse> TeacherCourses { get; set; }

    }
}
