using System.Drawing;
using Pastel;

namespace RPGspil;

public class Move
{
    public Enemy EnemyApproach(int level)
    {
        Console.WriteLine($"{"Enemy".Pastel(Color.FromArgb(200, 10, 70))} approaching!");
        
        int ran = Random.Shared.Next(1, 5);
        if (ran == 1)
        {
            Console.WriteLine("Skyggevandrer");
            Thread.Sleep(2000);
            Console.WriteLine("Disse mørke skikkelser er levende skygger, " +
                              "der sniger sig omkring i hytten og skoven.");
            Console.WriteLine("De er svære at se, men deres kolde ånde og " +
                              "hæse hvisken afslører deres tilstedeværelse");
            Thread.Sleep(4000);
            Console.WriteLine("");
            Console.WriteLine($"Brug et {"våben".Pastel(Color.Aqua)}");
            Enemy skygge = new Enemy{Name = "Skyggevandrer", attack = 15, health = 25 * level};
            return skygge;
        }
        else if (ran == 2)
        {
            Console.WriteLine("Hyttevæsen");
            Thread.Sleep(2000);
            Console.WriteLine("Et forvrænget, grotesk væsen, der engang var en " +
                              "spejderleder i hytten.");
            Console.WriteLine("Nu er det blevet besat af mørke kræfter og strejfer rundt i hytten på udkig efter intetanende ofre.");
            Thread.Sleep(4000);
            Console.WriteLine("");
            Console.WriteLine($"Brug et {"våben".Pastel(Color.Aqua)}");
            Enemy væsen = new Enemy{Name = "Hyttevæsen", attack = 10, health = 15 * level};
            return væsen;
        }
        else if (ran == 3)
        {
            Console.WriteLine("Skyggebarnet");
            Thread.Sleep(2000);
            Console.WriteLine("En ung pige på blot 10 år, der forsvandt på mystisk" +
                              " vis for over 100 år siden under en nat i fuldmånens" +
                              " skær.");
            Console.WriteLine("Hun var kendt for sin blonde krøllede hår, klare blå øjne og en uskyldig udstråling.");
            Console.WriteLine("Pigen boede i nærheden af skoven, hvor hytten nu ligger forfalden.");
            Thread.Sleep(5000);
            Console.WriteLine("");
            Console.WriteLine($"Brug et {"våben".Pastel(Color.Aqua)}");
            Enemy barn = new Enemy{Name = "Skyggebarnet", attack = 2, health = 15 * level};
            return barn;
        }
        else if (ran == 4)
        {
            Console.WriteLine("Varulv");
            Enemy bar = new Enemy{Name = "Varulv", attack = 20, health = 20 * level};
            Thread.Sleep(1000);
            Console.WriteLine("");
            Console.WriteLine($"Brug et {"våben".Pastel(Color.Aqua)}");
            return bar;
        }
        Console.WriteLine("");
        return null;
    }

    public Food FindFood()
    {
        Console.WriteLine($"You found {"food".Pastel(Color.FromArgb(20, 200, 50))}!");
        
        int ran = Random.Shared.Next(1, 5);
        if (ran == 1)
        {
            Console.WriteLine("Energibar! Find den i din inventory");
            Food bar = new Food{Name = "Energibar", Heeling = 25};
            return bar;
        }
        else if (ran == 2)
        {
            Console.WriteLine("Helende urter! Find dem i din inventory");
            Food urte = new Food{Name = "Helende urter", Heeling = 10};
            return urte;
        }
        else if (ran == 3)
        {
            Console.WriteLine("Sund suppe! Find den i din inventory");
            Food suppe = new Food { Name = "Sund suppe", Heeling = 50 };
            return suppe;
        }
        else if (ran == 4)
        {
            Console.WriteLine("Æble! Find det i din inventory");
            Food æble = new Food { Name = "Æble", Heeling = 25 };
            return æble;
        }
        Console.WriteLine("");
        return null;
    }

    public Weapon FindWeapon(int level)
    {
        Console.WriteLine($"You found a {"weapon".Pastel(Color.FromArgb(20, 200, 200))}! Pick it up");

        int ran = Random.Shared.Next(1, 6);
        if (ran == 1)
        {
            Console.WriteLine("Skovhakke! Find den i din inventory");
            Weapon hakke = new Weapon{Name = "Skovhakke", Damage = 12 * level, Health = 10};
            return hakke;
        }
        else if (ran == 2)
        {
            Console.WriteLine("Stålkniv! Find den i din inventory");
            Weapon kniv = new Weapon{Name = "Stålkniv", Damage = 5 * level, Health = 5};
            return kniv;
        }
        else if (ran == 3)
        {
            Console.WriteLine("Flaske med tjærepind! Find den i din inventory");
            Weapon flaske = new Weapon{Name = "Flaske med tjærepind", Damage = 25 * level, Health = 1};
            return flaske;
        }
        else if (ran == 4)
        {
            Console.WriteLine("Dolk! Find det i din inventory");
            Weapon dolk = new Weapon{Name = "Dolk", Damage = 5 * level, Health = 10};
            return dolk;
        }
        else if (ran == 5)
        {
            Console.WriteLine("Glock! Find det i din inventory");
            Weapon glock = new Weapon{Name = "Glock", Damage = 15 * level, Health = 15};
            return glock;
        }
        Console.WriteLine("");
        return null;
    }
}