using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab15
{
    class CountriesApp
    {
        const string FILENAME = "countries.txt";

        static void Main(string[] args)
        {
            bool repeat = true;
            while (repeat)
            {
                bool again = true;
                while (again)
                {
                    Console.WriteLine("Welcome to the Countries Maintence Application!\n\n1.Display a list of countries.\n2.Add a country to the list.\n3.Quit\n");
                    Console.WriteLine("Please choose a menu number (1-3)");
                    string input = Console.ReadLine();
                    int.TryParse(input, out int num);

                    if (num == 1)
                    {
                        ArrayList countries = CountriesTextFile.readFromFile(FILENAME);

                        //output countries
                        foreach (CountriesTextFile s in countries)
                        {
                            Console.WriteLine(s.Country);
                        }
                        break;
                    }
                    if (num == 2)
                    {
                        ArrayList countries = CountriesTextFile.readFromFile(FILENAME);
                        foreach (CountriesTextFile s in countries)
                        {
                            Console.WriteLine(s.Country);
                        }
                        Console.Write("\nWhat country did you want to add? ");
                        string country = Console.ReadLine();

                        CountriesTextFile c = new CountriesTextFile(country);

                        countries.Add(c);

                        CountriesTextFile.writeToFile(FILENAME, countries);
                        break;
                    }
                    if (num == 3)
                    {
                        Console.WriteLine("Goodbye!");
                        repeat = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please try again.");
                        again = true;
                    }
                }
            repeat = Validator.DoAgain("Would you like to run the program again? (Y or N)");
            }
            Console.WriteLine("Goodbye!");
        }
        
    }
}
