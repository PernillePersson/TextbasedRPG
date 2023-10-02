using System.Drawing;
using Pastel;

namespace RPGspil;

public class Ib
{
    public int health { get; set; }
    public int level { get; set; }
    public int xp { get; set; }
    public Inventory _inventory { get; set; }

    public Ib(Inventory inventory)
    {
        health = 100;
        level = 1;
        xp = 0;
        _inventory = inventory;
    }
    

    public string getStats()
    {
        return $"{"Health".Pastel(ConsoleColor.Red)}: {health} {"Level".Pastel(Color.LightSkyBlue)}: {level} {"XP".Pastel(Color.LightGreen)}: {xp}";
    }
    
}