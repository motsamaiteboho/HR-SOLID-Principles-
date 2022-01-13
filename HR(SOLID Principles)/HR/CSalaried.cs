/* 
 * Student names: Motsamai Teboho
 * Stuent Number: 2016206381
*/using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HR
{
    [Serializable]
    public class CSalaried : CEmployee
    {
        public decimal salary { get; set; }
        public decimal deductions { get; set; }

        public CSalaried(string number, string name, decimal salary, decimal deductions) : base(number, name)
        {
            this.salary = salary;
            this.deductions = deductions;
        }
        public override decimal Payment()
        {
            return salary - deductions;
        }
        public override string ToString()
        {
            return $"Number: {Number}; Name: {Name}; Type: Salaried ; Payment: {Payment().ToString("0.00")}";
        } //ToString
    }

}
