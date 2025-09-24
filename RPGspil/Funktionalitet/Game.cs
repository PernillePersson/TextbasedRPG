using System.Drawing;
using System.Net;
using Pastel;

namespace RPGspil;

public class Game
{
		public const int Playing  = 0;
		public const int Ended    = 1;
		public int GameState;
		public Ib ib;
		public Inventory inv;
		public List<IItem> Inventory;
		public Move mov;
		public IItem inHand;
		public Enemy currentEnemy;
		
		public Game() {
				GameState = Playing;
				Inventory = new List<IItem>();
				inv = new Inventory(Inventory);
				
				Item lygte = new Item{Name = "Lommelygte"};
				Weapon dolk = new Weapon{Name = "Dolk", Damage = 5, Health = 10};
				Food cookie = new Food { Name = "Cookie", Heeling = 20 };
				
				inv.AddToInventory(lygte);
				inv.AddToInventory(cookie);
				inv.AddToInventory(dolk);
				
				ib = new Ib(inv);
				mov = new Move();
				currentEnemy = new Enemy{health = 0};
		}
		
		public void Input(string input)
		{
				if (input == "h")
				{
						Help();
				}
				else if (input == "stats")
				{
						ShowStats();
				}
				else if (input == "kms")
				{
						CommitSuicide();
				}
				else if (input == "inv")
				{
						OpenInventory();
				}
				else if (input == "move")
				{
						if (currentEnemy.health <= 0)
						{
								Move(ib.level);
						}
						else
						{
								Console.WriteLine("You have to kill the enemy first");
						}
				}
				else if (input == "use")
				{
						inHand.UseItem(ib);
						if (inHand.GetType().Equals(typeof(Food)))
						{
							inHand = null;
						}
						if (currentEnemy.health > 0)
						{
								Fight();
						}
				}
				else if (input == "grab")
				{
						Grab();
				}
				else if (input == "put back")
				{
						PutBack();
				}
				else
				{
						Console.WriteLine("Not a move - try h for help");
				}
				if (IsPlaying())
				{
						string s = Console.ReadLine();
						Input(s);
				}
		}
		
		public bool IsPlaying() {
				return GameState == Playing;
		}

		private void CheckGameOver()
		{
				if (ib.health <= 0) {
						GameState = Ended;
						Console.WriteLine($"You {"died".Pastel(Color.FromArgb(255, 20, 20))}");
						ShowStats();
				}
		}

		public void Help()
		{
				Console.WriteLine($"{"stats".Pastel(Color.MediumOrchid)} : Viser dit health, level og xp");
				Console.WriteLine($"{"inv".Pastel(Color.MediumOrchid)} : Viser indholdet i din inventory");
				Console.WriteLine($"{"move".Pastel(Color.MediumOrchid)} : Forsæt på din vej i spillet");
				Console.WriteLine($"{"grab".Pastel(Color.MediumOrchid)} : Tager items ud ad din inventory!");
				Console.WriteLine($"{"use".Pastel(Color.MediumOrchid)} : Brug det item der er i din hånd!");
				Console.WriteLine($"{"put back".Pastel(Color.MediumOrchid)} : Lægger item i din hånd, tilbage i inventory");
				Console.WriteLine($"{"kms".Pastel(Color.MediumOrchid)} : Suicide - Game Over!");
				
		}

		public void ShowStats()
		{
				Console.WriteLine("Your stats: ");
				Console.WriteLine(ib.getStats());
		}

		public void OpenInventory()
		{
				Console.WriteLine($"Content in {"inventory".Pastel(Color.DodgerBlue)}: ");
				foreach (var Item in Inventory)
				{
						Console.WriteLine(Item);
				}
		}

		public void Move(int level)
		{
				int ran = Random.Shared.Next(1, 4);

				if (ran == 1)
				{
						currentEnemy = mov.EnemyApproach(level);
				}
				else if (ran == 2)
				{
						Food f = mov.FindFood();
						inv.AddToInventory(f);
				}
				else if (ran == 3)
				{
						Weapon w = mov.FindWeapon(level);
						inv.AddToInventory(w);
						ib.xp = ib.xp + 10;
				}

				ib.xp++;
				CheckXp(ib.xp);
		}

