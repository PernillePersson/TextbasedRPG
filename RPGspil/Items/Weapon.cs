using Pastel;

namespace RPGspil;

public class Weapon : IItem
{
    public string Name { get; set; }
    public int Damage { get; set; }
    public int Health { get; set; }

    public override string ToString()
    {
        return Name;
    }

    public void UseItem(Ib ib)
    {
        Health--;
        ib.xp = ib.xp + 20;
        if (Health <= 0)
        {
            Damage = 0;
            Console.WriteLine($"{"Grab new weapon".Pastel(ConsoleColor.Red)}");
        }
    }
}