/* 
 * Student names: Motsamai Teboho
 * Stuent Number: 2016206381
*/using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace HR
{
    [Serializable]
    public class CFileOperants
    {
            private const string FILENAME = "Employees.bin";
            public static void Save(List<CEmployee> lstEmployees)
            {
                FileStream fs = new FileStream(FILENAME, FileMode.Create);
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, lstEmployees);
                fs.Close();
            } //Save

            public static List<CEmployee> Read()
            {
                List<CEmployee> lstEmployees = new List<CEmployee>();
                if (!File.Exists(FILENAME))
                    return null;

                FileStream fs = new FileStream(FILENAME, FileMode.Open);
                IFormatter formatter = new BinaryFormatter();
                if (fs.Length > 0)
                   lstEmployees = (List<CEmployee>)formatter.Deserialize(fs);
                fs.Close();
                return lstEmployees;
            } //Read

    }
    //The Single Responsibility Principle (SRP)
    //The class(FileOperants) only has one resposibility of dealing with File(Save and Read)
}
