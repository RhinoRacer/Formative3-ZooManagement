using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;
// Formative 3 -- additions ===================================================
// enums
public enum AnimalType // enum for Animal Type
{
    mammal, bird, reptile, amphibian, not_specified
};
public enum FoodType // enum for food type
{
    Carnivore, Herbivore, Omnivore, not_specified
};
public enum HabitatType // enum for habitat type
{
    desert, forest, aquatic, jungle, savanna, not_specified
};
public struct DietInfo //struct for dietinfo
{
    public List<string> FeedingSchedule { get; set; } // array to store animals feeding schedule
    public double? Quantity { get; set; }
    private FoodType FoodType { get; set; }
    public DietInfo(string foodTypeStr)
    {
        FeedingSchedule = new List<string>();
        Quantity = null;

        switch (foodTypeStr.ToLower())
        {
            case "carnivore": // feeding schedule for carnivore
                FoodType = FoodType.Carnivore;
                FeedingSchedule.Add("Raw Steak");
                FeedingSchedule.Add("Raw Beef");
                break;
            case "herbivore": // feeding schedule for herbivore
                FoodType = FoodType.Herbivore;
                FeedingSchedule.Add("Grass");
                FeedingSchedule.Add("Fruits");
                break;
            case "omnivore": // feeding schedule for omnivore
                FoodType = FoodType.Omnivore;
                FeedingSchedule.Add("Fruits");
                FeedingSchedule.Add("Insects");
                break;
            default: // if food_type not specified
                FoodType = FoodType.not_specified;
                break;
        }
    }
    public string getFeedingSchedule() // get feeding schedule function
    {
        return string.Join(", ", FeedingSchedule);
    }
}
public class Position // class to get Animal position on map.
{
    public int X { get; set; } // X coordinate
    public int Y { get; set; } // Y coordinate
    public Position(int x, int y) // Constructor
    {
        X = x;
        Y = y;
    }
}
// Formative 3 -- additions ===================================================

// ============================================= Animal base class =============================================
public abstract class Animal : IComparable
{ // Creating base animal values
    public string? Name { get; set; }
    //private string? _name { get => Name; set => Name = value; } // I HAVE to use 2 properties, or else I get a stack Overflow error when creating a new animal.
    public int Age{ get; set; }
    //private int _age { get => Age; set => Age = value; } // the _[propertyName] is the get set for the actually used private [propertyName]
    public int Hunger { get; set; }
    //private int _hunger { get => Hunger; set => Hunger = value; }
    public int Health { get; set; }
    //private int _health { get => Health; set => Health = value; }
    public int Cleanliness { get; set; }
    //private int _cleanliness { get => Cleanliness; set => Cleanliness = value; }
    public int Fatigue { get; set; }
    //private int _fatigue { get => Fatigue; set => Fatigue = value; }
    public AnimalType Animal_Type { get; set; }
    //private AnimalType _animaltype { get => Animal_Type; set => Animal_Type = value; } // add property animal type enum
    public FoodType Food_Type { get; set; }
    //private FoodType _foodtype { get => Food_Type; set => Food_Type = value; } // add property food type enum
    public HabitatType Habitat_Type { get; set; }
    //private HabitatType _habitattype { get => Habitat_Type; set => Habitat_Type = value; } // add property habitat type enum
    public DietInfo Diet { get; set; } // add DietInfo property
    public Position AnimalPosition { get; set; } // add Position property

