using System;
using System.Collections.Generic;
using System.Linq;


namespace Lab_2
{
    public class EmployeeFactory
    {
        public List<Employee> GetEmployees()
        {
            return new List<Employee>
                {
                    new Employee { Code = 1, LastName = "Мельничук", BirthDate = new DateTime(1960, 3, 15), Gender = "Чоловік", ShopNumber = 1, Position = "Інженер", Experience = 30, Salary = 15000 },
                    new Employee { Code = 2, LastName = "Коваленко", BirthDate = new DateTime(1985, 7, 20), Gender = "Жінка", ShopNumber = 2, Position = "Бухгалтер", Experience = 15, Salary = 12000 },
                    new Employee { Code = 3, LastName = "Ковальчук", BirthDate = new DateTime(1999, 5, 27), Gender = "Жінка", ShopNumber = 3, Position = "Маркетолог", Experience = 5, Salary = 25000 },

            };
        }

        public List<Bonus> GetBonuses()
        {
            return new List<Bonus>
                {
                    new Bonus { WorkerCode = 1, Amount = 500, Date = new DateTime(2023, 1, 5) },
                    new Bonus { WorkerCode = 1, Amount = 600, Date = new DateTime(2023, 12, 5) },
                    new Bonus { WorkerCode = 2, Amount = 700, Date = new DateTime(2023, 6, 15) },
                    new Bonus { WorkerCode = 3, Amount = 1500, Date = new DateTime(2024, 7, 18) },
                };
        }
    }
    public static class EmployeeStatistics
    {
        public static void CalculatePositionCountWithBonus(List<Employee> employees, List<Bonus> bonuses)
        {
            var positionsWithBonus = employees
                .Join(bonuses, e => e.Code, b => b.WorkerCode, (e, b) => e.Position)
                .Distinct()
                .Count();

            Console.WriteLine($"Кількість посад працівників з премією: {positionsWithBonus}");
        }

        public static void CalculateWomenWithHighSalary(List<Employee> employees, List<Bonus> bonuses)
        {
            var pensionersAverageSalary = employees
                .Where(e => (DateTime.Now.Year - e.BirthDate.Year) >= 60)
                .Average(e => e.Salary);

            var womenWithHighSalary = employees
                .Where(e => e.Gender == "Жінка")
                .Join(bonuses, e => e.Code, b => b.WorkerCode, (e, b) => new { e.LastName, TotalSalary = e.Salary + b.Amount * 0.8 })
                .Where(e => e.TotalSalary > pensionersAverageSalary)
                .Select(e => e.LastName)
                .ToArray();

            Console.WriteLine("Прізвища жінок з високою зарплатою:");
            foreach (var name in womenWithHighSalary)
            {
                Console.WriteLine(name);
            }
        }

        public static void CalculateShopEmployeeBonusCount(List<Employee> employees, List<Bonus> bonuses)
        {
            var employeesWithMultipleBonuses = bonuses
                .GroupBy(b => new { b.WorkerCode, b.Date.Year })
                .Where(g => g.Count() >= 2)
                .Select(g => g.Key.WorkerCode)
                .Distinct();

            var employeesByShop = employees
                .Where(e => employeesWithMultipleBonuses.Contains(e.Code))
                .GroupBy(e => e.ShopNumber)
                .Select(g => new { ShopNumber = g.Key, EmployeeCount = g.Select(e => e.Code).Distinct().Count() });

            Console.WriteLine("Кількість працівників, які отримували премію двічі за рік по цехах:");
            foreach (var shop in employeesByShop)
            {
                Console.WriteLine($"Цех {shop.ShopNumber}: {shop.EmployeeCount} працівників");
            }
        }
    }
}

