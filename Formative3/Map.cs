// Represents a map where animals are placed on a grid
class Map
{
    // Displays the map with animals and handles exceptions
    public static void getMap(List<Animal> animals)
    {
        try
        {
            // Print a visual separator for clarity
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            // Create a 2D array to represent the map
            string[,] map = new string[20, 20];
            // Initialize the map with empty spaces
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = "[]";
                }
            }
            // change color for coordinates display
            Console.ForegroundColor = ConsoleColor.Green;
            // Place animals on the map
            foreach (var animal in animals)
            {
                // Get the coordinates of the animal's position
                int x = animal.AnimalPosition.X;
                int y = animal.AnimalPosition.Y;
                // Place the animal's name on the map
                map[y, x] = animal.getName();
                // Display the animal's position numerically
                Console.WriteLine($"{animal.getName()} is at Coordinates: {x}:{y}");
            }
            // Print the map to the console
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    bool animalFound = false;
                    foreach (var animal in animals)
                    {
                        if (map[i, j].ToString() == animal.getName())
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write(map[i, j] + "\t");
                            animalFound = true;
                            break; // Exit the loop if the animal is found
                        }
                    }
                    if (!animalFound)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write(map[i, j] + "\t");
                    }
                }
                Console.WriteLine();
            }
            // Print a visual separator for clarity
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }
        // Handle format exceptions
        catch (FormatException)
        {
            Console.WriteLine(ErrorList.Error1()); // throw error if something is wrong format
            Console.ForegroundColor = ConsoleColor.Gray;
            Program.Play(animals);
        }
        // Handle out of range exceptions
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine(ErrorList.Error4()); //throw error if out of range exception on map locations
            Console.ForegroundColor = ConsoleColor.Gray;
            Program.Play(animals); // go back to Main Menu
        }
        // Handle other exceptions
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.ForegroundColor = ConsoleColor.Gray;
            Program.Play(animals);
        }
    }
}
