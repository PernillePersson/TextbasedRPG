namespace RPGspil;

public interface IItem
{
    public string Name { get; set; }
    
    public void UseItem(Ib ib);
}