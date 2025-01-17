// Item class to represent individual items
public class Item
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }

    public Item(string name, string description, int quantity)
    {
        Name = name;
        Description = description;
        Quantity = quantity;
    }
}

// Inventory class to manage items
public class Inventory
{
    private List<Item> items;

    public Inventory()
    {
        items = new List<Item>();
    }

    // Add an item to the inventory
    public void AddItem(Item item)
    {
        var existingItem = items.Find(i => i.Name == item.Name);
        if (existingItem != null)
        {
            existingItem.Quantity += item.Quantity;
        }
        else
        {
            items.Add(item);
        }
    }

    // Remove an item from the inventory
    public bool RemoveItem(string itemName, int quantity)
    {
        var item = items.Find(i => i.Name == itemName);
        if (item != null && item.Quantity >= quantity)
        {
            item.Quantity -= quantity;
            if (item.Quantity == 0)
            {
                items.Remove(item);
            }
            return true;
        }
        return false;
    }

    // Display all items in the inventory
    public void DisplayInventory()
    {
        Console.WriteLine("Inventory:");
        foreach (var item in items)
        {
            Console.WriteLine($"{item.Name} - {item.Description} (Quantity: {item.Quantity})");
        }
    }
}

// Example usage
class Program
{
    static void Main(string[] args)
    {
        Inventory playerInventory = new Inventory();

        // Add items to the inventory
        playerInventory.AddItem(new Item("Sword", "A sharp blade", 1));
        playerInventory.AddItem(new Item("Health Potion", "Restores 50 HP", 5));
        playerInventory.AddItem(new Item("Gold Coin", "Currency", 100));
    }
}

