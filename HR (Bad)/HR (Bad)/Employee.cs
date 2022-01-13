/* Pieter Blignaut
   CSIS2664, Project 1
   This is a very bad implementation of the problem scenario. Students are instructed to improve 
   it by applying proper design principles.
   September 2020
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

enum EmployeeType
{
    Salaried, Commission
} //enum EmployeeType

[Serializable]
class Employee
{
    private const string FILENAME = @"C:\\temp\\Employees.bin";

    public string Number { get; set; }
    public string Name { get; set; }
    public EmployeeType type { get; set; }
    public decimal salary { get; set; }
    public decimal deductions { get; set; }
    public decimal sales { get; set; }
    public double percentage { get; set; }

    public static List<Employee> lstEmployees = new List<Employee>();

    public Employee(string number, string name, char type)
    {
        this.Number = number;
        this.Name = name;
        if (type == 'S')
            this.type = EmployeeType.Salaried;
        if (type == 'C')
            this.type = EmployeeType.Commission;
        
        lstEmployees.Add(this);

    }//Constructor

    public decimal Payment()
    {
        if (type == EmployeeType.Salaried)
            return salary - deductions;
        if (type == EmployeeType.Commission)
            return sales * (decimal)(percentage/100.0);
        return 0;
    }  //Payment

    public override string ToString()
    {
        return $"Number: {Number}; Name: {Name}; Type: {type}; Payment: {Payment().ToString("0.00")}";
    } //ToString

    public static void Save()
    {
        FileStream fs = new FileStream(FILENAME, FileMode.Create);
        IFormatter formatter = new BinaryFormatter();
        formatter.Serialize(fs, lstEmployees);
        fs.Close();
    } //Save

    public static void Read ()
    {
        if (!File.Exists(FILENAME))
            return;

        FileStream fs = new FileStream(FILENAME, FileMode.Open);
        IFormatter formatter = new BinaryFormatter();
        lstEmployees = (List<Employee>)formatter.Deserialize(fs);
        fs.Close();
    } //Read

} //class Employee

