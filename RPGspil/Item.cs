namespace RPGspil;

public class TestItem : IItem
{
    public string Name { get; set; }

    public override string ToString()
    {
        return Name;
    }

    public void UseItem()
    {
        throw new NotImplementedException();
    }

    
}