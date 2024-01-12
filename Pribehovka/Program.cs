using System;
using RPG;

class Program
{
    static void Main() //zacatek
    {
        Places places = new Places(); //trida na pozici a cas
        places.PlaceDialog("Doma", "17:30");

        Console.WriteLine("Hraješ na počítači a v tom ti zavolají dva kamarádi a ptají se, jestli nechceš jít do Blanice.");
        Console.WriteLine("Jako vždy váháš, protože se nechceš opít, ale sedět doma není zábava, a tak vyvstává otázka:");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("\nVydáš se do hospody a zažiješ své vlastní dobrodružství?! (1/2)");
        Console.ResetColor();

        string volba = "";

        while (volba != "1" && volba != "2") //while dokud nevyberes 1/2
        {
            volba = Console.ReadLine();
            switch (volba)
            {
                case "1":
                    CestaNaVolhu();
                    break;
                case "2":
                    KonecHry();
                    break;
                default:
                    Console.WriteLine("Vyber pouze z možností =)"); //opakovani pokud nevyberes spravne
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nVydáš se do hospody a zažiješ své vlastní dobrodružství?! (1/2)");
                    Console.ResetColor();
                    break;
            }
        }

    }

    static void CestaNaVolhu()
    {
        Places places = new Places();
        places.PlaceDialog("U Jedenáctky", "18:00"); //trida na pozici a cas

        Console.WriteLine("\nVychazíš");
        Console.WriteLine("Klasicky se scházíte na zastávce u Jedenáctky, kde se rozhodujete jestli busem nebo pěšky");
        Console.ForegroundColor = ConsoleColor.DarkRed; //zabarveni volby
        Console.WriteLine("Jdeš se podívat na iDOS a bus jede za 10 minut, chceš jít pešky nebo autobusem? (1/2)");
        Console.ResetColor();

        string volba = "";

        while (volba != "1" && volba != "2") //while dokud clovek nevybere 1/2
        {
            volba = Console.ReadLine();

            switch (volba)
            {
                case "1":
                    PesiCesta();
                    break;
                case "2":
                    Bus();
                    break;
                default:
                    Console.WriteLine("Vyber pouze z možností =)");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Jdeš se podívat na iDOS a bus jede za 10 minut, chceš jít pešky nebo autobusem? (1/2)");
                    Console.ResetColor();
                    break;
            }
        }
    }

    static void PesiCesta()
    {
        Places places = new Places(); //trida
        places.PlaceDialog("Starej Chodov", "18:10");

        Console.WriteLine("\nRozhodli jste se jít pěšky, protože čekat 10 minut nemá smysl.");
        Console.WriteLine("Povídate si jak se kdo má a co dělá.");
        Console.WriteLine("Postupně se blížíte k Chodovu a autobus jede za 3 minuty.");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Doběhnete autobus nebo půjdete rovnou na volhu? (Chodov(1)/Volha(2))");
        Console.ResetColor();

        string volba = "";

        while (volba != "1" && volba != "2") //while dokud neni 1/2
        {
            volba = Console.ReadLine();

            switch (volba)
            {
                case "1":
                    Chodov();
                    break;
                case "2":
                    Volha();

                    break;
                default:
                    Console.WriteLine("Vyber pouze z možností =)");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Doběhnete autobus nebo půjdete rovnou na volhu? (Chodov(1)/Volha(2))");
                    Console.ResetColor();
                    break;
            }
        }
    }

