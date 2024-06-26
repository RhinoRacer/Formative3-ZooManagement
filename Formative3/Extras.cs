using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.PortableExecutable;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;
using System.Numerics;

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
            string? Name;
            double? cash;
            double? bank;
            string[]? inventory;
            string[]? storage;
            int? AttractionPoints;
            int? customers;
            int? HappinessLevel;
            //prompt user for Zoo Name
            Console.WriteLine("What will be the name of your Zoo?");
            Console.ForegroundColor = ConsoleColor.Blue;
            string name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
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
                Zoo player = new Zoo(Name, cash, bank, inventory, storage, AttractionPoints, customers, HappinessLevel, animals);

                string Save_Info = JsonSerializer.Serialize(player, new JsonSerializerOptions { WriteIndented = true });

                // Write the JSON string to a file
                string filePath = $@"..\..\..\Save_Files\ZMS_{Name}_saveFile.json";

                using (StreamWriter streamWriter = new StreamWriter(filePath))
                {
                    streamWriter.Write(Save_Info);
                    streamWriter.Close();
                }
                
                Console.WriteLine($"Save file created at: {Path.GetFullPath(filePath)}");

                Program.Play(player, animals);
            }
            else if (sure_about_that.ToLower().Equals("n") || sure_about_that.ToLower().Equals("no"))
            {
                Create_Save(animals);
            }
            else
            {
                Console.WriteLine(ErrorList.Error6());
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
            Console.WriteLine(e.Message);
            Console.ForegroundColor= ConsoleColor.Gray;
            Create_Save(animals);
        }
    }
    public static void Load_Save(string file_num_str, string[] files)
    {
        try
        {
            int file_num = Convert.ToInt32(file_num_str);
            StreamReader currentFile = new StreamReader(files[file_num]); // get user chosen file
            if (currentFile == null)
            {
                Console.WriteLine(ErrorList.Error4()); // if the file is empty, throw error file not found.
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                
                var json = currentFile.ReadToEnd();
                var player = JsonSerializer.Deserialize<Zoo>(json, new JsonSerializerOptions { IncludeFields = true })!;
                List<Animal> animals = player.Animals;

                Console.ForegroundColor = ConsoleColor.Gray;
                currentFile.Close();
                Program.Play(player, animals);
            }
        }
        catch (FormatException e)
        {
            Console.WriteLine(ErrorList.Error2());
            Console.ForegroundColor = ConsoleColor.Gray;
            Load_Save();
        }
        catch (Exception e)
        {
            Console.WriteLine(ErrorList.Error6());
            Console.WriteLine(e.Message);
            Console.ForegroundColor = ConsoleColor.Gray;
            Load_Save();
        }
    }

    public static void Save_Game(Zoo player, List<Animal> animals)
    {
        try
        {
            string? Name = player.Name;
            double? cash = player.Cash;
            double? bank = player.Bank;
            string[]? inventory = player.Inventory;
            string[]? storage = player.Storage;
            int? AttractionPoints = player.AP;
            int? customers = player.Customers;
            int? HappinessLevel = player.HL;
            // create the player object/zoo object
            Zoo Player = new Zoo(Name, cash, bank, inventory, storage, AttractionPoints, customers, HappinessLevel, animals);

            string Save_Info = JsonSerializer.Serialize(Player, new JsonSerializerOptions { WriteIndented = true });

            // Write the JSON string to a file
            string filePath = $@"..\..\..\Save_Files\ZMS_{Name}_saveFile.json";

            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                streamWriter.Write(Save_Info);
                streamWriter.Close();
            }
            Console.WriteLine($"Game file saved at: {Path.GetFullPath(filePath)}");
        }
        catch (FormatException e)
        {
            Console.WriteLine(ErrorList.Error2());
            Console.ForegroundColor = ConsoleColor.Gray;
            Load_Save();
        }
        catch (Exception e)
        {
            Console.WriteLine(ErrorList.Error6());
            Console.WriteLine(e.Message);
            Console.ForegroundColor = ConsoleColor.Gray;
            Load_Save();
        }
    }

    public static void Load_Save()
    {
        try
        {
            string strDocPath = $@"..\..\..\Save_Files\";
            int docCount = Directory.GetFiles(strDocPath, "ZMS_*_saveFile.json",
            SearchOption.TopDirectoryOnly).Length;
            
            if (docCount == null || docCount == 0) // incase Save_file list is empty
            {
                Console.WriteLine(ErrorList.Error11());
                Console.ForegroundColor = ConsoleColor.Gray;
                Program.Main(null);
            }
            else
            {
                string[] files = Directory.GetFiles(strDocPath);
                Console.WriteLine("Select the Number with the save file you want to load.");
                try
                {
                    int i = 0; // instantiate i
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    foreach (string save_f in files) // loop through files list
                    {
                        Console.WriteLine($"{i}: {save_f}\n"); // display each list
                        i++;  // used for indexing and user choice
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString()); // if something goes wrong (which there shouldn't) throw Exception message
                }
                Console.WriteLine("Select number: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                string file_number = Console.ReadLine(); // enter file index, if value integer is checked later
                Console.ForegroundColor = ConsoleColor.Gray;
                Load_Save(file_number, files);
            }
        }
        catch (FormatException e)
        {
            Console.WriteLine(ErrorList.Error2());
            Console.ForegroundColor = ConsoleColor.Gray;
            Load_Save();
        }
        catch (Exception e)
        {
            Console.WriteLine(ErrorList.Error6());
            Console.WriteLine(e.Message);
            Console.ForegroundColor = ConsoleColor.Gray;
            Load_Save();
        }
    }
}
