using RaktarApp;

List<Termek> list = new List<Termek>();
int hibasSorokSzama = 0;

foreach (string sor in File.ReadLines("termek.txt").Skip(1))
{
    string[] adatok = sor.Split("|");

    if (adatok.Length != 4)
    {
        hibasSorokSzama++;
        continue;
    }
    if (adatok[0] != "S" || adatok[0] != "G")
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
        Termek termek = new Termek(adatok[2], alapar);
        list.Add(termek);
    }
    else if (adatok[0] == "G")
    {
        TartosTermek tartosTermek = new TartosTermek(adatok[2], alapar, garanciaevek);
        list.Add(tartosTermek);

    }
    foreach (var T in list)
    {
        T.ToString();
    }
    Console.WriteLine(hibasSorokSzama);
    Console.WriteLine(list.Count());
    Console.WriteLine(list.Sum(t => t.ErtekSzamitas(10)));
    Console.WriteLine( Termek.OsszesTermekSzama);


}