/* Pieter Blignaut
   CSIS2664, Project 1
   This is a very bad implementation of the problem scenario. Students are instructed to improve 
   it by applying proper design principles.
   September 2020
*/

using System;
using static System.Console;

class Program
{
    static void Main()
    {
        Employee.Read();
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
            case '1' : AddEmployee(); Menu(); break;
            case '2' : ListEmployees(); Menu(); break;
            case '3' : break;
            default  : Menu(); break;
        }
    } //Menu

    private static void AddEmployee()
    {
        Clear();
        Write("Number     : "); string number = ReadLine();
        Write("Name       : "); string name = ReadLine();
        Write("Type (S/C) : "); char type = ReadLine()[0];
        Employee employee = new Employee(number, name, type);
        if (type == 'S')
        {
            Write("Salary     : "); employee.salary = decimal.Parse(Console.ReadLine());
            Write("Deductions : "); employee.deductions = decimal.Parse(Console.ReadLine());
        }
        if (type == 'C')
        {
            Write("Sales : ");      employee.sales = decimal.Parse(Console.ReadLine());
            Write("Percentage : "); employee.percentage = double.Parse(Console.ReadLine());
        }

        Employee.Save();
    } //AddEmployee

    private static void ListEmployees()
    {
        Clear();
        Console.Write("Type (S/C/A): ");
        char option = ReadKey().KeyChar.ToString().ToUpper()[0];
        if (option == 'S')
            ListEmployees("Salaried");
        if (option == 'C')
            ListEmployees("Commissioned");
        if (option == 'A')
            ListEmployees("All");

    }//ListEmployees

    private static void ListEmployees(string type)
    {
        Clear();

        foreach (Employee employee in Employee.lstEmployees)
        {
            if (type == "Salaried" && employee.type == EmployeeType.Salaried)
                WriteLine(employee);
            if (type == "Commissioned" && employee.type == EmployeeType.Commission)
                WriteLine(employee);
            if (type == "All")
                WriteLine(employee);
        } //foreach

        Write("\nPress any key to return to the menu ...");
        ReadKey();

    } //ListEmployees

} //class

