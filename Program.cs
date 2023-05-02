using Lotto;
using System.ComponentModel.Design;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Sorsolas> sorsolas_list = new List<Sorsolas>();
        List<NySzam> nySzam_list = new List<NySzam>();
        string[] lines = File.ReadAllLines("sorsolas.txt");
        foreach (var item in lines)
        {
            string[] values = item.Split(';');
            Sorsolas sorsolas_object = new Sorsolas(values[0], values[1], values[2], values[3], values[4], values[5]);
            sorsolas_list.Add(sorsolas_object);
        }
        int db = 0;
        for (int i = 1; i < 91; i++)
        {
            foreach (var item in sorsolas_list)
            {
                if (i == item.szam1)
                    db++;
                if (i == item.szam2)
                    db++;
                if (i == item.szam3)
                    db++;
                if (i == item.szam4)
                    db++;
                if (i == item.szam5)
                    db++;
            }
            NySzam nySzam_object = new NySzam(i, db);
            nySzam_list.Add(nySzam_object);
            db = 0;
        }

        //2. feladat
        Console.WriteLine("Adj megy egy számot");
        string input_szam = Console.ReadLine();

        int het = 0;
        if (int.TryParse(input_szam, out het))
        {
            if (het > 0 && het < 53)
                    
                foreach (var item in sorsolas_list)
            {
                if (item.het ==  het)
                {
                    Console.WriteLine($"2. feladat: {item.het},{item.szam1}, {item.szam2},{item.szam3},{item.szam4},{item.szam5} ");
                }
            }
        else 
            Console.WriteLine("Nincs tartományban!");
        
        }
        else
        {
            Console.WriteLine("Nem szám");
        }

        //3.feladat
        int minDb = int.MaxValue;
        int minNySzam = 0;

        foreach (var item in nySzam_list)
        {
            if(minDb > item.db)
            {
                minDb = item.db;
                minNySzam = item.szam;
            }
        }
        Console.WriteLine($"3.Feladat{minNySzam}{minDb}");

        //4.feladat
        //megszamolas tétele
        int parosSum = 0;
        foreach (var item in nySzam_list)
        {
            if(item.szam %2 == 0)
            {
                parosSum += item.db;
            }
        }
        Console.WriteLine($"3 Feladat, páros számpk kihúzva: {parosSum}");

        //5-6 feladat
        int szam5 = 0;
        int szam46 = 0;

        foreach (var item in nySzam_list)
        {
            if (item.szam == 5)
                szam5 = item.db;
            if (item.szam == 46)
                szam46 = item.db;
        }
        Console.WriteLine($"5-6. feladat: 5:{szam5}; 46: {szam46}");
        //7.feladat
        foreach (var item in nySzam_list)
        {
            Console.WriteLine(item.szam + ";" + item.db);
        }

        Console.ReadKey();
    }
}
    