    [JsonConstructor]
    public Animal(string? Name, int Age, int Hunger, int Health, int Cleanliness, int Fatigue, int Animal_Type, int Food_Type, int Habitat_Type, int X, int Y) // constructor
    { // Constructor for base Animal class
        this.Name = Name;
        this.Age = Age;
        this.Hunger = Hunger;
        this.Health = Health;
        this.Cleanliness = Cleanliness;
        this.Fatigue = Fatigue;
        AnimalPosition = new Position(X, Y);
        // =---------- AnimalType ----------=
        if (Animal_Type.Equals(0))
        {
            this.Animal_Type = AnimalType.mammal; // sets the animal type based on the input from the contructor
        }
        else if (Animal_Type.Equals(1))
        {
            this.Animal_Type = AnimalType.bird;
        }
        else if (Animal_Type.Equals(2))
        {
            this.Animal_Type = AnimalType.reptile;
        }
        else if (Animal_Type.Equals(3))
        {
            this.Animal_Type = AnimalType.amphibian;
        }
        else
        {
            this.Animal_Type = AnimalType.not_specified;
        }
        // =---------- FoodType ----------=
        if (Food_Type.Equals(0))
        {
            this.Food_Type = FoodType.Carnivore; // sets the Food type based on the input from the contructor
        }
        else if (Food_Type.Equals(1))
        {
            this.Food_Type = FoodType.Herbivore;
        }
        else if (Food_Type.Equals(2))
        {
            this.Food_Type = FoodType.Omnivore;
        }
        else
        {
            this.Food_Type = FoodType.not_specified;
        }
        // =---------- HabitatType ----------=
        if (Habitat_Type.Equals(0))
        {
            this.Habitat_Type = HabitatType.desert; // sets the Habitat type based on the input from the contructor
        }
        else if (Habitat_Type.Equals(1))
        {
            this.Habitat_Type = HabitatType.forest;
        }
        else if (Habitat_Type.Equals(2))
        {
            this.Habitat_Type = HabitatType.aquatic;
        }
        else if (Habitat_Type.Equals(3))
        {
            this.Habitat_Type = HabitatType.jungle;
        }
        else if (Habitat_Type.Equals(4))
        {
            this.Habitat_Type = HabitatType.savanna;
        }
        else
        {
            this.Habitat_Type = HabitatType.not_specified;
        }
        // =-------------- Setting the instance diet ----------=
        setDiet();
    }

