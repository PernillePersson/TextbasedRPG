namespace RPGspil;

public class Inventory
{
    public List<IItem> _Inventory { get; set; }
    public Inventory(List<IItem> inventory)
    {
        _Inventory = inventory;
    }
    
    public void AddToInventory(IItem i)
    {
        _Inventory.Add(i);
    }

    public void GrapFromInventory(IItem i)
    {
        _Inventory.Remove(i);
    }

}