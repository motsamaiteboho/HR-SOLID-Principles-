/* 
 * Student names: Motsamai Teboho
 * Stuent Number: 2016206381
*/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Headers;
using static System.Console;

namespace HR
{
    class Program
    {
        static CEmployees employees;
        static void Main()
        {
            employees = new CEmployees();

            //Read from file
            CEmployees.Read();
            Menu();
        } //Main

        private static void Menu()
        {
            Clear();
            WriteLine("1. Add employee");
            WriteLine("2. List employees");
            WriteLine("3. Exit");
            char option = ReadKey().KeyChar.ToString().ToUpper()[0];

            switch (option)
            {
                case '1': AddEmployee(); Menu(); break;
                case '2': ListEmployees(); Menu(); break;
                case '3': break;
                default: Menu(); break;
            }
        } //Menu

        private static void AddEmployee()
        {
            try
            {
                Clear();
                Write("Number     : "); string number = ReadLine();
                Write("Name       : "); string name = ReadLine();
                Write("Type (S/C/H) : "); char type = ReadKey().KeyChar.ToString().ToUpper()[0];

                ReadLine();
                if (type == 'S')
                {

                    Write("Salary     : "); decimal salary = decimal.Parse(Console.ReadLine());
                    Write("Deductions : "); decimal deductions = decimal.Parse(Console.ReadLine());
                    //The Liskov Substition Principle (LSP) 
                    //Derived class(Salaried) is completely subsitutable for its base classes(employee)
                    employees.AddEmployee(new CSalaried(number, name, salary, deductions));

                }
                if (type == 'C')
                {
                    Write("Sales : "); decimal sales = decimal.Parse(Console.ReadLine());
                    Write("Percentage : "); double percentage = double.Parse(Console.ReadLine());
                    //The Liskov Substition Principle (LSP) 
                    //Derived class(Comission) is completely subsitutable for its base classes(employee)
                    employees.AddEmployee(new CCommission(number, name, sales, percentage));
                }

                if (type == 'H')
                {
                    Write("Hourly Salary : "); decimal HourlySalary = decimal.Parse(Console.ReadLine());
                    Write("Hours : "); double Hours = double.Parse(Console.ReadLine());
                    //The Liskov Substition Principle (LSP) 
                    //Derived class(Comission) is completely subsitutable for its base classes(employee)
                    employees.AddEmployee(new CHourly(number, name, HourlySalary, Hours));
                }

                //Save to file
                CEmployees.Save();
            }
            catch
            {
                Write("\n Invalid entry, Press any key to return to the menu ...");
                ReadKey();
                Menu();
            }
        } //AddEmployee

        private static void ListEmployees()
        {
            try
            {
                Clear();
                Console.Write("Type (S/C/H/A): ");
                char option = ReadKey().KeyChar.ToString().ToUpper()[0];

                ReadLine();
                //The Dependency Inversion Principle (DIP)
                //There is no no more dependency on the storage model.
                for (int i = 0; i < employees.Count; i++)
                {
                    if (option == 'S' && employees[i] is CSalaried)
                        WriteLine(employees[i]);
                    if (option == 'C' && employees[i] is CCommission)
                        WriteLine(employees[i]);
                    if (option == 'H' && employees[i] is CHourly)
                        WriteLine(employees[i]);
                    if (option == 'A')
                        WriteLine(employees[i]);
                }
                Write("\nPress any key to return to the menu ...");
                ReadKey();
            }
            catch
            {
                Write("\n Invalid entry, Press any key to return to the menu ...");
                ReadKey();
                Menu();
            }
                
        }//ListEmployees

    } //class
}