    public Animal(string? Name, int Age, int Hunger, int Health, int Cleanliness, int Fatigue, string Animal_Type, string Food_Type, string Habitat_Type, int X, int Y) // constructor
    { // Constructor for base Animal class
        this.Name = Name;
        this.Age = Age;
        this.Hunger = Hunger;
        this.Health = Health;
        this.Cleanliness = Cleanliness;
        this.Fatigue = Fatigue;
        AnimalPosition = new Position(X, Y);
        // =---------- AnimalType ----------=
        if (Animal_Type.ToLower() == "mammal")
        {
            this.Animal_Type = AnimalType.mammal; // sets the animal type based on the input from the contructor
        }
        else if (Animal_Type.ToLower() == "bird")
        {
            this.Animal_Type = AnimalType.bird;
        }
        else if (Animal_Type.ToLower() == "reptile")
        {
            this.Animal_Type = AnimalType.reptile;
        }
        else if (Animal_Type.ToLower() == "amphibian")
        {
            this.Animal_Type = AnimalType.amphibian;
        }
        else
        {
            this.Animal_Type = AnimalType.not_specified;
        }
        // =---------- FoodType ----------=
        if (Food_Type.ToLower() == "carnivore")
        {
            this.Food_Type = FoodType.Carnivore; // sets the Food type based on the input from the contructor
        }
        else if (Food_Type.ToLower() == "herbivore")
        {
            this.Food_Type = FoodType.Herbivore;
        }
        else if (Food_Type.ToLower() == "omnivore")
        {
            this.Food_Type = FoodType.Omnivore;
        }
        else
        {
            this.Food_Type = FoodType.not_specified;
        }
        // =---------- HabitatType ----------=
        if (Habitat_Type.ToLower() == "desert")
        {
            this.Habitat_Type = HabitatType.desert; // sets the Habitat type based on the input from the contructor
        }
        else if (Habitat_Type.ToLower() == "forest")
        {
            this.Habitat_Type = HabitatType.forest;
        }
        else if (Habitat_Type.ToLower() == "aquatic")
        {
            this.Habitat_Type = HabitatType.aquatic;
        }
        else if (Habitat_Type.ToLower() == "jungle")
        {
            this.Habitat_Type = HabitatType.jungle;
        }
        else if (Habitat_Type.ToLower() == "savanna")
        {
            this.Habitat_Type = HabitatType.savanna;
        }
        else
        {
            this.Habitat_Type = HabitatType.not_specified;
        }
        // =-------------- Setting the instance diet ----------=
        setDiet();
    }
    // Formative 3 -- additions ===================================================
    public string getName() // get name function to access private variable Name
    {
        return this.Name;
    }
    public int getAge() // get the Animal age
    {
        return this.Age;
    }
    public int getHunger() // get the Animal Hunger
    {
        return this.Hunger;
    }
    public int getHealth() // get the Animal Health
    {
        return this.Health;
    }
    public int getCleanliness() // get the Animal Cleanliness
    {
        return this.Cleanliness;
    }
    public int getFatigue() // get the Animal Fatigue
    {
        return this.Fatigue;
    }
    // ---------- FA3 ----------
    public string getAnimal_Type() // get the Animal type
    {
        return this.Animal_Type.ToString();
    }
    public string getFood_Type() // get the food type
    {
        return this.Food_Type.ToString();
    }
    public string getHabitat_Type() // get the Habitat type
    {
        return this.Habitat_Type.ToString();
    }
    public string getDiet() // get the feeding schedule/diet
    {
        return this.Diet.getFeedingSchedule();
    }
    public int getXCoordinate() // get the X coordinate on map
    {
        return AnimalPosition.X;
    }
    public int getYCoordinate() // get the Y coordinate on map
    {
        return AnimalPosition.Y;
    }
    // setters
    public void setXCoordinate(int x) // set the X coordinate on map
    {
        AnimalPosition.X = x;
    }
    public void setYCoordinate(int y) // set the Y coordinate on map
    {
        AnimalPosition.Y = y;
    }
    public void setDiet()
    {
        // ==================== Diet Info ====================
        if (Food_Type == FoodType.Carnivore)
        {
            Diet = new DietInfo("Carnivore"); // Initialize DietInfo
        }
        else if (Food_Type == FoodType.Herbivore)
        {
            Diet = new DietInfo("Herbivore"); // Initialize DietInfo
        }
        else if (Food_Type == FoodType.Omnivore)
        {
            Diet = new DietInfo("Omnivore"); // Initialize DietInfo
        }
        else if (Food_Type == FoodType.not_specified)
        {
            Diet = new DietInfo(); // Initialize DietInfo
        }
    } // ---------- FA3 ----------
    // property set methods
    public void setName(string name) // set the Name of the Animal
    {
        this.Name = name;
    }
    public void setAge(int age) // set the Age of the Animal
    {
        this.Age = age;
    }
    public void setHunger(int hunger) // set the Hunger of the Animal
    {
        this.Hunger = hunger;
    }
    public void setHealth(int health) // set the Health of the Animal
    {
        this.Health = health;
    }
    public void setCleanliness(int cleanliness) // set the Cleanliness of the Animal
    {
        this.Cleanliness = cleanliness;
    }
    public void setFatigue(int fatigue) // set the Fatigue of the Animal
    {
        this.Fatigue = fatigue;
    }
    public void setAnimal_Type(string animal_type) // set the Type of the Animal
    {
        if (animal_type.ToLower() == "mammal")
        {
            this.Animal_Type = AnimalType.mammal;
        }
        else if (animal_type.ToLower() == "bird")
        {
            this.Animal_Type = AnimalType.bird;
        }
        else if (animal_type.ToLower() == "reptile")
        {
            this.Animal_Type = AnimalType.reptile;
        }
        else if (animal_type.ToLower() == "amphibian")
        {
            this.Animal_Type = AnimalType.amphibian;
        }
        else
        {
            this.Animal_Type = AnimalType.not_specified;
        }
    }
    public abstract void Swim(); // Abstract method for swim
    public abstract void Climb(); // Abstract method for climb
    public abstract void Fly(); // Abstract method for fly
    // Formative 3 -- additions ===================================================
    public virtual void Eat() // virtual Method for Eat
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Animal decides to not eat.");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public virtual void Sleep() // virtual Method for Sleep
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Animal is not sleepable.");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public virtual void Move() // virtual Method for Move
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Animal is not Moveable, but is disgusted that you ask it to, and runs away from you.");
        this.Health += 1;
        this.Fatigue += 2;
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public virtual void Speak() // virtual Method for Speak
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Animal is not speakable.");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    // Overloading Methods
    public virtual void Feed() // Overloading virtual Method for Feed
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Animal is not Feedable.");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public virtual void Feed(string food) // Overloading virtual Method for Feed
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Animal is not feedable and cannot enjoy {food}.");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    // back to normal method
    public virtual void Clean() // virtual Method for Clean
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Animal is not Cleanable and cannot be washed.");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public int CompareTo(object? obj)
    {
        throw new NotImplementedException();
    }
}
// ============================================= Specific animal classes ============================================= 
// ----- Lion -----
public class Lion : Animal, IMovable, ISleepable, ISpeakable, ICleanable, ISwimmable
{   // constructor
    public Lion(string? Name, int Age, int Hunger, int Health, int Cleanliness, int Fatigue, string Animal_Type, string Food_Type, string Habitat_Type, int X, int Y) : base(Name, Age, Hunger, Health, Cleanliness, Fatigue, Animal_Type, Food_Type, Habitat_Type, X, Y) { }
    // override methods for Lion type
    public override void Eat() // Overriding Method for Eat
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Lion is eating meat.");
        this.setHunger(getHunger() - 5);
        this.setHealth(getHealth() + 2);
        this.setCleanliness(getCleanliness() - 1);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Sleep() // Overriding Method for Sleep
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Lion is sleeping under a tree.");
        this.setFatigue(getFatigue() - 10);
        this.setHealth(getHealth() + 2);
        this.setCleanliness(getCleanliness() - 1);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Move() // Overriding Method for Move
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Lion is running.");
        this.setHunger(getHunger() + 5);
        this.setHealth(getHealth() + 1);
        this.setFatigue(getFatigue() + 2);
        this.setCleanliness(getCleanliness() -3);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Speak() // Overriding Method for Speak
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Roar!");
        this.setHunger(getHunger() + 1);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Clean() // Overriding Method for Clean
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("You Clean the Lion using a hosepipe from far away, its not very effective.");
        this.setCleanliness(getCleanliness() + 5);
        this.setHealth(getHealth() + 1);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Swim() // Overriding method for the Abstract Method Swim
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Lion takes a dip in the water, and goes back to where it was before.");
        this.setHunger(getHunger() + 5);
        this.setHealth(getHealth() + 1);
        this.setFatigue(getFatigue() + 2);
        this.setCleanliness(getCleanliness() - 3);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Climb() // Overriding method for the Abstract Method Climb
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Animal Can not Climb.");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Fly() // Overriding method for the Abstract Method Fly
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Animal Can not Fly.");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}
// ----- Vulture -----
public class Vulture : Animal, ISleepable, ISpeakable, IMovable, ICleanable, IFlyable
{   // constructor
    public Vulture(string? Name, int Age, int Hunger, int Health, int Cleanliness, int Fatigue, string Animal_Type, string Food_Type, string Habitat_Type, int X, int Y) : base(Name, Age, Hunger, Health, Cleanliness, Fatigue, Animal_Type, Food_Type, Habitat_Type, X, Y) { }