    static void Chodov()
    {
        Places places = new Places(); //trida
        places.PlaceDialog("Chodov", "18:15");

        Console.WriteLine("\nBěžíte jak o závod aby jste stihli autobus");
        Console.WriteLine("Dorážíte na most u OC Chodov a vidíte jak 177 stojí na zastávce");
        Console.WriteLine("Zrychlíte, ale štestí není na vaší straně, protože autobusák je kokot a zavře vám před očima");
        Console.WriteLine("A tak nezbývá než pokračovat pěšky");

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("\nStiskni jakoukoliv klávesu pro pokračování.");
        Console.ResetColor();
        Console.ReadLine();

        Blanice(); //presun do funkce blanice
    }
    static void Volha()
    {
        Places places = new Places(); //trida
        places.PlaceDialog("Volha", "18:35");

        Console.WriteLine("\nRozhodli jste se jít rovnou na Volhu");
        Console.WriteLine("Byla to dobrá volba, protože by jste to nestihli a aspoň jste si ušetřili dech");
        Console.WriteLine("po chvíli vidíte Volhu a to už je znamení že tam skoro jste!");

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("\nStiskni jakoukoliv klávesu pro pokračování.");
        Console.ResetColor();
        Console.ReadLine();

        Blanice(); //presun
    }

    static void Bus()
    {
        Places places = new Places(); // -//-
        places.PlaceDialog("125/177", "18:10");

        Console.WriteLine("Rozhodli jste se počkat a hezky jste si pokecali o tom, jak se kdo má.");
        Console.WriteLine("Přecijen kam spěchat...");
        Console.WriteLine("Cesta na Chodov byla klidná, ale po nastoupení do 177 začala ta pravá zábava");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Chceš se jí zúčastnit nebo budeš v klidu ?(ano(1)/ne(2))\n");
        Console.ResetColor();

        string volba = "";

        while (volba != "1" && volba != "2")
        {
            volba = Console.ReadLine();

            switch (volba)
            {
                case "1":
                    Revizor();
                    break;
                case "2":
                    Console.WriteLine("Správná volba, kdyby si začal hlučet chytl by tě revizor a to je konec...");
                    Console.WriteLine("Upřímně kdo platí lítaču nebo lístky ?");
                    break;
                default:
                    Console.WriteLine("Vyber pouze z možností =)");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Chceš se jí zúčastnit nebo budeš v klidu ?(ano(1)/ne(2))\n");
                    Console.ResetColor();
                    break;
            }
        }
    }
    static void Revizor()
    {
        Places places = new Places();
        places.PlaceDialog("177", "18:35");

        Console.WriteLine("S klukama si žačal zpívat Mešitu od Ortelu, avšak pan revizor to moc dobře nevzal.");
        Console.WriteLine("šel si tě omrknout jestli máš jízdenku");
        Console.WriteLine("Hledáš a hledáš, ale neúspěch");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Zkusíš utéct nebo zaplatíš 1500 ? (útěk(1)/platba(2))\n");
        Console.ResetColor();

        string volba = "";

        while (volba != "1" && volba != "2")
        {
            volba = Console.ReadLine();

            switch (volba)
            {
                case "1":
                    Utek();
                    break;
                case "2":
                    Pokuta();
                    break;
                default:
                    Console.WriteLine("Vyber pouze z možností =)");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Zkusíš utéct nebo zaplatíš 1500 ? (útěk(1)/platba(2))\n");
                    Console.ResetColor();
                    break;
            }
        }
    }

    static void Utek()
    {
        Places places = new Places();
        places.PlaceDialog("177", "18:35");

        Console.WriteLine("Zkoušíš utéct!");
        Console.WriteLine("R: VRAŤ SE !");
        Console.WriteLine("Povedlo se! Utekl si mu a nestihl si mu dát ani žádný průkaz.");
        Console.WriteLine("Musel sis vystoupit u Kunratického lesa");
        Console.WriteLine("Tak snad kámoši počkaj s pivem na tebe !");

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("\nStiskni jakoukoliv klávesu pro pokračování.");
        Console.ResetColor();
        Console.ReadLine();

        Blanice();
    }

    static void Pokuta()
    {
        Places places = new Places();
        places.PlaceDialog("177", "18:35");

        Console.WriteLine("Poslušně platíš 1500 čímž ses připravil o celovečerní zábavu!");
        Console.WriteLine("Budeš muset najít nějakou cestu, jak se dostat k pití i bez peněz");

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("\nStiskni jakoukoliv klávesu pro pokračování.");
        Console.ResetColor();
        Console.ReadLine();

        Blanice();
    }

