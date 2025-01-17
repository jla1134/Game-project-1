public class PlayerBrigade 
{
    public List<(int id, char pos)> Units { get; set; } = new List<(int, char)>(5);

    public PlayerBrigade()
    {
        // Initialize with default values
        for (int i = 0; i < 5; i++)
        {
            Units.Add((0, 'N')); // 0 for no unit, 'N' for no position
        }
    }

    // Method to set a unit
    public void SetUnit(int index, int id, char pos)
    {
        if (index >= 0 && index < 5)
        {
            Units[index] = (id, pos);
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index must be between 0 and 4");
        }
    }

    // Method to get a unit
    public (int id, char pos) GetUnit(int index)
    {
        if (index >= 0 && index < 5)
        {
            return Units[index];
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index must be between 0 and 4");
        }
    }
}

public class enemyBrigade 
{
    //predetermined a.k.a does not require setup, just loading
}

function editPlayerBrigade()//tbd
{
    PlayerBrigade playerBrigade = new PlayerBrigade()
    Console.WriteLine("Editing player brigade:")
    // Access the entire list of units
    foreach (var (id, pos) in playerBrigade.Units)
    {
        Console.WriteLine($"Unit ID: {id}, Position: {pos}")
    }
    int[] position//load current position
    Console.WriteLine("To edit formation, type 1")
    Console.WriteLine("To edit familiars, type 2")
    int choice = Convert.ToInt32(Console.ReadLine())
    switch (choice)
    {
        case 1:
            Console.WriteLine("Editing formation:");
            //include info about what effects different positions have
            Console.Writeline("Choose a formation:\n
            1. Skein (R-M-F-M-R)\n
            2. Valley (F-M-R-M-F)\n
            3. Tooth (F-R-F-R-F)\n
            4. Wave (R-F-M-F-R)\n
            5. Front (F-F-F-F-F)\n
            6. Mid (M-M-M-M-M)\n
            7. Rear (R-R-R-R-R)\n
            8. Pike (R-R-F-R-R)\n
            9. Shield (F-F-R-F-F)\n
            10. Pincer (R-F-R-F-R)\n
            11. Saw (F-R-M-R-F)\n
            12. Hydra (R-R-F-F-F)");
            int choice = Convert.ToInt32(Console.ReadLine);
            switch (choice)
            {
                case 1: // Set position
                    position = [R,M,F,M,R];
                    break;

                case 2: // Set position
                    position = [F,M,R,M,F];
                    break;

                case 3: // Set position
                    position = [F,R,F,R,F];
                    break;

                case 4: // Set position
                    position = [R,F,M,F,R];
                    break;

                case 5: // Set position
                    position = [F,F,F,F,F];
                    break;

                case 6: // Set position
                    position = [M,M,M,M,M];
                    break;

                case 7: // Set position
                    position = [R,R,R,R,R];
                    break;
                
                case 8: // Set position
                    position = [R,R,F,R,R];
                    break;

                case 9: // Set position
                    position = [F,F,R,F,F];
                    break;

                case 10: // Set position
                    position = [R,F,R,F,R];
                    break;

                case 11: // Set position
                    position = [F,R,M,R,F];
                    break;

                case 12: // Set position
                    position = [R,R,F,F,F];
                    break;

                default:
                    console.Writeline("Cancel");
                    break;
            }
            break;
        
        case 2:
            Console.WriteLine("Editing familiars");
            break;

        default:
            Console.Writeline("Cancel");
            break;
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
        Print("Error: " + e.Message);

    return dataList;


function Battle(playerBrigade: playerBrigade; enemyBrigade: enemyBrigade)
{
    class turnOrder
    {
        int playerSpeed
        int enemySpeed
        string order
    }
    class turnOrderList
    {
        List<turnOrder> turnOrderList
    }
    function turnOrder(playerBrigade: playerBrigade; enemyBrigade: enemyBrigade)
    {
        int playerSpeed = playerBrigade.AGI
        int enemySpeed = enemyBrigade.AGI
        if (playerSpeed >= enemySpeed)
        {
            return "player"
        }
        else
        {
            return "enemy"
        }
    }
    function checkStatus(playerBrigade: playerBrigade; enemyBrigade: enemyBrigade)
    {
        if (playerBrigade.isAlive() and enemyBrigade.isAlive())
        {
            return "continue"
        }
        else
        {
            return "end"
        }
    }
    function skillResolution(playerBrigade: playerBrigade; enemyBrigade: enemyBrigade)
    {
        if (playerBrigade.Skill1 == 1)
        {
            Console.WriteLine("Player Brigade used Skill 1")
        }
        //add code to check if skill is a hit, crit, etc
        //if skill fails, perform regular attack
    }
    function enemySkillResolution(playerBrigade: playerBrigade; enemyBrigade: enemyBrigade)
    {
        if (enemyBrigade.Skill1 == 1)
        {
            Console.WriteLine("Enemy Brigade used Skill 1")
        }
        //add code to check if skill is a hit, crit, etc
        //if skill fails, perform regular attack
    }   
    function attack(playerBrigade: playerBrigade; enemyBrigade: enemyBrigade)
    {
        //add code to determine target
        int playerAttack = playerBrigade.ATK * playerScalar
        int enemyAttack = enemyBrigade.ATK * enemyScalar
        int playerDR = playerBrigade.DEF * playerDRScalar
        int enemyDR = enemyBrigade.DEF * enemyDRScalar
        int finalPlayerAttack = playerAttack - enemyDR
        int finalEnemyAttack = enemyAttack - playerDR
        //update enemy and player HP
        enemyBrigade.HP = enemyBrigade.HP - finalPlayerAttack
        playerBrigade.HP = playerBrigade.HP - finalEnemyAttack
    }
    while (playerBrigade.isAlive() and enemyBrigade.isAlive())
    {
        if (turnOrder(playerBrigade, enemyBrigade) == "player")
        {
            checkStatus(playerBrigade, enemyBrigade)
            skillResolution(playerBrigade, enemyBrigade)
            attack(playerBrigade, enemyBrigade)

        }
        else
        {
            checkStatus(playerBrigade, enemyBrigade)
            enemySkillResolution(playerBrigade, enemyBrigade)
            attack(playerBrigade, enemyBrigade)
        }

    }
}   