    public override void Eat() // Overriding Method for Eat
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Vulture is picking meat from bones.");
        this.setHunger(getHunger() - 5);
        this.setHealth(getHealth() + 2);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Sleep() // Overriding Method for Sleep
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Vulture is sleeping on a perch.");
        this.setFatigue(getFatigue() - 10);
        this.setHealth(getHealth() + 2);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Move() // Overriding Method for Move
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Vulture is flying.");
        this.setHunger(getHunger() + 1);
        this.setHealth(getHealth() + 1);
        this.setFatigue(getFatigue() + 2);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Speak() // Overriding Method for Speak
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Squawk!");
        this.setHunger(getHunger() + 1);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Clean() // Overriding Method for Clean
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("You Clean the Vulture carefully while wearing protective suit, its fairly effective.");
        this.setCleanliness(getCleanliness() + 10);
        this.setHealth(getHealth() + 2);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Fly() // Overriding method for the Abstract Method Fly
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Vulture goes high up into the, and goes back to where it was before.");
        this.setHunger(getHunger() + 1);
        this.setHealth(getHealth() + 1);
        this.setFatigue(getFatigue() + 2);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Swim() // Overriding method for the Abstract Method Swim
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Animal Can not Swim.");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Climb() // Overriding method for the Abstract Method Climb
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Animal Can not Climb.");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}
// ----- Zebra -----
public class Zebra : Animal, IFeedable, ISleepable, ISpeakable, IMovable, ICleanable
{   // constructor
    public Zebra(string? Name, int Age, int Hunger, int Health, int Cleanliness, int Fatigue, string Animal_Type, string Food_Type, string Habitat_Type, int X, int Y) : base(Name, Age, Hunger, Health, Cleanliness, Fatigue, Animal_Type, Food_Type, Habitat_Type, X, Y) { }