    static void Blanice()
    {
        Places places = new Places();
        places.PlaceDialog("klub Blanice", "18:40");

        Console.WriteLine("");
        Console.WriteLine("už jste před vchodem a září na vás vstupní tabule.\n");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(" _ __   __       _,   _ __    ___    ,___  ______");
        Console.WriteLine("( /  ) ( /      / |  ( /  )  ( /    /   / (  /   ");
        Console.WriteLine(" /--<   /      /--|   /  /    /    /        /--  ");
        Console.WriteLine("/___/ (/___/ _/   | _/  (_  _/_   (___/   (/____/\n");
        Console.ResetColor();
        Console.WriteLine("Vstupujete dovnitř, hledáte místečko hezky u boxéru, abyste se mohli vyřádit.");
        Console.WriteLine("");
        Console.WriteLine("\nNajdete, sedenete si a objednáváte si:");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Vymažpaměť(1), Pivo(2), 10 čupít(3), víno(4)");
        Console.ResetColor();
        string volba = "";

        while ((volba != "1" && volba != "2" && volba != "3" && volba != "4"))
        {
            volba = Console.ReadLine();

            switch (volba)
            {
                case "1":
                    Console.WriteLine("Vymažpaměť hned na začátek?!");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nStiskni jakoukoliv klávesu pro pokračování.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Rada();
                    break;
                case "2":
                    Console.WriteLine("Pivo, klasická volba jak se patří!");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nStiskni jakoukoliv klávesu pro pokračování.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Rada();
                    break;
                case "3":
                    Console.WriteLine("10 čupít, pán se vyzná !");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nStiskni jakoukoliv klávesu pro pokračování.");
                    Console.ResetColor();
                    Console.ReadLine();
                    Rada();
                    break;
                case "4":
                    Vino();
                    break;
                default:
                    Console.WriteLine("Vyber pouze z možností =)");
                    Console.WriteLine("Najdete, sedenete si a objednáváte si:");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Vymažpaměť(1), Pivo(2), 10 čupít(3), víno(4)");
                    Console.ResetColor();
                    break;
            }
        }
    }

    static void Vino()
    {
        Console.WriteLine("Zbláznil si se ?!");
        Console.WriteLine("Pít víno ? Zaprvé si dostal krabicák a zadruhé si nasral kámoše");
        Console.WriteLine("Tohle nemůže dopadnout dobře...");
        Console.WriteLine("*Slyšíš tichý výsměch");
        Console.WriteLine("Naštval si se a šel domů");
        KonecHry();
    }
    static void Rada()
    {
        Places places = new Places();
        places.PlaceDialog("klub Blanice", "21:00");

        Console.WriteLine("\nŠel si do řady, objednat si nějaké pití");
        Console.WriteLine("Čekáš nesmysl řadu, a když si skoro na řade přiběhne slečna a ptá se:");
        Console.WriteLine("Čauky, nebude ti vadit, že tě předběhnu ? Kopupim ti panáka!");
        Console.WriteLine("Panáček zdarma ?! Utíkej přede mě!");
        Console.WriteLine("\nKoupila ti panáka a ptá se:");
        Console.WriteLine("Dáš si ho semnou ? =)");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("(W rizz(1)/L rizz(2))");
        Console.ResetColor();

        string volba = "";

        while (volba != "1" && volba != "2")
        {
            volba = Console.ReadLine();

            switch (volba)
            {
                case "1":
                    WRizz();
                    break;
                case "2":
                    LRizz();
                    break;
                default:
                    Console.WriteLine("Vyber pouze z možností =)");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("(W rizz(1)/L rizz(2))");
                    break;
            }
        }
        Console.ReadKey();
    }

