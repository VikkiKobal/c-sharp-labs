using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore; 
using lab_5.Data;
using lab_5.Services;

namespace lab_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddDbContext<ApplicationContext>(options =>
                    options.UseSqlServer(@"Server=DESKTOP-T94V6UV\SQLEXPRESS;Database=EmployeeDB;Trusted_Connection=True;TrustServerCertificate=True;"));

                    services.AddScoped<EmployeeService>();
                })
                .Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var employeeService = services.GetRequiredService<EmployeeService>();

                    // Виведення кількості посад працівників, які мають премію
                    var positionsCount = employeeService.GetPositionsWithBonusesCount();
                    Console.WriteLine($"Кількість посад працівників, які мають премію: {positionsCount}");

                    // Запис у масив прізвищ працівників-жінок з зарплатою
                    var femaleEmployees = employeeService.GetFemaleEmployeesWithSalaryAboveAveragePension();
                    Console.WriteLine("Прізвища працівників-жінок з зарплатою, більшою за середній оклад пенсіонерів:");
                    foreach (var lastName in femaleEmployees)
                    {
                        Console.WriteLine(lastName);
                    }

                    // Виведення кількості працівників для кожного цеху
                    employeeService.PrintShopEmployeeBonusCounts();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Виникла помилка: {ex.Message}");
                }
            }

            Console.WriteLine("Натисніть будь-яку клавішу для виходу!");
            Console.ReadKey();
        }
    }
}
