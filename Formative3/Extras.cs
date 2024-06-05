using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Text.Json;

class Extras
{
    private static SoundPlayer BG_Music = new SoundPlayer(@"..\..\..\Music\BG_music.wav");
    
    public static void Play_BG()
    {
        BG_Music.Play();
    }
    public static void Stop_BG()
    {
        BG_Music.Stop();
    }
}

class Mechanics
{
    public static void Options()
    {

    }

    public static void Check_Stats()
    {

    }

    public static void Create_Save(List<Animal> animals)
    {
        try
        {
            // create the variables for player object
            string Name;
            double cash;
            double bank;
            string[] inventory;
            string[] storage;
            int AttractionPoints;
            int customers;
            int HappinessLevel;
            //prompt user for Zoo Name
            Console.WriteLine("What will be the name of your Zoo?");
            string name = Console.ReadLine();
            Console.WriteLine($"Are you sure you want your Zoo to be called {name}? (y/n)");
            string sure_about_that = Console.ReadLine();
            if (sure_about_that.ToLower().Equals("y") || sure_about_that.ToLower().Equals("yes") || sure_about_that.ToLower().Equals("ye"))
            {
                Name = name;
                cash = 1000;
                bank = 0;
                inventory = ["", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""];
                storage = ["", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""];
                AttractionPoints = 0;
                customers = 0;
                HappinessLevel = 0;
                // create the player object/zoo object
                Zoo player = new Zoo(Name, cash, bank, inventory, AttractionPoints, customers, HappinessLevel, storage);

                string jsonString1 = JsonSerializer.Serialize(player, new JsonSerializerOptions { WriteIndented = true });
                string jsonString2 = JsonSerializer.Serialize(animals, new JsonSerializerOptions { WriteIndented = true });

                // Write the JSON string to a file
                string filePath = $@"..\..\..\Save_Files\ZMS_{Name}_saveFile.json";
               // StreamWriter streamWriter = File.WriteAllText(filePath, jsonString1);
                //streamWriter = File.AppendText(jsonString2);

                Console.WriteLine($"JSON file created at: {Path.GetFullPath(filePath)}");
            }
            else if (sure_about_that.ToLower().Equals("n") || sure_about_that.ToLower().Equals("no"))
            {
                Create_Save(animals);
            }
            else
            {
                Console.WriteLine(ErrorList.Error5());
                Console.ForegroundColor = ConsoleColor.Gray;
                Create_Save(animals);
            }
        } catch (FormatException e)
        {
            Console.WriteLine(ErrorList.Error2());
            Console.ForegroundColor = ConsoleColor.Gray;
            Create_Save(animals);
        } catch (Exception e)
        {
            Console.WriteLine(ErrorList.Error6());
            Console.ForegroundColor= ConsoleColor.Gray;
            Create_Save(animals);
        }
    }

    public static void Load_Save()
    {

    }
}
