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
   [Serializable]
    public abstract class CEmployee
    {
        
        public string Number { get; set; }
        public string Name { get; set; }
        public CEmployee(string number, string name)
        {
            this.Number = number;
            this.Name = name;
        }//Constructor
        public abstract decimal Payment();
    }
    //To comply with Single Responsibility Principle (SRP)
    // Class (Employee) only deal with the details of empleyee

    //The Open/Closed Principle (OCP) 
    //Class(Employee) is now open for extention and closed for modification

    //The Interface Segregation Principle (ISP)
    //Base class(Employee) doesn't have methods which are not relevant to derived classes that the derived class will have to  inherit.
}
