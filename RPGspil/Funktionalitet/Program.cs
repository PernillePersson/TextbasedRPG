using System.Drawing;
using Pastel;

namespace RPGspil;

public class Program
{
    public static void Main(string[] args)
    {
        Game game = new Game();
        
        Console.WriteLine($"Året er {"1995".Pastel(Color.CadetBlue)}, og den gamle spejderhytte" +
                          " i hjertet af skoven står øde og forfalden. ");
        Thread.Sleep(2000);
        Console.WriteLine($"Lokale legender fortæller om mystiske {"forsvindinger".Pastel(Color.CadetBlue)}, " +
                          $"bizarre {"ritualer".Pastel(Color.CadetBlue)} og en ukendt" +
                          $" {"skæbne".Pastel(Color.CadetBlue)}, der hviler over " +
                          "dette sted.");
        Thread.Sleep(3000);
        Console.WriteLine($"Ingen tør nærme sig hytten efter {"mørkets frembrud".Pastel(Color.CadetBlue)}.");
        Console.WriteLine();
        Thread.Sleep(5000);
        Console.WriteLine($"tast {"h".Pastel(Color.MediumOrchid)} for hjælp");
        
        var input = Console.ReadLine();
        
        game.Input(input);
        
        
    }
    
}