		public void Fight()
		{
				if (inHand.GetType().Equals(typeof(Weapon)))
				{
						Weapon f = (Weapon)inHand;
						
						ib.health = ib.health - currentEnemy.attack;
						Console.WriteLine($"You have been {"attacked".Pastel(Color.MediumSlateBlue)}");
						Thread.Sleep(1000);
						Console.WriteLine($"Your health: {ib.health}");
						Console.WriteLine("");
						Thread.Sleep(1000);
						CheckGameOver();
						if (IsPlaying())
						{
								if (f.Health >= 0)
								{
										currentEnemy.health = currentEnemy.health - f.Damage;
										Console.WriteLine($"Enemy has been {"hurt".Pastel(Color.MediumSlateBlue)}");
										Thread.Sleep(1000);
										Console.WriteLine($"Enemys health: {currentEnemy.health}");
								}
								else
								{
										Console.WriteLine("You need a weapon to fight enemy");
								}
								ib.xp++;
														
								Thread.Sleep(1000);
								Console.WriteLine("");
								Console.WriteLine($"{"Weapon health left:".Pastel(Color.MediumSeaGreen)} {f.Health}");
								
								if (currentEnemy.health <= 0)
								{
										ib.xp = ib.xp + 20;
										Console.WriteLine($"{"Enemy defeated!".Pastel(Color.DarkCyan)} You can now continue");
								}
						}
						
				}
				else
				{
						Console.WriteLine("Item in hand must be weapon to fight enemy");
				}
		}

		public void Grab()
		{
				if(Inventory.Count == 0)
				{
						Console.WriteLine("Your inventory is empty");
						if(currentEnemy.health > 0 && inHand == null)
						{
							Console.WriteLine("You don't have anything to fight with");
							Thread.Sleep(1000);
							ib.health = ib.health - currentEnemy.attack;
							Console.WriteLine($"You have been {"attacked".Pastel(Color.MediumSlateBlue)}");
							Thread.Sleep(1000);
							Console.WriteLine($"Your health: {ib.health}");
							Console.WriteLine("");
							Thread.Sleep(1000);
							CheckGameOver();
						}
				}else
				{
						Console.WriteLine($"Which {"item".Pastel(Color.CornflowerBlue)} do you " +
															$"want to grab from your {"inventory".Pastel(Color.DodgerBlue)}?");
						string s = Console.ReadLine();
						try
						{
								if (inHand != null)
								{
										inv.AddToInventory(inHand);
										Console.WriteLine($"{inHand.Name.Pastel(Color.CornflowerBlue)} was put back in your inventory");
								}
				
								Thread.Sleep(1000);
								IItem i = Inventory.First(item => item.Name == s);
								inv.GrapFromInventory(i);
								inHand = i;
								Console.WriteLine($"{i.Name.Pastel(Color.CornflowerBlue)} is now in your hand");
						}
						catch (Exception e)
						{
								Console.WriteLine($"You don't have this item in your {"inventory".Pastel(Color.DodgerBlue)}");
						}
				}
				
		}

		public void PutBack()
		{
				inv.AddToInventory(inHand);
				inHand = null;
				Console.WriteLine($"Item is back in your {"inventory".Pastel(Color.DodgerBlue)}");
		}

		public void CheckXp(int xp)
		{
				double tal = ib.level * 1.5;
				if (xp >= 100 * tal) //increaser level når xp er over 100 * ib's level plus en halv
				{
						ib.level++;
						Console.WriteLine("");
						Console.WriteLine($"You have {"leveled up".Pastel(Color.DeepPink)}." +
															$" Food will now give more {"health".Pastel(Color.Crimson)}," +
															$" and enemies will have higher {"health and damage".Pastel(Color.Crimson)}");
				}
		}

		public void CommitSuicide()
		{
				ib.health = 0;
				CheckGameOver();
		}

}