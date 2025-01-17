public class MenuItem
{
    public string Name { get; set; }
    public Action Action { get; set; }

    public MenuItem(string name, Action action)
    {
        Name = name;
        Action = action;
    }
}

public class Menu
{
    private List<MenuItem> items;
    private string title;

    public Menu(string title)
    {
        this.title = title;
        items = new List<MenuItem>();
    }

    public void AddItem(string name, Action action)
    {
        items.Add(new MenuItem(name, action));
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(title);
        Console.WriteLine(new string('-', title.Length));

        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i].Name}");
        }

        Console.WriteLine("\n0. Exit");
    }

    public void Run()
    {
        while (true)
        {
            Display();
            Console.Write("\nEnter your choice: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice))
            {
                if (choice == 0)
                {
                    break;
                }
                else if (choice > 0 && choice <= items.Count)
                {
                    items[choice - 1].Action();
                }
                else
                {
                    Console.WriteLine("Invalid choice. Press any key to continue.");
                    Console.ReadKey();
                }
            }
        }
    }
}

