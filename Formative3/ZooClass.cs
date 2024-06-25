using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

public class Zoo
{
    public string? Name { get; set; }
    public double? Cash { get; set; }
    public double? Bank { get; set; }
    public string[]? Inventory { get; set; }
    public string[]? Storage { get; set; }
    public int? AP { get; set; }
    public int? Customers { get; set; }
    public int? HL { get; set; }
    public List<Animal> Animals { get; set; }
    public Zoo(string Name, double Cash, double Bank, string[] Inventory, int AP, int Customers, string[] Storage, int HL, List<Animal> Animals)
    {
        this.Name = Name; // Name of zoo
        this.Cash = Cash; // Amount of useable cash
        this.Bank = Bank; // Amount of money stored in the bank
        this.Inventory = Inventory; // Inventory slots
        this.Customers = Customers; // Amount of Customers
        this.AP = AP; // Attraction Points
        this.HL = HL; // Happiness Level
        this.Storage = Storage; // Storage Slots
        this.Animals = Animals; // Animals in Zoo
    }

    [JsonConstructor]
    public Zoo(string Name, double Cash, double Bank, string[] Inventory, string[] Storage, int AP, int Customers, int HL, List<Animal> Animals)
    {
        this.Name = Name; // Name of zoo
        this.Cash = Cash; // Amount of useable cash
        this.Bank = Bank; // Amount of money stored in the bank
        this.Inventory = Inventory; // Inventory slots
        this.Storage = Storage; // Storage Slots
        this.AP = AP; // Attraction Points
        this.Customers = Customers; // Amount of Customers
        this.HL = HL; // Happiness Level
        this.Animals = Animals; // Animals in Zoo
    }
}
