using RaktarApp;

List<Termek> list = new List<Termek>();
int hibasSorokSzama = 0;

foreach (string sor in File.ReadLines("termekek.txt").Skip(1))
{
    string[] adatok = sor.Split("|");

    if (adatok.Length != 4)
    {
        hibasSorokSzama++;
        continue;
    }
    if (adatok[0] != "S" && adatok[0] != "G")
    {
        hibasSorokSzama++;
        continue;
    }
    if (!int.TryParse(adatok[2],out int alapar) || !int.TryParse(adatok[3], out int garanciaevek))
    {
        hibasSorokSzama++;
        continue;
    }
    if (adatok[0] == "S")
    {
        Termek termek = new Termek(adatok[1], alapar);
        list.Add(termek);
    }
    else if (adatok[0] == "G")
    {
        TartosTermek tartosTermek = new TartosTermek(adatok[1], alapar, garanciaevek);
        list.Add(tartosTermek);

    }
    


}
Console.WriteLine("\t\t--- RAKTÁR ELLENŐRZÉS ---");
Console.WriteLine($"hibas sorok:\t{hibasSorokSzama}");
Console.WriteLine($"beolvasott sorok: \t{list.Count()}");
Console.WriteLine("\t\t--- TERMÉKEK LISTÁJA ---");
foreach (var T in list)
{
    Console.WriteLine(T.ToString());
}
Console.WriteLine("\t\t--- Statisztika ---");
Console.WriteLine($"osszes termek ara 10db termeket feltetelezve: \t{list.Sum(t => t.ErtekSzamitas(10))}");
Console.WriteLine($"osszes termek: \t{Termek.OsszesTermekSzama}");