    public static void WRizz()
    {
        Places places = new Places();
        places.PlaceDialog("klub Blanice", "21:05");

        Console.WriteLine("\nDali jste si drink a docela si i rozuměli");
        Console.WriteLine("Kecali jste a zkoušíš W Rizz, protože to vypadá, že nikoho nemá!");
        Console.WriteLine("Kecáte a kecáte, když v tom přijde nějaký frajer a začne do tebe strkat");
        Console.WriteLine("Tvoje nová kámoška ho uklidňuje, když vtom ti dojde, že spolu asi chodí");
        Console.WriteLine("Chce jít ven, chce se prát, nemáš na výběr a deš");

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("\nStiskni jakoukoliv klávesu pro pokračování.");
        Console.ResetColor();
        Console.ReadLine();

        Venku();
    }

    public static void LRizz()
    {
        Places places = new Places();
        places.PlaceDialog("klub Blanice", "21:05");

        Console.WriteLine("Nakonec si se vrátil ke stolu, možná to byla šance, ale kdo ví.");
        Console.WriteLine("Zbytek večera si s kámošema a užiješ si to");
        Console.WriteLine("Dáváte jedno pivo za druhým a na boxeru lámete all time high!");

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("\nStiskni jakoukoliv klávesu pro pokračování.");
        Console.ResetColor();
        Console.ReadLine();

        Boxer();
    }

    public static void Venku()
    {
        Places places = new Places();
        places.PlaceDialog("Před klubem", "22:00");

        Console.WriteLine("Je to v prdeli, frajer o hlavu větší, nabombenej...");
        Console.WriteLine("Tohle nemůžu v životě vyhrát...");
        Console.WriteLine("\n: TAK CO TY CHCÍPÁKU, KOMU JEDEŠ DO HOLKY ?!");
        Console.WriteLine("DNESKA CHCÍPNEŠ, TO TI SLIBUJU!");
        Console.WriteLine("\nKonec, frajer je ještě magor, za co mě bůh trestá!");

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("\nStiskni jakoukoliv klávesu pro pokračování.");
        Console.ResetColor();
        Console.ReadLine();

        Console.WriteLine("FIGHT OR DIE!");
        Souboj();
    }

