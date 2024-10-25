using System;
using System.Linq;
using lab_5.Data;
using lab_5.Models;

namespace lab_5.Services
{
    public class EmployeeService
    {
        private readonly ApplicationContext _context;

        public EmployeeService(ApplicationContext context)
        {
            _context = context;
        }

        public int GetPositionsWithBonusesCount()
        {
            return _context.Employee
                .Where(e => e.Bonus.Any())
                .Select(e => e.Position)
                .Distinct()
                .Count();
        }

        public string[] GetFemaleEmployeesWithSalaryAboveAveragePension()
        {
            // Отримати зарплати працівників віком 60+
            var salaries = _context.Employee
                .Where(e => (DateTime.Now.Year - e.BirthDate.Year) >= 60)
                .Select(e => e.Salary)
                .ToList(); 

            var averagePensionSalary = salaries.Any() ? salaries.Average() : 0;

            // Вибірка жінок з зарплатою вище середньої пенсійної
            return _context.Employee
                .Where(e => e.Gender == "Жінка" &&
                            (e.Salary + (decimal)(e.Bonus.Sum(b => b.Amount) * 0.8)) > averagePensionSalary)
                .Select(e => e.LastName)
                .ToArray();
        }


        public void PrintShopEmployeeBonusCounts()
        {
            var shopEmployeeBonusCounts = _context.Employee
                .GroupBy(e => e.ShopNumber)
                .Select(g => new
                {
                    ShopNumber = g.Key,
                    Count = g.Select(e => e.Bonus
                        .GroupBy(b => b.Date.Year)
                        .Count(yearGroup => yearGroup.Count() >= 2)
                    ).Any() ? g.Count() : 0
                });

            foreach (var shop in shopEmployeeBonusCounts)
            {
                Console.WriteLine($"Цех: {shop.ShopNumber}, Кількість працівників з премією хоча б двічі: {shop.Count}");
            }
        }
    }
}
