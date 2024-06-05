using AutoMapper;
using Curso.Models;
using Curso.Models.Dtos;

namespace Curso.Mappers
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<Course , CourseDto>().ReverseMap();
            CreateMap<Student , StudentDto>().ReverseMap();
            CreateMap<Student, SaveStudentDto>().ReverseMap();
            CreateMap<Teacher , TeacherDto>().ReverseMap();
            CreateMap<TeacherCourse , TeacherCourseDto>()
                .ForMember(x => x.NameTeacher, d => d.MapFrom(src => src.Teacher.Name))
                .ForMember(x => x.Email , d => d.MapFrom(src => src.Teacher.Email) )
                .ForMember(x => x.CPF , d => d.MapFrom(src => src.Teacher.CPF))
                .ForMember(x => x.Price, d => d.MapFrom(src => src.Course.Price))
                .ForMember(x => x.CourseName, d => d.MapFrom(src => src.Course.Name))
                .ForMember(x => x.Description, d=> d.MapFrom(src => src.Course.Description))
                .ReverseMap();
            CreateMap<TeacherCourse,ManagementTeacherCourseDto>().ReverseMap();
        }
    }
}
