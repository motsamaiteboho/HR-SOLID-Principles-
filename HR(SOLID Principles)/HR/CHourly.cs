/* 
 * Student names: Motsamai Teboho
 * Stuent Number: 2016206381
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR
{
    [Serializable]
    class CHourly: CEmployee
    {
        public decimal HourlySalary { get; set; }
        public double Hours { get; set; }

        public CHourly(string number, string name, decimal HourlySalary, double Hours) : base(number, name)
        {
            this.HourlySalary = HourlySalary;
            this.Hours = Hours;
        }
        public override decimal Payment()
        {
            return HourlySalary * (decimal)(Hours);
        }
        public override string ToString()
        {
            return $"Number: {Number}; Name: {Name}; Type: Hourly ; Payment: {Payment().ToString("0.00")}";
        } //ToString
    }
}
