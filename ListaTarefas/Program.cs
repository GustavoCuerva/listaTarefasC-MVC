using ListaTarefas.Data;
using ListaTarefas.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace ListaTarefas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            const string server = "GUSTAVO\\SQLEXPRESS", 
            database = "DB_Tasks",
            user = "sa",
            pass = "123456789";


            builder.Services.AddControllersWithViews();
            builder.Services.AddEntityFrameworkSqlServer().AddDbContext<BancoContext>(o => o.UseSqlServer("Server="+server+";Database="+database+";User Id="+user+";Password="+pass+";Encrypt=False"));
            builder.Services.AddScoped<ITaskRepositorio, TaskRepositorio>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Task}/{action=Index}/{id?}");

            app.Run();
        }
    }
}