namespace RPGspil;

public class Item : IItem
{
    public string Name { get; set; }

    public override string ToString()
    {
        return Name;
    }

    public void UseItem(Ib ib)
    {
        Console.WriteLine("");
    }

    
}