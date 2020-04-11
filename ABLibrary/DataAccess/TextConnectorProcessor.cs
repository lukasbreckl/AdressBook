using ABLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABLibrary.DataAccess.TextHelpers
{
    public static class TextConnectorProcessor
    {
        public static string FullFilePath (this string fileName)
        {
            return $"{ConfigurationManager.AppSettings["filePath"]}\\{fileName} ";
        }

        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }
            return File.ReadAllLines(file).ToList();
        }
        
        public static List<ContactModel> ConvertToContactModel (this List<string> lines)
        {
            List<ContactModel> output = new List<ContactModel>();
            foreach (string  line in lines)
            {
                string[] cols = line.Split(',');
                ContactModel c = new ContactModel();
                c.id = int.Parse(cols[0]);
                c.FirstName = cols[1];
                c.LastName = cols[2];
                c.PhoneNumber = cols[3];
                output.Add(c);

            }
            return output;
        } 

        public static void SaveToContacts(this List<ContactModel> models, string fileName)
        {
            List<string> lines = new List<string>();
            foreach (ContactModel c in models)
            {
                lines.Add($"{c.id},{c.FirstName},{c.LastName},{c.PhoneNumber}");
            }
            File.WriteAllLines(fileName.FullFilePath(), lines);

        }
    }
}
