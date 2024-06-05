using Curso.Data;
using Curso.Mappers;
using Curso.Repository;
using Curso.Repository.Interfaces;
using Curso.Services;
using Curso.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});



builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<IStudentRepository, StudentRepository>();

builder.Services.AddTransient<ICourseService, CourseService>();
builder.Services.AddTransient<ICourseRepository, CourseRepository>();

builder.Services.AddTransient<ITeacherCourseService, TeacherCourseService>();
builder.Services.AddTransient<ITeacherCourseRepository, TeacherCourseRepository>();

builder.Services.AddTransient<IStudentCourseRepository , StudentCourseRepository>();
builder.Services.AddTransient<IStudentCourseService, StudentCourseService>();

builder.Services.AddAutoMapper(typeof(AppProfile));



var app = builder.Build();

//using(var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    var context = services.GetRequiredService<AppDbContext>();
//    context.Database.Migrate();

//    var userContext = services.GetRequiredService<AdminContext>();
//    userContext.Database.Migrate();

    

//}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