    public static void Souboj()
    {
        Random rand = new Random();
        int zivotyHrac1 = 10; //nastaveni zivotu hracu (ebe a nepritele)
        int zivotyHrac2 = 10;

        for (int kolo = 1; kolo <= 10; kolo++) //max 10 kol
        {
            Console.WriteLine($"\n----- Kolo {kolo} -----");

            if (zivotyHrac1 <= 0 || zivotyHrac2 <= 0) //pokud jsouj zivoty na 0 souboj konci
            {
                break;
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            int hrac1Utoci = HracVolba("co uděláš? Útok(1), Obrana(2): "); //volba akce
            Console.ResetColor();

            int hrac2Utoci = 1;

            int hodHrac1 = rand.Next(1, 7); //"hod kostkou" vyssi cislo vyhrava a dava dmg, mensi zase dostava
            int hodHrac2 = rand.Next(1, 7);

            Console.WriteLine($"Hodil jsi \x1B[3m{hodHrac1}\x1B[0m, Frajer hodil \x1B[3m{hodHrac2}\x1B[0m"); //vypis do konzole v kurzive z chat gpt

            if (hrac1Utoci == 1 && hrac2Utoci == 1) //
            {
                Console.WriteLine("Oba útočíte..."); //kdyz oba utocime

                if (hodHrac1 > hodHrac2)
                {
                    Console.WriteLine("...a tvůj útok byl úspěšný!"); //padlo ti vetsi cislo na kostce davas dmg
                    zivotyHrac2 -= 5;
                }
                else if (hodHrac1 < hodHrac2)
                {
                    Console.WriteLine("...ale Frajer tě překonal, jeho útok byl úspěšný!"); //padlo ti mensi, dostavas dmg
                    zivotyHrac1 -= 5;
                }
                else
                {
                    Console.WriteLine("...a oba jste se zadanému úderu vyhnuli, žádné poškození nenastalo."); //stejne cislo, nic se nestalo
                }
            }
            else if (hrac1Utoci == 1 && hrac2Utoci == 2)
            {
                Console.WriteLine("útočíš, Frajer se brání."); //frajer brani utok = nic se nedeje
                zivotyHrac2 -= 0;
                Console.WriteLine("Ubránil se!");
            }
            else if (hrac1Utoci == 2 && hrac2Utoci == 1)
            {
                Console.WriteLine("Bráníš se, Frajer útočí."); //ubranis utok = nic se nedeje
                zivotyHrac1 -= 0;
                Console.WriteLine("Ubránil si se");
            }
            else
            {
                Console.WriteLine("Oba se bráníte, žádné poškození nenastalo.");
            }

            Console.WriteLine($"Tvoje životy: {zivotyHrac1}, Frajerovy životy: {zivotyHrac2}"); //vypis aktualniho stavu zivotu
        }

        Console.WriteLine("\n----- Výsledek souboje -----");

        if (zivotyHrac1 <= 0 || zivotyHrac2 <= 0)
        {
            if (zivotyHrac1 <= 0)
            {
                Console.WriteLine("Frajer vyhrál!");
                Console.WriteLine("Co si budem, čekal si něco jinýho?"); //vyhra nepritele
                KonecHry();
            }
            else
            {
                Console.WriteLine("Vyhrál jsi!");
                Console.WriteLine("Upřímně jsem to nečekal, ale dobrá práce!"); //tvoje vyhra
                WWRizz();
            }
        }
        else if (zivotyHrac1 > zivotyHrac2)
        {
            Console.WriteLine("Vyhrál si!");
            Console.WriteLine("Upřímně jsem to nečekal, ale dobrá práce!"); //vyhra pokud prekoname 10 kol a mame vic hp
        }
        else if (zivotyHrac1 < zivotyHrac2)
        {
            Console.WriteLine("Frajer vyhrál!");
            Console.WriteLine("Co si budem, čekal si něco jinýho?");  //prohra pokud prekoname 10 kol a mame min hp
            KonecHry();
        }
        else
        {
            Console.WriteLine("Remíza!");
            Console.WriteLine("Oba končíte v nemocnici"); //oba prohravate remizou = stejne hp na konci
            KonecHry();
        }
    }

    public static int HracVolba(string prompt)
    {
        Console.Write(prompt);
        int volba;
        while (!int.TryParse(Console.ReadLine(), out volba) || (volba != 1 && volba != 2))
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Zadejte platnou volbu (1 nebo 2): ");
            Console.ResetColor();
        }
        return volba;
    }

    public static void Boxer()
    {
        Places places = new Places();
        places.PlaceDialog("klub Blanice", "23:00");

        Console.WriteLine("\nS kámošema už máte řádnou hladinku, což znamena BOXER !!!");
        Console.WriteLine("Navalíte se na boxer, vytáhnete drobáčky a jedete bomby");

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("Chceš jít na boxer? (ano/ne): ");
        Console.ResetColor();
        string decision = Console.ReadLine().ToLower();

        if (decision == "ano")
        {
            Random random = new Random(); //nahodne cislo od 1-999 ktere nasledne urcuje odpoved programu, respektive tvuj vysledek an boxeru
            int punchResult = random.Next(1, 1000);

            if (punchResult >= 1 && punchResult <= 500)
            {
                Console.WriteLine($"Minul si boxer, nic moc úder. Číslo: {punchResult}"); //pod 500 slabota
            }
            else if (punchResult >= 501 && punchResult <= 700)
            {
                Console.WriteLine($"Pěkná rána, mohla být lepší! Číslo: {punchResult}"); //pod 700 dobry
            }
            else if (punchResult >= 701 && punchResult <= 999)
            {
                Console.WriteLine($"?! SUPER VYKON! Číslo: {punchResult}"); //nad 701 hodne dobry
            }
        }
        else
        {
            Console.WriteLine("Rozhodl ses nejít na boxer. Bezpečná volba!");
        }
        Stul();
    }

