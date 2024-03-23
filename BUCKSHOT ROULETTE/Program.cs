using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.WriteLine("Vítejte v hře Buckshot Roulette!");
        Console.WriteLine("Hra obsahuje válec s náboji. Sázejte na čísla a zkuste přežít!");

        int[] playerCylinder; // Válec s náboji hráče
        int[] dealerCylinder; // Válec s náboji dealera
        int totalRounds = 5; // Maximální počet kol
        int playerLives = 3; // Počet životů hráče
        int dealerLives = 3; // Počet životů dealera
        int maxPlayerItems = 6; // Maximální počet itemů hráče
        int maxCylinderCapacity = 10; // Maximální kapacita válce
        int roundTime = 5000; // Čas na rozhodnutí v milisekundách (5 sekundy)

        List<Item> availableItems = new List<Item> { new Item("Lupa", "Umožňuje vidět typ náboje"),
                                                     new Item("Pouta", "Odepře druhému hráči hraní v jednom kole"),
                                                     new Item("Pivo", "Zasahové náboje v tomto kole neubírají životy"),
                                                     new Item("Cigareta", "Přidá 1 život") };

        List<Item> playerItems = new List<Item>(); // Itemy hráče

        for (int round = 1; round <= totalRounds; round++)
        {
            Console.WriteLine($"\nKolo č. {round}");

            // Nastavení náhodných nábojů a itemů pro každé kolo pro hráče a dealera
            playerCylinder = LoadCylinder(maxCylinderCapacity);
            dealerCylinder = LoadCylinder(maxCylinderCapacity);
            List<Item> roundPlayerItems = GetRoundItems(availableItems);
            List<Item> dealerItems = GetRoundItems(availableItems);

            // Informace o brokovnici hráče na začátku kola
            Console.WriteLine($"Brokovnice hráče obsahuje {playerCylinder.Length} nábojů:");
            Console.WriteLine($"  - {playerCylinder.Count(x => x == 0)} slepých nábojů");
            Console.WriteLine($"  - {playerCylinder.Count(x => x == 1)} ostrých nábojů");

            // Použití itemů hráče
            UseItems(playerItems, playerCylinder);

            // Hráč rozhoduje, zda střílí na sebe nebo na dealera
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Chcete střílet na sebe (S) nebo na dealera (D)? ");
            Console.ResetColor();
            char playerChoice = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            if (playerChoice == 'S')
            {
                // Otočení válce pro hráče
                int playerShotPosition = SpinCylinder(playerCylinder, roundTime);

                // Kontrola výsledku pro hráče
                if (playerCylinder[playerShotPosition] == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Blahopřeji! Přežili jste střelbu v tomto kole!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bohužel, střelba vás zasáhla.");
                    Console.ResetColor();
                    playerLives--;

                    if (playerLives <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Hra končí, vy jste zemřel/a.");
                        Console.ResetColor();
                        break;
                    }

                    Console.WriteLine($"Zbývající životy hráče: {playerLives}");
                }
            }
            else if (playerChoice == 'D')
            {
                // Otočení válce pro dealera
                int dealerShotPosition = SpinCylinder(dealerCylinder, roundTime);

                // Kontrola výsledku pro dealera
                if (dealerCylinder[dealerShotPosition] == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Dealer přežil střelbu v tomto kole!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Dealer byl zasažen.");
                    Console.ResetColor();
                    dealerLives--;

                    if (dealerLives <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Hra končí, dealer zemřel.");
                        Console.ResetColor();
                        break;
                    }

                    Console.WriteLine($"Zbývající životy dealera: {dealerLives}");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Neplatná volba. Ztrácíte kolo.");
                Console.ResetColor();
            }

            // Přidání itemů hráče
            foreach (Item item in roundPlayerItems)
            {
                if (playerItems.Count < maxPlayerItems)
                {
                    playerItems.Add(item);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Dosáhli jste maximálního počtu itemů. Některý item bude ignorován.");
                    Console.ResetColor();
                }
            }

            // Zobrazí dostupné itemy pro hráče
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nDostupné itemy pro hráče:");
            foreach (Item item in playerItems)
            {
                Console.WriteLine($"- {item.Name}: {item.Description}");
            }
            Console.ResetColor();

            // Zobrazí dostupné itemy pro dealera
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nDostupné itemy pro dealera:");
            foreach (Item item in dealerItems)
            {
                Console.WriteLine($"- {item.Name}: {item.Description}");
            }
            Console.ResetColor();
        }

        Console.WriteLine("\nKonec hry.");
    }

    static void UseItems(List<Item> items, int[] playerCylinder)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Použití itemů:");
        Console.ResetColor();

        foreach (Item item in items)
        {
            Console.Write($"Chcete použít '{item.Name}'? (A/N): ");
            char choice = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            if (choice == 'A')
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Používáte '{item.Name}'. {item.Description}");
                Console.ResetColor();

                // Logika pro každý item (lupa, pouta, pivo, cigareta)
                switch (item.Name)
                {
                    case "Lupa":
                        // Zjistí typ náboje v brokovnici
                        int shotType = playerCylinder[0];
                        Console.WriteLine($"První náboj v brokovnici je: {GetShotTypeDescription(shotType)}");
                        break;
                    case "Pouta":
                        // Sníží počet nábojů v brokovnici o 1
                        if (playerCylinder.Length > 1)
                        {
                            Array.Resize(ref playerCylinder, playerCylinder.Length - 1);
                            Console.WriteLine("Po použití pout zůstává v brokovnici o jeden náboj méně.");
                        }
                        else
                        {
                            Console.WriteLine("Brokovnice je prázdná, pouta nemají žádný efekt.");
                        }
                        break;
                    case "Pivo":
                        // Následné náboje neubírají životy
                        Console.WriteLine("Po použití piva následné náboje neubírají životy v tomto kole.");
                        break;
                    case "Cigareta":
                        // TODO: Implementujte logiku cigarety (přidání 1 života)
                        break;
                    default:
                        break;
                }
            }
        }
    }

    static int[] LoadCylinder(int maxCapacity)
    {
        Random random = new Random();
        int cylinderSize = random.Next(5, maxCapacity + 1); // Náhodný počet nábojů od 5 do maxCapacity
        int[] cylinder = new int[cylinderSize];

        // Náhodné umístění slepých nábojů
        for (int i = 0; i < cylinderSize; i++)
        {
            if (random.Next(2) == 0) // 50% šance na slepý náboj
            {
                cylinder[i] = 0; // Slepý náboj
            }
            else
            {
                cylinder[i] = 1; // Normální náboj
            }
        }

        return cylinder;
    }

    static int SpinCylinder(int[] cylinder, int roundTime)
    {
        Random random = new Random();
        int shotPosition = -1;

        // Zobrazí informaci o otáčení válce
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Zbývající čas na rozhodnutí: {roundTime / 1000} sekund. Válec se otáčí...");

        // Čekání na zvolení hráče
        Thread.Sleep(roundTime);

        // Náhodné určení pozice střely
        shotPosition = random.Next(cylinder.Length);

        // Přebití válce, pokud je prázdný
        if (cylinder.Length == 0)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Válec je prázdný. Probíhá přebití válce...");
            cylinder = LoadCylinder(cylinder.Length + 5); // Přebití a přidání dalších 5 nábojů
        }

        return shotPosition;
    }

    static List<Item> GetRoundItems(List<Item> availableItems)
    {
        Random random = new Random();
        List<Item> roundItems = new List<Item>();

        // Každé kolo hráč a dealer dostanou 1-3 náhodné itemy z dostupných
        int itemCount = random.Next(1, 4);
        for (int i = 0; i < itemCount; i++)
        {
            int index = random.Next(availableItems.Count);
            roundItems.Add(availableItems[index]);
        }

        return roundItems;
    }

    static string GetShotTypeDescription(int shotType)
    {
        return (shotType == 0) ? "slepý náboj" : "ostrý náboj";
    }
}

class Item
{
    public string Name { get; }
    public string Description { get; }

    public Item(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
