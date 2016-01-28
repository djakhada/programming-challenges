using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace challenges
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Programming Challenges v1.3 programmed by github.com/sinnzr");
            Console.WriteLine("Content:");
            Console.ResetColor();
            Console.WriteLine("00: Identitity generator");
            Console.WriteLine("02: Temperature Converter :INCOMPLETE");
            Console.WriteLine("03: Fizzbuzz");
            string key = Console.ReadLine();
            switch (key)
            {
                case "00":
                    GenerateIdentity();
                    break;
                case "02":
                    ConvertTemp();
                    break;
                case "03":
                    Fizzbuzz();
                    break;
                    
            }
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
                if (Regex.IsMatch(input, "y", RegexOptions.IgnoreCase))
                {
                    Console.Write("What gender?[f/m]: ");
                    input = Console.ReadLine();
                    if (Regex.IsMatch(input, "f", RegexOptions.IgnoreCase))
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
                Console.Clear();
                int r = new Random().Next(namesMale.Count);
                int rs = new Random().Next(surnames.Count);
                Console.WriteLine("Surname: " + surnames[rs]);
                Console.WriteLine("Name: " + namesMale[r]);
                Console.WriteLine("Age: " + new Random().Next(1,100));
                Console.Write("Generate another?[Y/N]: ");
                string input = Console.ReadLine();
                if (Regex.IsMatch(input, "y", RegexOptions.IgnoreCase)) GenerateIdentity("male");
                else Main(null);
            }
            else if (type == "female") //female
            {
                Console.Clear();
                int r = new Random().Next(namesFemale.Count);
                int rs = new Random().Next(surnames.Count);
                Console.WriteLine("Surname: " + surnames[rs]);
                Console.WriteLine("Name: " + namesFemale[r]);
                Console.WriteLine("Age: " + new Random().Next(1, 100));
                Console.Write("Generate another?[Y/N]: ");
                string input = Console.ReadLine();
                if (Regex.IsMatch(input, "y", RegexOptions.IgnoreCase)) GenerateIdentity("female");
                else Main(null);
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
                Console.Write("Generate another?[Y/N]: ");
                string input = Console.ReadLine();
                if (Regex.IsMatch(input, "y", RegexOptions.IgnoreCase)) GenerateIdentity("auto");
                else Main(null);
            }
            

        }


        // I D E N T I T Y  G E N E R A T O R


        // C O N V E R T T E M P


        static void ConvertTemp(int temperature = 0, string unit = "celsius")
        {

        }


        // C O N V E R T T E M P


        static void Fizzbuzz()
        {
            for (int i=1; i < 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Ne");
                }
                else if (i % 5 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("De");
                }
                else if (i % 3 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Su");
                }
                else Console.WriteLine(i);
                Console.ResetColor();
            }
            Console.ReadLine();
            Console.ResetColor();
        }

    }
}