    public static void WWRizz()
    {
        Places places = new Places();
        places.PlaceDialog("klub Blanice", "23:15");

        Console.WriteLine("VYHRÁL SI");
        Console.WriteLine("Slečna všechno viděla a hrozně se ti za něj omlouvala");
        Console.WriteLine("A vyadá to, že má i zájem =)");
        Console.WriteLine("Padne něco málo laškování a je to...");
        Console.WriteLine("Po chvilce ... se ptá jestli kní nechceš na barák, že prý bydlí blízko...");
        Console.WriteLine("Chceš jít ?!");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Ano(1)/Ne(2))");
        Console.ResetColor();

        string volba = "";

        while (volba != "1" && volba != "2")
        {
            volba = Console.ReadLine();

            switch (volba)
            {
                case "1":
                    Barak();
                    break;
                case "2":
                    Stul();
                    break;
                default:
                    Console.WriteLine("Vyber pouze z možností =)");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Ano(1)/Ne(2))");
                    Console.ResetColor();
                    break;
            }
        }
        Console.ReadKey();
    }

    public static void Barak()
    {
        Places places = new Places();
        places.PlaceDialog("Slečny byt", "24:00");

        Console.WriteLine("Jsi u ní doma");
        Console.WriteLine("Pomalu se to začíná schylovat ... No však víme k čemu ");
        Console.WriteLine("Večer sis užil a se slečnou si rozuměl");
        Console.WriteLine("Ráno se vydáváš domů a  o všem musíš říct kamaádům");

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("\nStiskni jakoukoliv klávesu pro pokračování.");
        Console.ResetColor();
        Console.ReadLine();

        DumRano();
    }

    public static void Stul()
    {
        Places places = new Places();
        places.PlaceDialog("klub Blanice", "1:00");

        Console.WriteLine("Posedáváte, dáváte poslední pivo a pomalu se už vydáváte na cestu domů...");
        Console.WriteLine("Jdete pešky, zaprvé je to kousek a zadruhé musíte vystřízlivět!");
        Console.WriteLine("Celý večer jste si užili a o všem si po cestě pokecali!");

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("\nStiskni jakoukoliv klávesu pro pokračování.");
        Console.ResetColor();
        Console.ReadLine();
    }

    public static void DumVecer()
    {
        Places places = new Places();
        places.PlaceDialog("Doma", "3:00");

        Console.WriteLine("");
    }

    public static void DumRano()
    {
        Places places = new Places();
        places.PlaceDialog("Doma", "10:00");

        Console.WriteLine("Došel si v klidu domů a potkal si naštvanou mámu, který si celý večer nebral telefon !");
        Console.WriteLine("Byla lehčí hádka, ale uhrál si to na to, že si spal u kámoše... Klasika");
        Console.WriteLine("Konec dobrý, všechno dobré.");

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("\nStiskni jakoukoliv klávesu pro pokračování.");
        Console.ResetColor();
        Console.ReadLine();

        Vyhra();
    }

    public static void KonecHry() //konec hry , ktery nam umoznuje hrat od znova
    {
        Console.WriteLine("\nHra končí\n");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Hrát znova? (ano(1)/ne(2))");
        Console.ResetColor();

        string volba = "";

        while (volba != "1" && volba != "2")
        {
            volba = Console.ReadLine();

            switch (volba)
            {
                case "1":
                    Console.Clear();
                    Main();
                    break;
                case "2":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Vyber pouze z možností =)");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Hrát znova? (ano(1)/ne(2))");
                    Console.ResetColor();
                    Console.Clear();
                    break;
            }
        }
    }
    public static void Vyhra() //Konec hry vyhrou, umoznuje nam hrat od znova
    {
        Console.WriteLine("\nGratuluju, vyhrál si !\n");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Hrát znova? (ano(1)/ne(2))");
        Console.ResetColor();

        string volba = "";

        while (volba != "1" && volba != "2")
        {
            volba = Console.ReadLine();

            switch (volba)
            {
                case "1":
                    Console.Clear();
                    Main();
                    break;
                case "2":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Vyber pouze z možností =)");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Hrát znova? (ano(1)/ne(2))");
                    Console.ResetColor();
                    Console.Clear();
                    break;
            }
        }
    }
}
