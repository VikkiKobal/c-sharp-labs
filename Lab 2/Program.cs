using System;
using System.Collections.Generic;


namespace Lab_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeFactory factory = new EmployeeFactory();
            List<Employee> employees = factory.GetEmployees();
            List<Bonus> bonuses = factory.GetBonuses();

            EmployeeStatistics.CalculatePositionCountWithBonus(employees, bonuses);
            EmployeeStatistics.CalculateWomenWithHighSalary(employees, bonuses);
            EmployeeStatistics.CalculateShopEmployeeBonusCount(employees, bonuses);
        }
    }
}

