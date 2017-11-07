using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab15
{
    class CountriesTextFile
    {
        private string country;

        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        public CountriesTextFile(string country)
        {
            this.country = country;
        }
        public static ArrayList readFromFile(string filename)
        {
            StreamReader inputFile;
            try
            {
                inputFile = new StreamReader(filename);
            }
            catch (SystemException e)
            {
                Console.WriteLine("Error accessing file.  Please check file permissions.");
                Console.WriteLine($"Detailed Info: {e.Message}");
                return null;
            }

            ArrayList countries = new ArrayList();
            while (true)
            {
                string line = inputFile.ReadLine();
                if (line == null || line == "")
                {
                    break;
                }
                string[] parts = line.Split('\t');
                if (parts.Length < 1)
                {
                    Console.WriteLine("Error in file format. Line contents " + line);
                    break;
                }
                string country = parts[0];
                CountriesTextFile c = new CountriesTextFile(country);
                countries.Add(c);
            }
            inputFile.Close();

            Console.WriteLine("List of Countries\n");
            return countries;
        }
        public static void writeToFile(string filename, ArrayList countries)
        {

            StreamWriter outputFile = new StreamWriter(filename, false);
            foreach (CountriesTextFile c in countries)
            {
                outputFile.WriteLine($"{c.Country}");
            }

            outputFile.Close();
        }

        public override string ToString()
        {
            return $"{country,-20}";
        }


    }
}
