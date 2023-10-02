using System.Drawing;
using Pastel;

namespace RPGspil;

public class Food : IItem
{
    public string Name { get; set; }
    public int Heeling { get; set; }
    
    public override string ToString()
    {
        return Name;
    }

    public void UseItem(Ib ib)
    {
        ib.health = ib.health + Heeling;
        Heeling = 0;
        ib.xp++;
        Console.WriteLine($"{"Dit health er nu på:".Pastel(Color.MediumSeaGreen)} {ib.health}");
    }
    
}