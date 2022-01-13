/* 
 * Student names: Motsamai Teboho
 * Stuent Number: 2016206381
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR
{
    class CEmployees
    {
        //The Dependency Inversion Principle (DIP)
        //List is now private to comply with DIP priciple
        private static List<CEmployee> lstEmployees;

        public CEmployees()
        {
            lstEmployees = new List<CEmployee>();
        }
        public int Count
        {
            get
            {
                return lstEmployees.Count;
            }
        }
        public CEmployee this[int i]
        {
            get
            {
                return lstEmployees[i];
            }
        }
        public void AddEmployee(CEmployee employee)
        {
            lstEmployees.Add(employee);
        }

        //The Single Responsibility Principle (SRP)
        //The FileOperants class is concerned with saving employeees
        public static void Save()
        {
            CFileOperants.Save(lstEmployees);
        }

        //The Single Responsibility Principle (SRP)
        //The FileOperants class is concerned with reading employees
        public static void Read()
        {
            lstEmployees = CFileOperants.Read();
        }
    }
    //To comply with Single Responsibility Principle (SRP)
    // Class (Employees) is added deal with the basic operations of empleyees 
}
