using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
// Main program
class Program
{ // ============================================= Main Method =============================================
    public static void Main(string[] args)
    {
        // Create a collection of animals at start of application
        List<Animal> animals = new List<Animal>();
        //Start Background Music
        Extras.Play_BG();
        Console.WriteLine("Welcome to Virtual Zoo Management!\n" +
            "1. Start new Game\n" +
            "2. Load Save\n");
        string choice = Console.ReadLine();
        if (choice == "1")
        {
            Mechanics.Create_Save(animals);
        } 
        else if (choice == "2")
        {

        }
        else
        {
            Console.WriteLine(ErrorList.Error6());
            Console.ForegroundColor = ConsoleColor.Gray;
            Main(args);
        }
        Console.ForegroundColor = ConsoleColor.Gray;
        // Go to Main Menu
        Play(animals);
    }
    // ============================================= Play Method =============================================
    //use another method to use the animals, to avoid recreating them over and over again.
    public static void Play(List<Animal> animals)
    {
        Console.ForegroundColor = ConsoleColor.Gray;// Ensure Gray colour
        Console.WriteLine($"-<========>- Welcome to ~'s Virtual Zoo~! -<========>-");
        Console.WriteLine("Please enter the number of your choice \n" +
            " 1. Add a new animal\n" +
            " 2. Remove an animal\n" +
            " 3. Use an animal\n" +
            " 4. Display all animals\n" +
            " 5. Display Zoo Map\n" +
            " 6. Check Stats\n" +
            " 7. Shop\n" +
            " \n" +
            " 88. Game Options\n" +
            " 99. Quit Game\n" +
            " Enter your choice: ");
        Console.ForegroundColor = ConsoleColor.Blue;
        string choice = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Gray;
        // ========== choice options ==========
        if (string.IsNullOrEmpty(choice)) // if choice is null or empty, throw an error
        {
            Console.WriteLine(ErrorList.Error3());
            Console.ForegroundColor = ConsoleColor.Gray;
            Play(animals);
        } // --------------------------------------- Add new animal ---------------------------------------
        else if (choice == "1") // if choice is 1, give prompt for animal type to add
        {
            Console.WriteLine("What kind of animal do you wish to add?\n" +
                " 1. Lion\n" +
                " 2. Vulture\n" +
                " 3. Zebra\n" +
                " 4. Rhinoceros\n" +
                " 5. Cheetah\n" +
                " 6. Wolf\n" +
                " 7. Baboon\n" +
                " 00. Go Back");
            Console.ForegroundColor = ConsoleColor.Blue;
            string choice_at_1 = Console.ReadLine();// read user input
            Console.ForegroundColor = ConsoleColor.Gray;
            if (choice_at_1 == "1")
            {
                Add_animal(animals, "Lion"); // add animal type Lion
                Play(animals); // go back to play
            }
            else if (choice_at_1 == "2")
            {
                Add_animal(animals, "Vulture"); // add animal type vulture
                Play(animals); // go back to play
            }
            else if (choice_at_1 == "3")
            {
                Add_animal(animals, "Zebra"); // add animal type zebra
                Play(animals); // go back to play
            }
            else if (choice_at_1 == "4")
            {
                Add_animal(animals, "Rhinoceros"); // add animal type rhinoceros
                Play(animals); // go back to play
            }
            else if (choice_at_1 == "5")
            {
                Add_animal(animals, "Cheetah"); // add animal type cheetah
                Play(animals); // go back to play
            }
            else if (choice_at_1 == "6")
            {
                Add_animal(animals, "Wolf"); // add animal type wolf
                Play(animals); // go back to play
            }
            else if (choice_at_1 == "7")
            {
                Add_animal(animals, "Baboon"); // add animal type baboon
                Play(animals); // go back to play
            }
            else if (choice_at_1 == "00")
            {
                Play(animals); // go back to play
            }
            else if (Check_Choice(choice_at_1) == false) // if the choice is not valid, throw an error
            {
                ErrorList.Error6();
                Console.ForegroundColor = ConsoleColor.Gray;
                Play(animals); // go back to play
            }
            else
            {
                Console.WriteLine(ErrorList.Error6());
                Console.ForegroundColor = ConsoleColor.Gray;
                Play(animals); // go back to play
            }
            Play(animals); // go back to play
        }// --------------------------------------- Remove animal ---------------------------------------
        else if (choice == "2")
        {
            Console.WriteLine("Which animal would you like to Delete?");
            if (animals == null || animals.Count == 0) // incase animals list is empty
            {
                Console.WriteLine(ErrorList.Error5());
                Console.ForegroundColor = ConsoleColor.Gray;
                Play(animals); // go back to play
            }
            else
            {
                try
                {
                    int i = 0; // instantiate i
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    foreach (Animal animal in animals) // loop through animals list
                    {
                        Console.WriteLine($"{i}: {animal.getName()} the {animal}\n"); // display each animal
                        i++; // used for indexing and user choice
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString()); // if something goes wrong (which there shouldn't) throw Exception message
                }
            }
            Console.WriteLine("Select number: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string animal_number = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Remove_animal(animals, animal_number);
            Play(animals); // go back to play
        } // --------------------------------------- Use an animal ---------------------------------------
        else if (choice == "3")
        {
            Console.WriteLine("Which animal would you like to use?");
            if (animals == null || animals.Count == 0) // incase animals list is empty
            {
                Console.WriteLine(ErrorList.Error5());
                Console.ForegroundColor = ConsoleColor.Gray;
                Play(animals); // go back to play
            }
            else
            {
                try
                {
                    int i = 0; // instantiate i
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    foreach (Animal animal in animals) // loop through animals list
                    {
                        Console.WriteLine($"{i}: {animal.getName()} the {animal}\n"); // display each animal
                        i++;  // used for indexing and user choice
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString()); // if something goes wrong (which there shouldn't) throw Exception message
                }
            }
            Console.WriteLine("Select number: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string animal_number = Console.ReadLine(); // enter animal index, if value integer is checked later
            Console.ForegroundColor = ConsoleColor.Gray;
            use_animal(animals, animal_number);
            Play(animals); // go back to play
        } // --------------------------------------- Display all animals ---------------------------------------
        else if (choice == "4")
        {
            DisplayAnimals(animals);
            Play(animals); // go back to play
        }// --------------------------------------- Display Zoo Map ---------------------------------------
        else if (choice == "5")
        {
            // get Map of current animal positions
            Map.getMap(animals);
            Play(animals); // go back to play
        }// --------------------------------------- Check Stats ---------------------------------------
        else if (choice == "6")
        {
            Mechanics.Check_Stats();
            Play(animals);
        }// --------------------------------------- Access Game Shop ---------------------------------------
        else if (choice == "7")
        {
            Shop.Access();
            Play(animals);
        }// --------------------------------------- Options ---------------------------------------
        else if (choice == "88")
        {
            Mechanics.Options();
            Play(animals);
        }
        // --------------------------------------- Quit program ---------------------------------------
        else if (choice == "99")
        {
            Extras.Stop_BG();
            Environment.Exit(0);
        } // --------------------------------------- if choice input not valid ---------------------------------------
        else if (Check_Choice(choice) == false)
        {
            Console.WriteLine(ErrorList.Error2());
            Console.ForegroundColor = ConsoleColor.Gray;
            Play(animals); // go back to play
        } // --------------------------------------- if input is not a valid option ---------------------------------------
        else if (Convert.ToInt32(choice) >= 5 && Convert.ToInt32(choice) < 99 || Convert.ToInt32(choice) > 99)
        {
            Console.WriteLine(ErrorList.Error6());
            Console.ForegroundColor = ConsoleColor.Gray;
            Play(animals); // go back to play
        } // --------------------------------------- if user input wrong data type/left empty ---------------------------------------
        else
        {
            Console.WriteLine(ErrorList.Error1());
            Console.ForegroundColor = ConsoleColor.Gray;
            Play(animals); // go back to play
        }
        // ============================================= Display all Animals =============================================
        static void DisplayAnimals(List<Animal> animals)
        {
            if (animals == null || animals.Count == 0)
            {
                Console.WriteLine(ErrorList.Error5());
                Console.ForegroundColor = ConsoleColor.Gray;
                Play(animals); // go back to play
            }
            else
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    foreach (Animal animal in animals) // loop through animals list for every animal in list
                    {
                        Console.WriteLine($"~~~~~~~~~~~~~~~~~~~~~~ \n" +
                            $"Type: {animal} \n" +
                            $"Name: {animal.getName()}\n" +
                            $"Age: {animal.getAge()}\n" +
                            $"Hunger: {animal.getHunger()}\n" +                  // Display all animal information
                            $"Health: {animal.getHealth()}\n" +
                            $"Cleanliness: {animal.getCleanliness()}\n" +
                            $"Fatigue: {animal.getFatigue()}\n" +
                            $" ~~~ Animal Needs ~~~\n" +
                            $"{animal.getName()} is a {animal.getAnimal_Type()}\n" +
                            $"{animal.getName()}'s diet: {animal.getDiet()}\n" +
                            $"{animal.getName()}'s natural habitat is: {animal.getHabitat_Type()}\n");
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString()); // if something bad happens, throw exception
                }
            }
        }
        // ============================================= Checking choice method =============================================
        static bool Check_Choice(string choice)
        {
            //for checking if choice is a number
            int i = 0;
            bool result = int.TryParse(choice, out i); // return true if choice is a number
            return result;
        }
        // ============================================= Use animal =============================================
        static void use_animal(List<Animal> animals, string animal_num_str)
        {
            try
            {   //choose animal from list
                int animal_num = Convert.ToInt32(animal_num_str);
                Animal current_animal = animals[animal_num]; // get user chosen animal
                if (current_animal == null)
                {
                    Console.WriteLine(ErrorList.Error4()); // if the animal is empty, throw error animal not found.
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Play(animals);
                }
                else
                {
                    Console.WriteLine($"What would you like to do with {current_animal.getName()}?\n" + // Give options to user for animal uses
                        $"1. Let {current_animal.getName()} eat\n" +
                        $"2. Feed {current_animal.getName()}.\n" +
                        $"3. Let {current_animal.getName()} sleep.\n" +
                        $"4. Make {current_animal.getName()} move.\n" +
                        $"5. Ask {current_animal.getName()} to speak.\n" +
                        $"6. Give {current_animal.getName()} a bath/shower\n" +
                        $"99. Go Back");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    int choice_at_2 = Convert.ToInt32(Console.ReadLine()); // user input
                    Console.ForegroundColor = ConsoleColor.Gray;
                    // --------------------------------------- Letting animal eat ---------------------------------------
                    if (choice_at_2 == 1)
                    {
                        if (current_animal.getHunger() <= 0)
                        {
                            Console.WriteLine(ErrorList.Error7()); // if animal is too full to eat more
                            Console.ForegroundColor = ConsoleColor.Gray;
                            use_animal(animals, animal_num_str); // go back to use animal choices
                        }
                        else
                        {
                            current_animal.Eat();
                            use_animal(animals, animal_num_str); // go back to use animal choices
                        }
                    } // --------------------------------------- feeding animal by hand ---------------------------------------
                    else if (choice_at_2 == 2)
                    {
                        if (current_animal.getHunger() <= 0)
                        {
                            Console.WriteLine(ErrorList.Error7()); // if animal is too full to eat more
                            Console.ForegroundColor = ConsoleColor.Gray;
                            use_animal(animals, animal_num_str); // go back to use animal choices
                        }
                        else
                        {
                            Console.WriteLine($"What food would you like to give {current_animal.getName()}?\n" + // give user food options
                                $"1. Nothing specific\n" +
                                $"2. Grass\n" +
                                $"3. Leaves\n" +
                                $"4. Fruits");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            int food_num = Convert.ToInt32(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Gray;

                            if (food_num == 1)
                            {
                                current_animal.Feed(); // call Feed method for animal
                                use_animal(animals, animal_num_str); // go back to use animal choices
                            }
                            else if (food_num == 2)
                            {
                                current_animal.Feed("Grass"); // call overloaded Feed method for animal
                                use_animal(animals, animal_num_str); // go back to use animal choices
                            }
                            else if (food_num == 3)
                            {
                                current_animal.Feed("Leaves"); // call overloaded Feed method for animal
                                use_animal(animals, animal_num_str); // go back to use animal choices
                            }
                            else if (food_num == 4)
                            {
                                current_animal.Feed("Fruits"); // call overloaded Feed method for animal
                                use_animal(animals, animal_num_str); // go back to use animal choices
                            }
                            else
                            {
                                Console.WriteLine(ErrorList.Error6());
                                Console.ForegroundColor = ConsoleColor.Gray;
                                use_animal(animals, animal_num_str); // go back to use animal choices
                            }
                        }
                    } // --------------------------------------- Letting animal sleep ---------------------------------------
                    else if (choice_at_2 == 3)
                    {
                        if (current_animal.getFatigue() <= 0) // if animal is not tired enough to sleep
                        {
                            Console.WriteLine(ErrorList.Error8());
                            Console.ForegroundColor = ConsoleColor.Gray;
                            use_animal(animals, animal_num_str); // go back to use animal choices
                        }
                        else
                        {
                            current_animal.Sleep(); // call animal sleep method
                            use_animal(animals, animal_num_str); // go back to use animal choices
                        }
                    } // --------------------------------------- animal movement ---------------------------------------
                    else if (choice_at_2 == 4)
                    {
                        if (current_animal.getFatigue() >= 100) // if animal is too tired to continue
                        {
                            Console.WriteLine(ErrorList.Error9());
                            Console.ForegroundColor = ConsoleColor.Gray;
                            use_animal(animals, animal_num_str); // go back to use animal choices
                        }
                        else
                        {
                            Console.WriteLine($"How would you like {current_animal.getName()} to move?\n" +
                                $"1. Move normally\n" +
                                $"2. Fly\n" +
                                $"3. Climb\n" +
                                $"4. Swim");
                            string move_choice = Console.ReadLine();
                            if (move_choice == null)
                            {
                                Console.WriteLine(ErrorList.Error3());
                                Console.ForegroundColor = ConsoleColor.Gray;
                            } else if (move_choice == "1")
                            {
                                current_animal.Move();
                                Random rnd = new Random();
                                int x = rnd.Next(20); // creates a number between 0 and 19
                                int y = rnd.Next(20); // creates a number between 0 and 19
                                current_animal.setXCoordinate(x);
                                current_animal.setYCoordinate(y);
                                use_animal(animals, animal_num_str); // go back to use animal choices
                            }
                            else if (move_choice == "2")
                            {
                                current_animal.Fly();
                                use_animal(animals, animal_num_str); // go back to use animal choices
                            }
                            else if (move_choice == "3")
                            {
                                current_animal.Climb();
                                use_animal(animals, animal_num_str); // go back to use animal choices
                            }
                            else if (move_choice == "4")
                            {
                                current_animal.Swim();
                                use_animal(animals, animal_num_str); // go back to use animal choices
                            }
                            else
                            {
                                Console.WriteLine(ErrorList.Error1());
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }
                            use_animal(animals, animal_num_str); // go back to use animal choices
                        }
                    } // --------------------------------------- animal makes a sound ---------------------------------------
                    else if (choice_at_2 == 5)
                    {
                        current_animal.Speak();
                        use_animal(animals, animal_num_str); // go back to use animal choices
                    } // --------------------------------------- Give animal bath ---------------------------------------
                    else if (choice_at_2 == 6)
                    {
                        if (current_animal.getCleanliness() >= 100) // if animal is already as clean as can be
                        {
                            Console.WriteLine(ErrorList.Error10());
                            Console.ForegroundColor = ConsoleColor.Gray;
                            use_animal(animals, animal_num_str); // go back to use animal choices
                        }
                        else
                        {
                            current_animal.Clean();
                            use_animal(animals, animal_num_str); // go back to use animal choices
                        }
                    } // --------------------------------------- Go back to play ---------------------------------------
                    else if (choice_at_2 == 99)
                    {
                        Play(animals);
                    } // --------------------------------------- if user input is wrong ---------------------------------------
                    else if (choice_at_2 >= 7 && choice_at_2 <= 98 || choice_at_2 >= 100)
                    {
                        Console.WriteLine(ErrorList.Error6());
                        Console.ForegroundColor = ConsoleColor.Gray;
                        use_animal(animals, animal_num_str); // go back to use animal choices
                    }
                    else
                    {
                        Console.WriteLine(ErrorList.Error6());
                        Console.ForegroundColor = ConsoleColor.Gray;
                        use_animal(animals, animal_num_str); // go back to use animal choices
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine(ErrorList.Error1()); // throw error if user enters wrong format
                Console.ForegroundColor = ConsoleColor.Gray;
                use_animal(animals, animal_num_str); // go back to use animal choices
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine(ErrorList.Error4()); //throw error if out of range exception
                Console.ForegroundColor = ConsoleColor.Gray;
                use_animal(animals, animal_num_str); // go back to use animal choices
            }
        }
        // ============================================= Add more animals =============================================
        static void Add_animal(List<Animal> animals, string animal_type)
        {
            try
            {
                // set default value for numeric animal values
                int an_default = 50;
                // user input for animal details and defaults declared
                Console.WriteLine($"Enter new {animal_type}'s name: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                string? name = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"Enter new {animal_type}'s age: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                int age = Convert.ToInt32(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Gray;
                int hunger = an_default;
                int health = an_default;
                int cleanliness = an_default;
                int fatigue = an_default;
                Random rnd = new Random();
                int x = rnd.Next(20); // creates a number between 0 and 19
                int y = rnd.Next(20); // creates a number between 0 and 19
                if (animal_type == "Lion") // Adding a new Lion animal
                {
                    animals.Add(new Lion(name, age, hunger, health, cleanliness, fatigue, "mammal", "carnivore", "savanna", x, y));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"New Lion {name} added Successfully!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Play(animals); // go back to play
                }
                else if (animal_type == "Vulture") // Adding a new Vulture animal
                {
                    animals.Add(new Vulture(name, age, hunger, health, cleanliness, fatigue, "bird", "carnivore", "desert", x, y));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"New Vulture {name} added Successfully!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Play(animals); // go back to play
                }
                else if (animal_type == "Zebra") // Adding a new Zebra animal
                {
                    animals.Add(new Zebra(name, age, hunger, health, cleanliness, fatigue, "mammal", "herbivore", "savanna", x, y));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"New Zebra {name} added Successfully!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Play(animals); // go back to play
                }
                else if (animal_type == "Rhinoceros") // Adding a new Rhinoceros animal
                {
                    animals.Add(new Rhinoceros(name, age, hunger, health, cleanliness, fatigue, "mammal", "herbivore", "savanna", x, y));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"New Rhinoceros {name} added Successfully!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Play(animals); // go back to play
                }
                else if (animal_type == "Cheetah") // Adding a new Cheetah animal
                {
                    animals.Add(new Cheetah(name, age, hunger, health, cleanliness, fatigue, "mammal", "carnivore", "savanna", x, y));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"New Cheetah {name} added Successfully!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Play(animals); // go back to play
                }
                else if (animal_type == "Wolf") // Adding a new Wolf animal
                {
                    animals.Add(new Wolf(name, age, hunger, health, cleanliness, fatigue, "mammal", "carnivore", "forest", x, y));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"New Wolf {name} added Successfully!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Play(animals); // go back to play
                }
                else if (animal_type == "Baboon") // Adding a new Baboon animal
                {
                    animals.Add(new Baboon(name, age, hunger, health, cleanliness, fatigue, "mammal", "omnivore", "jungle", x, y));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"New Baboon {name} added Successfully!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Play(animals); // go back to play
                }
            }
            catch (FormatException) // if user input in wrong format
            {
                Console.WriteLine(ErrorList.Error2());
                Console.ForegroundColor = ConsoleColor.Gray;
                Play(animals); // go back to play
            }
            catch (Exception e) // catch outstanding errors (which there shouldn't be)
            {
                Console.WriteLine($"{e.Message}");
                Play(animals); // go back to play
            }
        }
        // ============================================= Remove an animal =============================================
        static void Remove_animal(List<Animal> animals, string animal_num_str)
        {
            try
            {   //choose animal from list
                int animal_num = Convert.ToInt32(animal_num_str);
                Animal current_animal = animals[animal_num]; // get user chosen animal from animals list
                if (current_animal == null)
                {
                    Console.WriteLine(ErrorList.Error4());
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Play(animals); // go back to play
                }
                else
                {
                    Console.WriteLine($"Are you sure you want to delete {current_animal.getName()} the {current_animal}?\n" +
                        $"1. Yes\n" +
                        $"2. No");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    int choice_at_3 = Convert.ToInt32(Console.ReadLine()); // user input for choices
                    Console.ForegroundColor = ConsoleColor.Gray;
                    if (choice_at_3 == 1) // user is sure they want to delete animal
                    {
                        animals.Remove(animals[animal_num]);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"Animal {current_animal} removed successfully!"); // if animal was removed
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (choice_at_3 == 2) // user decides to give mercy to the poor animals soul
                    {
                        Play(animals); // go back to play
                    }
                    else
                    {
                        Console.WriteLine(ErrorList.Error6());
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Remove_animal(animals, animal_num_str);
                    }
                }
            }
            catch (FormatException) // if user input is in wrong format
            {
                Console.WriteLine(ErrorList.Error1());
                Console.ForegroundColor = ConsoleColor.Gray;
                Play(animals);
            }
            catch (ArgumentOutOfRangeException) // if out of range exception happens
            {
                Console.WriteLine(ErrorList.Error4());
                Console.ForegroundColor = ConsoleColor.Gray;
                Play(animals);
            }
        }
    }
}
// ============================================= Custom Error messages =============================================
public class ErrorList()
{
    public static string Error1() // Error if user inputs anything other than a number
    {
        Console.ForegroundColor = ConsoleColor.Red;
        return "ERROR 101: Please enter a number in this field";
    }
    public static string Error2() // Error if user inputs in wrong format
    {
        Console.ForegroundColor = ConsoleColor.Red;
        return "ERROR 202: Wrong value type for this field, please try again";
    }
    public static string Error3() // Error if user doesn't input anything
    {
        Console.ForegroundColor = ConsoleColor.Red;
        return "ERROR 303: Please do not leave this field empty, enter something.";
    }
    public static string Error4() // Error if animal isn't found
    {
        Console.ForegroundColor = ConsoleColor.Red;
        return "ERROR 404: Animal not found!";
    }
    public static string Error5() // Error if no animals have been created
    {
        Console.ForegroundColor = ConsoleColor.Red;
        return "ERROR 505: Currently no animals in the Zoo, please add more.";
    }
    public static string Error6() // If index out of range etc.
    {
        Console.ForegroundColor = ConsoleColor.Red;
        return "ERROR 606: Please enter a valid option.";
    }
    public static string Error7() // Animal can't eat
    {
        Console.ForegroundColor = ConsoleColor.Red;
        return "ERROR 707: Animal cannot eat more, Ask it to run around so it can become hungrier.";
    }
    public static string Error8() // Animal can't sleep
    {
        Console.ForegroundColor = ConsoleColor.Red;
        return "ERROR 808: Animal cannot sleep anymore, Ask it to run around so it can become tired.";
    }
    public static string Error9() // Animal can't run
    {
        Console.ForegroundColor = ConsoleColor.Red;
        return "ERROR 909: Animal cannot run anymore, Ask it to sleep, so it can be less fatigued.";
    }
    public static string Error10() // Animal can't be cleaned
    {
        Console.ForegroundColor = ConsoleColor.Red;
        return "ERROR 1010: Animal cannot be cleaned more, use other features for it to become dirty again.";
    }
}