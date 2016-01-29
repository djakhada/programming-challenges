using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace challenges
{
    class cs1
    {
        public void ěščřžýáí() //props to Chinese_Soup for picking the name
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Content:");
            Console.ResetColor();
            Console.WriteLine("00: Identitity generator");
            Console.WriteLine("01: Temperature Converter");
            Console.WriteLine("02: Fizzbuzz");
            string key = Console.ReadLine();
            switch (key)
            {
                case "0":
                case "00":
                    GenerateIdentity();
                    break;
                case "1":
                case "01":
                    Console.WriteLine("");
                    Console.WriteLine("Format: 100C(elsius) in F(ahrenheit)");
                    string input = Console.ReadLine();
                    Console.WriteLine(ConvertTemp(input));
                    Console.WriteLine("");
                    ěščřžýáí();
                    break;
                case "2":
                case "02":
                    Fizzbuzz();
                    break;
                default:
                    ěščřžýáí();
                    break;
            }
            Console.WriteLine("");
        }

        //I D E N T I T Y  G E N E R A T O R


        static List<String> surnames = new List<String>(){
            "Corlett","Smith","Howell","Brown","Black","White","Gruber",
            "Mayer","Moser","Weber","Schmid","Rəsulov","Hüseynov","Козлов",
            "Jensen","Nielsen","Hansen","Virtanen","Järvinen","Niemi","Salo",
            "Laitinen","Tuominen","Koskinen","Mattila","Dubois","Bernard","Moreau",
            "Michel","Roux","Lefebvre","Lomidze","Martinez","Vakovic","Lasic","Bolkvadze",
            "Dzudzevic","Müller","Becker","Fischer","Schmidt","Nagy","Varga","Farkas","Balogh",
            "Papp","Murphy","Walsh","O'Neill","Murray","Ricci","Rossi","Greco"
        };

        static List<String> namesMale = new List<String>(){
            "Mohamed","Abdelkader","Ali","Rachid","Said","Brahim","Omar","Djamel",
            "Youssef","Mustapha","Santiago","Mateo","Juan","Nicolás","Benjamín","Pedro",
            "Daniel","Miguel","Dylan","Kevin","David","Arthur","Gabriel","Bernado",
            "Liam","Jackson","Logan","Lucas","Noah","Ethan","Jack","William",
            "Owen","Jayden","Diego","Thomas","Ryan","Matthew","Neil","John","James",
            "Robert","Michael","An","Bo","Cheng","De","Dong","Feng","Gang","Guo","Hui","Jian",
            "Wei","Peng","Liang","Marc","Jan","Ian","Enzo","Aaron","Alexander","Conor",
            "Lewis","Charlie","Markuss","Artjoms","Gustavo","Nikola","Maxim","Dejan",
            "Sem","Levi","Bram","Daan","Finn","Jakub","Kacper","Filip","Andrei","Francisco",
            "Lukas","Oliver","Leon","Cooper","Lachlan","Henry","Tyler","Tom"
        };

        static List<String> namesFemale = new List<String>(){
            "Fatma","Maha","Reem","Farida","Aya","Rowan","Irene","Hana","Maria","Sofia","Sophia",
            "Alice","Julia","Isabella","Manuela","Laura","Emma","Olivia","Zoe","Emily","Chloe",
            "Charlotte","Abigail","Scarlett","Hannah","Avery","Lea","Mia","Madison","Skylar","Serenity",
            "Angela","Victoria","Riya","Diya","Elizabeth","Mary","Linda","Barbara","Jennifer","Susan","Sakura",
            "Riko","Aoi","Wakana","Rin","Anri","Anna","Azuna","Himari","Yuna","Kaede","Lucie"
        };

        static void GenerateIdentity(string type = "none")
        {
            if (type == "none") //selection
            {
                Console.Clear();
                Console.Write("Specify gender?[Y/n]: ");
                string input = Console.ReadLine();
                if (input.ToUpper().Equals("Y"))
                {
                    Console.Write("What gender?[f/m]: ");
                    input = Console.ReadLine();
                    if (input.ToUpper().Equals("F"))
                    {
                        GenerateIdentity("female");
                    }
                    else
                    {
                        GenerateIdentity("male");
                    }
                }
                else GenerateIdentity("auto");
            }
            else if (type == "male") //male
            {
                int r = new Random().Next(namesMale.Count);
                int rs = new Random().Next(surnames.Count);
                Console.WriteLine("Surname: " + surnames[rs]);
                Console.WriteLine("Name: " + namesMale[r]);
                Console.WriteLine("Age: " + new Random().Next(1, 100));
                Console.Write("Generate another?[Y/n]: ");
                string input = Console.ReadLine();
                if (input.ToUpper().Equals("Y")) GenerateIdentity("male");
                else new cs1().ěščřžýáí();
            }
            else if (type == "female") //female
            {
                int r = new Random().Next(namesFemale.Count);
                int rs = new Random().Next(surnames.Count);
                Console.WriteLine("Surname: " + surnames[rs]);
                Console.WriteLine("Name: " + namesFemale[r]);
                Console.WriteLine("Age: " + new Random().Next(1, 100));
                Console.Write("Generate another?[Y/n]: ");
                string input = Console.ReadLine();
                if (input.ToUpper().Equals("Y")) GenerateIdentity("female");
                else new cs1().ěščřžýáí();
            }
            else //no gender specified
            {
                Console.Clear();
                int rg = new Random().Next(2);
                string name = "none";
                if (rg == 1)
                {
                    int r = new Random().Next(namesFemale.Count);
                    name = namesFemale[r];
                }
                else
                {
                    int r = new Random().Next(namesMale.Count);
                    name = namesMale[r];
                }

                int rs = new Random().Next(surnames.Count);
                Console.WriteLine("Surname: " + surnames[rs]);
                Console.WriteLine("Name: " + name);
                Console.WriteLine("Age: " + new Random().Next(1, 100));
                Console.Write("Generate another?[Y/n]: ");
                string input = Console.ReadLine();
                if (input.ToUpper().Equals("Y")) GenerateIdentity("auto");
                else new cs1().ěščřžýáí();
            }


        }


        // I D E N T I T Y  G E N E R A T O R


        // C O N V E R T T E M P


        static string ConvertTemp(string input)
        {
            float outputn = 0.111F;
            string searched = "in";
            string outf = input.Substring(input.IndexOf(searched) + searched.Length); //output format e.g: Fahrenheit or F
            input = input.Remove(input.IndexOf(searched) - 1);
            float inputn = float.Parse(Regex.Match(input, @"(-)?\d+").Value); //input number e.g: 123
            float originalinput = inputn;
            input = input.Replace(inputn.ToString(), ""); //input is the input format now e.g: C or Celsius

            if (outf.ToUpper().Contains('F')) outf = "Fahrenheit";
            else if (outf.ToUpper().Contains('C')) outf = "Celsius";
            else if (outf.ToUpper().Contains('K')) outf = "Kelvin";
            else return "Wrong Input.";

            if (input.ToUpper().Contains('F')) input = "Fahrenheit";
            else if (input.ToUpper().Contains('C')) input = "Celsius";
            else if (input.ToUpper().Contains('K')) input = "Kelvin";
            else return "Wrong Input.";

            //First we convert the given temperature to Celsius
            if (input == "Fahrenheit")
            {
                inputn = (5.0F / 9.0F) * (inputn - 32);
            }
            else if (input == "Kelvin")
            {
                inputn = inputn - 273.15F;
            }

            if (outf == "Fahrenheit")
            {
                outputn = (inputn * (9.0F / 5.0F)) + 32;
            }
            else if (outf == "Kelvin")
            {
                outputn = inputn + 273.15F;
            }
            else
            {
                outputn = inputn;
            }

            return "Input: " + originalinput + " " + input + " in " + outf + "\n" + "Output: " + outputn + " " + outf;

        }


        // C O N V E R T T E M P


        static void Fizzbuzz()
        {
            for (int i = 1; i < 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Pop");
                }
                else if (i % 5 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Buzz");
                }
                else if (i % 3 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Fizz");
                }
                else Console.WriteLine(i);
                Console.ResetColor();
            }
            Console.WriteLine("");
            new cs1().ěščřžýáí();
        }
    }
}
