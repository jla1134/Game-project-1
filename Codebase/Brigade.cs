public class playerBrigade 
{
    int id1
    int id2
    int id3
    int id4
    int id5
    //maybe don't make a class, just a base level array
//needs code to specify formation
//needs a function to edit 
}
public class enemyBrigade 
{
    int id1
    int id2
    int id3
    int id4
    int id5
    //maybe don't make a class, just a base level array
//needs code to specify formation
//needs a function to edit 
}
    // Add more properties as needed
function editPlayerBrigade()//tbd
{
    Console.WriteLine("Editing player brigade:")
    Console.WriteLine("To edit formation, type 1")
    Console.WriteLine("To edit player, type 2")
    int choice = Convert.ToInt32(Console.ReadLine())
    switch (choice)
    {
        case 1:
            Console.WriteLine("Editing formation:")

    }
        case 2:
    {
            Console.WriteLine("Editing familiars")
    }
}
public class Familiar
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public int HP { get; set; }//HP = HP Base * (1 + HPScale * Level)
    public int ATK { get; set; }//ATK = ATK Base * (1 + ATKScale * Level)
    public int DEF { get; set; }//DEF = DEF Base * (1 + DEFScale * Level)
    public int WIS { get; set; }//WIS = WIS Base * (1 + WISScale * Level)
    public int AGI { get; set; }//AGI = AGI Base * (1 + AGIScale * Level)
    public int HPScale { get; set; }
    public int ATKScale { get; set; }
    public int DEFScale { get; set; }
    public int WISScale { get; set; }
    public int AGIScale { get; set; }
    public int Skill1 { get; set; }
    public int Skill2 { get; set; }
    public int Skill3 { get; set; }
}

function ImportCsv(filePath: string) : List<DataObject>
    List<DataObject> dataList = new List<DataObject>()
    
    try
        // Open the CSV file
        StreamReader reader = new StreamReader(filePath)
        string headerLine = reader.ReadLine() // Read the header line

        // Loop through each line in the CSV
        while (not reader.EndOfStream)
            string line = reader.ReadLine()
            string[] values = line.Split(',')

            // Create a new DataObject and assign properties
            DataObject data = new DataObject()
            data.Property1 = values[0]
            data.Property2 = values[1]
            data.Property3 = Convert.ToInt32(values[2])
            // Map more properties as needed

            // Add the object to the list
            dataList.Add(data)
        
        // Close the reader
        reader.Close()
    
    catch (Exception e)
        // Handle exceptions (e.g., file not found, format errors)
        Print("Error: " + e.Message)

    return dataList