    public override void Eat() // Overriding Method for Eat
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Zebra is eating grass.");
        this.setHunger(getHunger() - 5);
        this.setHealth(getHealth() + 2);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Sleep() // Overriding Method for Sleep
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Zebra is sleeping near the water.");
        this.setFatigue(getFatigue() - 10);
        this.setHealth(getHealth() + 2);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Move() // Overriding Method for Move
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Zebra runs around.");
        this.setHunger(getHunger() + 1);
        this.setHealth(getHealth() + 1);
        this.setFatigue(getFatigue() + 2);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Speak() // Overriding Method for Speak
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Zebra makes a loud sound.");
        this.setHunger(getHunger() + 1);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Feed() // Overloading Method for Feed
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Zebra enjoys grass.");
        Console.ForegroundColor = ConsoleColor.Gray;
        this.setHunger(getHunger() - 5);
        this.setHealth(getHealth() + 3);
    }
    public override void Feed(string food) // Overloading Method for Feed
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Zebra enjoys the {food}.");
        Console.ForegroundColor = ConsoleColor.Gray;
        this.setHunger(getHunger() - 7);
        this.setHealth(getHealth() + 5);
    }
    public override void Clean() // Overriding Method for Clean
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("You Clean the Zebra with a brush, its very effective.");
        this.setCleanliness(getCleanliness() + 20);
        this.setHealth(getHealth() + 8);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Swim() // Overriding method for the Abstract Method Swim
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Animal Can not Swim.");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Climb() // Overriding method for the Abstract Method Climb
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Animal Can not Climb.");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Fly() // Overriding method for the Abstract Method Fly
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Animal Can not Fly.");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}
// ----- Rhinoceros -----
public class Rhinoceros : Animal, IFeedable, ISleepable, ISpeakable, IMovable, ICleanable
{   // constructor
    public Rhinoceros(string? Name, int Age, int Hunger, int Health, int Cleanliness, int Fatigue, string Animal_Type, string Food_Type, string Habitat_Type, int X, int Y) : base(Name, Age, Hunger, Health, Cleanliness, Fatigue, Animal_Type, Food_Type, Habitat_Type, X, Y) { }
    public override void Eat() // Overriding Method for Eat
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Rhinoceros is eating grass.");
        this.setHunger(getHunger() - 5);
        this.setHealth(getHealth() + 2);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Sleep() // Overriding Method for Sleep
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Rhinoceros is sleeping under a tree.");
        this.setFatigue(getFatigue() - 10);
        this.setHealth(getHealth() + 2);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Move() // Overriding Method for Move
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Rhinoceros runs around.");
        this.setHunger(getHunger() + 1);
        this.setHealth(getHealth() + 1);
        this.setFatigue(getFatigue() + 2);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Speak() // Overriding Method for Speak
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Rhinoceros makes a grunting noise.");
        this.setHunger(getHunger() + 1);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Feed() // Overloading Method for Feed
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Rhinoceros enjoys the leaves.");
        Console.ForegroundColor = ConsoleColor.Gray;
        this.setHunger(getHunger() - 5);
        this.setHealth(getHealth() + 3);
    }
    public override void Feed(string food) // Overloading Method for Feed
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Rhinoceros enjoys the {food}.");
        Console.ForegroundColor = ConsoleColor.Gray;
        this.setHunger(getHunger() - 7);
        this.setHealth(getHealth() + 5);
    }
    public override void Clean() // Overriding Method for Clean
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("You Clean the Rhinoceros with a brush, its very effective.");
        this.setCleanliness(getCleanliness() + 20);
        this.setHealth(getHealth() + 8);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Swim() // Overriding method for the Abstract Method Swim
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Animal Can not Swim.");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Climb() // Overriding method for the Abstract Method Climb
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Animal Can not Climb.");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Fly() // Overriding method for the Abstract Method Fly
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Animal Can not Fly.");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}
// ----- Cheetah -----
public class Cheetah : Animal, ISleepable, ISpeakable, IMovable, ICleanable, ISwimmable
{   // constructor
    public Cheetah(string? Name, int Age, int Hunger, int Health, int Cleanliness, int Fatigue, string Animal_Type, string Food_Type, string Habitat_Type, int X, int Y) : base(Name, Age, Hunger, Health, Cleanliness, Fatigue, Animal_Type, Food_Type, Habitat_Type, X, Y) { }
    public override void Eat() // Overriding Method for Eat
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Cheetah is eating meat.");
        this.setHunger(getHunger() - 5);
        this.setHealth(getHealth() + 2);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Sleep() // Overriding Method for Sleep
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Cheetah is sleeping on top of a tree.");
        this.setFatigue(getFatigue() - 10);
        this.setHealth(getHealth() + 2);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Move() // Overriding Method for Move
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Cheetah runs 700 meters in 10 seconds.");
        this.setHunger(getHunger() + 1);
        this.setHealth(getHealth() + 1);
        this.setFatigue(getFatigue() + 2);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Speak() // Overriding Method for Speak
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Cheetah growls and grunts.");
        this.setHunger(getHunger() + 1);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Clean() // Overriding Method for Clean
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("You Clean the Cheetah wit a hosepipe from far away, its not very effective.");
        this.setCleanliness(getCleanliness() + 5);
        this.setHealth(getHealth() + 1);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Swim() // Overriding method for the Abstract Method Swim
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Cheetah swims around the lake.");
        this.setHunger(getHunger() + 1);
        this.setHealth(getHealth() + 1);
        this.setFatigue(getFatigue() + 2);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Climb() // Overriding method for the Abstract Method Climb
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Animal Can not Climb.");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Fly() // Overriding method for the Abstract Method Fly
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Animal Can not Fly.");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}
// ----- Wolf -----
public class Wolf : Animal, IFeedable, ISleepable, ISpeakable, ICleanable, ISwimmable
{   // constructor
    public Wolf(string? Name, int Age, int Hunger, int Health, int Cleanliness, int Fatigue, string Animal_Type, string Food_Type, string Habitat_Type, int X, int Y) : base(Name, Age, Hunger, Health, Cleanliness, Fatigue, Animal_Type, Food_Type, Habitat_Type, X, Y) { }
    public override void Eat() // Overriding Method for Eat
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Wolf is eating meat.");
        this.setHunger(getHunger() - 5);
        this.setHealth(getHealth() + 2);
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    public override void Sleep() // Overriding Method for Sleep
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Wolf sleeps in its cave.");
        this.setFatigue(getFatigue() - 10);
        this.setHealth(getHealth() + 2);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Speak() // Overriding Method for Speak
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Wolf howls.");
        this.setHunger(getHunger() + 1);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Feed()  // Overloading Method for Feed
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Wolf enjoys some meat.");
        Console.ForegroundColor = ConsoleColor.Gray;
        this.setHunger(getHunger() - 5);
        this.setHealth(getHealth() + 3);
    }
    public override void Feed(string food) // Overloading Method for Feed
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Wolf enjoys some {food}.");
        Console.ForegroundColor = ConsoleColor.Gray;
        this.setHunger(getHunger() - 5);
        this.setHealth(getHealth() + 4);
    }
    public override void Clean() // Overriding Method for Clean
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("You Clean the Wolf with a brush, its very effective.");
        this.setCleanliness(getCleanliness() + 20);
        this.setHealth(getHealth() + 8);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Swim() // Overriding method for the Abstract Method Swim
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Wolf swims around the lake, and goes back to where it was before.");
        this.setHunger(getHunger() + 1);
        this.setHealth(getHealth() + 1);
        this.setFatigue(getFatigue() + 2);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Climb() // Overriding method for the Abstract Method Climb
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Animal Can not Climb.");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Fly() // Overriding method for the Abstract Method Fly
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Animal Can not Fly.");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}
// ----- Baboon -----
public class Baboon : Animal, ISleepable, ISpeakable, IMovable, ICleanable, IClimbable, ISwimmable
{   // constructor
    public Baboon(string? Name, int Age, int Hunger, int Health, int Cleanliness, int Fatigue, string Animal_Type, string Food_Type, string Habitat_Type, int X, int Y) : base(Name, Age, Hunger, Health, Cleanliness, Fatigue, Animal_Type, Food_Type, Habitat_Type, X, Y) { }
    public override void Eat() // Overriding Method for Eat
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Baboon is eating fruit.");
        this.setHunger(getHunger() - 5);
        this.setHealth(getHealth() + 2);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Sleep()// Overriding Method for Sleep
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Baboon sleeps in its tree.");
        this.setFatigue(getFatigue() - 10);
        this.setHealth(getHealth() + 2);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Move() // Overriding Method for Move
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Baboon climbs trees and jumps up and down.");
        this.setHunger(getHunger() + 1);
        this.setHealth(getHealth() + 1);
        this.setFatigue(getFatigue() + 2);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Speak() // Overriding Method for Speak
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Baboon barks and throws a banana.");
        this.setHunger(getHunger() + 1);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Clean() // Overriding Method for Clean
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("You Clean the Baboon carefully while wearing a protective suit, its kind of effective.");
        this.setCleanliness(getCleanliness() + 10);
        this.setHealth(getHealth() + 5);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Swim() // Overriding method for the Abstract Method Swim
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Baboon swims around the lake, and goes back to where it was before.");
        this.setHunger(getHunger() + 1);
        this.setHealth(getHealth() + 1);
        this.setFatigue(getFatigue() + 2);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Climb() // Overriding method for the Abstract Method Climb
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Baboon climbs around in the trees, and goes back to where it was before.");
        this.setHunger(getHunger() + 1);
        this.setHealth(getHealth() + 1);
        this.setFatigue(getFatigue() + 2);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    public override void Fly() // Overriding method for the Abstract Method Fly
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Animal Can not Fly.");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}

// ============================================= Interface for feedable animals ============================================= 
public interface IFeedable
{
    void Feed(); // Overloading methods
    void Feed(string food);
}

// ============================================= Interface for movable animals ============================================= 
public interface IMovable
{
    void Move(); // Overriding Methods
}
// ============================================= Interface for speakable animals ============================================= 
public interface ISpeakable
{
    void Speak(); // void method for Speak
}

// ============================================= Interface for sleepable animals ============================================= 
public interface ISleepable
{
    void Sleep(); // void method for Sleep
}
// ============================================= Interface for Cleanable animals =============================================
public interface ICleanable
{
    void Clean(); // void method for Clean
}
// --------------------------- FORMATIVE 3 ---------------------------
// ============================================= Interface for Climbable animals =============================================
public interface IClimbable
{
    abstract void Climb(); // void method for Climb
}
// ============================================= Interface for Swimmable animals =============================================
public interface ISwimmable
{
    abstract void Swim(); // void method for Swim
}
// ============================================= Interface for Flyable animals =============================================
public interface IFlyable
{
    abstract void Fly(); // void method for Fly
}