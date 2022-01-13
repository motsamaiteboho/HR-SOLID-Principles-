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
    public class CCommission : CEmployee
    {
        public decimal sales { get; set; }
        public double percentage { get; set; }

        public CCommission(string number, string name, decimal sales, double percentage) : base(number, name)
        {
            this.sales = sales;
            this.percentage = percentage;
        }

        public override decimal Payment()
        {
            return sales * (decimal)(percentage / 100.0);
        }
        public override string ToString()
        {
            return $"Number: {Number}; Name: {Name}; Type: Commossioned ; Payment: {Payment().ToString("0.00")}";
        } //ToString
    }
}
