using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public Zoo(string name, double cash, double bank, string[] inventory, int AttractionPoints, int customers, int HappinessLevel, string[] storage)
    {
        Name = name;
        Cash = cash;
        Bank = bank;
        Inventory = inventory;
        Customers = customers;
        AP = AttractionPoints;
        HL = HappinessLevel;
        Storage = storage;

    }
}
