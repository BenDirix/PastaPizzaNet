using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enum;

namespace PastaPizzaNet
{
	class Program
	{
		static void Main(string[] args)
		{
			
			List<Gerecht> gerechten = null;
			List<Klant> klanten = null;
			List<Drank> dranken = null;
			List<BesteldGerecht> besteldeGerechten = null;
			List<Bestelling> bestellingen = null;
			List<Dessert> desserts = null;
			

			try
			{
				//Lijsten
				gerechten = new List<Gerecht>
				{
					new Pizza("Pizza Margherita", 8m, new List<string>{"Tomatensaus","Mozzarella" }), //0
					new Pizza("Pizza Napoli", 10m, new List<string>{"Tomatensaus", "Mozzarella", "Ansjovis", "Kappers", "Olijven"}), //1
					new Pizza("Pizza Lardiera", 9.50m, new List<string>{"Tomatensaus", "Mozzarella", "Spek"}), //2
					new Pizza("Pizza Vegetariana", 9.50m, new List<string>{"Tomatensaus", "Mozzarella", "Groenten"}), //3
					new Pasta("Spaghetti Bolognese", 12m, "met gehaktsaus"), //4
					new Pasta("Spaghetti Carbonara", 13m, "spek, roomsaus en parmezaanse kaas"), //5
					new Pasta("Penne Arrabbiata", 14m, "met pittige tomatensaus"), //6
					new Pasta("Lasagne", 15m) //7
				};				
				klanten = new List<Klant>
				{
					new Klant(1,"Jan Janssen"), //0
					new Klant(2,"Piet Peeters") //1
				};
				dranken = new List<Drank>
				{
					new Frisdrank(Enum.Drank.Water), //0
					new Frisdrank(Enum.Drank.Limonade), //1
					new Frisdrank(Enum.Drank.CocaCola), //2
					new Warmedrank(Enum.Drank.Koffie), //3
					new Warmedrank(Enum.Drank.Thee) //4
				};
				desserts = new List<Dessert>
				{
					new Dessert(Enum.Dessert.Cake),
					new Dessert(Enum.Dessert.Ijs),
					new Dessert(Enum.Dessert.Tiramisu)
				};
				besteldeGerechten = new List<BesteldGerecht>
				{
					new BesteldGerecht(gerechten[0],Grootte.Groot, new List<Extra>{Extra.Kaas, Extra.Look}), //0
					new BesteldGerecht(gerechten[0]), //1
					new BesteldGerecht(gerechten[1], Grootte.Groot), //2
					new BesteldGerecht(gerechten[7],Grootte.Klein, new List<Extra>{Extra.Look}), //3
					new BesteldGerecht(gerechten[5]), //4
					new BesteldGerecht(gerechten[4],Grootte.Groot, new List<Extra>{Extra.Kaas}), //5
				};
				bestellingen = new List<Bestelling>
				{
					new Bestelling(besteldeGerechten[0], dranken[0], desserts[1], 2, klanten[0]),
					new Bestelling(besteldeGerechten[1], dranken[0], desserts[2], 1, klanten[1]),
					new Bestelling(besteldeGerechten[2], dranken[4], desserts[1], 1, klanten[1]),
					new Bestelling(besteldeGerechten[3]),
					new Bestelling(besteldeGerechten[4], dranken[2], klant: klanten[0]),
					new Bestelling(besteldeGerechten[5], dranken[2], desserts[0], 1, klanten[1]),
					new Bestelling(drank: dranken[3], aantal:3, klant: klanten[1]),
					new Bestelling(dessert: desserts[2],klant: klanten[0])
				};               

				Console.WriteLine("1. Alle bestellingen");
				LijnTrekker.TrekLijn();
				//Alle Bestellingen
				var bestellingNr = 1;
				foreach(var gerecht in bestellingen)
				{
					Console.WriteLine($"Bestelling: {bestellingNr++}");
					Console.WriteLine(gerecht);
					LijnTrekker.TrekLijn();
				}

				//Alle bestellingen van Jan Janssen
				Clear("bestellingen van Jan Janssen");				
				var bestellingenJan = from bestelling in bestellingen
									  where bestelling.Klant.Naam == klanten[0].Naam
									  select bestelling;

				var totaalBedrag = 0m;
				
				Console.WriteLine("2. Alle bestellingen van Jan Janssen");
				LijnTrekker.TrekLijn();

				Console.WriteLine($"Bestellingen van klant {klanten[0].Naam}\n");
				foreach (var bestelling in bestellingenJan)
				{
					Console.WriteLine(bestelling);
					totaalBedrag += bestelling.BerekenBedrag();
					Console.WriteLine();
				}
				Console.WriteLine($"Het totaal bedrag van alle bestelingen van klant {klanten[0].Naam}: {totaalBedrag} euro");
				LijnTrekker.TrekLijn();

				Clear("bestellingen gegroepeerd per klant");

				//Alle bestellingen gesorteerd per klant
				Console.WriteLine("3. Alle bestellingen gegroepeerd per klant");
				LijnTrekker.TrekLijn();
				
				var bestellingenPerKlant = from bestelling in bestellingen
										   group bestelling by bestelling.Klant.Naam;

				foreach(var klant in bestellingenPerKlant)
				{
					totaalBedrag = 0m;
					if (klant.Key != "Onbekende Klant") 
						Console.WriteLine($"Bestellingen van klant {klant.Key}:\n");
					else
						Console.WriteLine($"{klant.Key}en:\n");

					foreach (var bestelling in klant)
					{
						Console.WriteLine(bestelling);
						Console.WriteLine();
						totaalBedrag += bestelling.BerekenBedrag();
					}
					if (klant.Key != "Onbekende Klant")
						Console.WriteLine($"Het totaal bedrag van alle bestelingen van klant {klant.Key}: {totaalBedrag} euro");

					LijnTrekker.TrekLijn();
				}	
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			Clear("ingelezen gegevens");
			Console.WriteLine("4. Alle ingelezen gegevens");
			LijnTrekker.TrekLijn();


			string locatie = @"C:\Data\";
			//WegSchrijven	
			try
			{							
				using (var schrijver = new StreamWriter(locatie + "Klanten.txt"))
				{
					foreach (var klant in klanten)
						schrijver.WriteLine(klant.WegSchrijven());
				}
				using (var schrijver = new StreamWriter(locatie + "Gerechten.txt"))
				{
					foreach (var gerecht in gerechten)
						schrijver.WriteLine(gerecht.WegSchrijven());
				}
				using (var schrijver = new StreamWriter(locatie + "Bestellingen.txt"))
				{
					foreach (var bestelling in bestellingen)
						schrijver.WriteLine(bestelling.WegSchrijven());
				}
			}
			catch (IOException)
			{
				Console.WriteLine("Fout bij het schrijven naar het bestand");
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			//Inlezen
			try
			{
				bestellingen = new List<Bestelling>();
				gerechten = new List<Gerecht>();
				klanten = new List<Klant>();
				List<Extra> extras;
				Bestelling bestelling;
				Gerecht gerecht;
				Drank drank;
				Dessert dessert;				
				Klant klant;
				string regel;
				
				using (var lezer = new StreamReader(locatie + "Klanten.txt"))
				{
					while ((regel = lezer.ReadLine()) != null)
					{
						string[] klantgegevens = regel.Split('#');
						var klantId = int.Parse(klantgegevens[0]);
						var klantnaam = klantgegevens[1];
						klant = new Klant(klantId, klantnaam);
						klanten.Add(klant);
					}
				}               
				using (var lezer = new StreamReader(locatie + "Gerechten.txt"))
				{
					while((regel = lezer.ReadLine()) != null)
					{
						string[] gerechtGegevens = regel.Split('#');
						var naam = gerechtGegevens[1];
						var prijs = decimal.Parse(gerechtGegevens[2]);
						var onderdelen = new List<string>();
						
						if(gerechtGegevens[0] == "pizza")
						{
							int aantalOnderdelen = gerechtGegevens.Length - 3;
							for (int i = 3; i < aantalOnderdelen + 3; i++)
							{
								onderdelen.Add(gerechtGegevens[i]);
							}
							var pizza = new Pizza(naam, prijs, onderdelen);
							gerechten.Add(pizza);
						}
						else if (gerechtGegevens[0] == "pasta")
						{
							if (gerechtGegevens[3] != null)
							{
								var omschrijving = gerechtGegevens[3];
								var pasta = new Pasta(naam, prijs, omschrijving);
								gerechten.Add(pasta);
							}
							else
							{
								var pasta = new Pasta(naam, prijs);
								gerechten.Add(pasta);
							}                            
						}
					}
				}
				using(var lezer = new StreamReader(locatie + "Bestellingen.txt"))
				{
					while ((regel= lezer.ReadLine()) != null)
					{						
						BesteldGerecht besteldgerecht = null;
						gerecht = null;
						extras = null;
						drank = null;
						dessert = null;

						string[] bestellingGegevens = regel.Split('#');

						var klantId = int.Parse(bestellingGegevens[0]);
						klant = klanten.Find(item => item.KlantId == klantId);
						
						if(bestellingGegevens[1] != "")
						{
							string[] arrBesteldgerecht = bestellingGegevens[1].Split('-');
							if(arrBesteldgerecht[0] != "")
								gerecht = gerechten.Find(item => item.Naam == arrBesteldgerecht[0]);

							Grootte grootte = (Grootte)System.Enum.Parse(typeof(Grootte), arrBesteldgerecht[1]);

							int aantalExtras = int.Parse(arrBesteldgerecht[2]);
							if (aantalExtras != 0)
							{
								extras = new List<Extra>();
								for (int i = 0; i < aantalExtras; i++)
								{
									Extra extra = (Extra)System.Enum.Parse(typeof(Extra), arrBesteldgerecht[i + 3]);
									extras.Add(extra);
								}
							}							
							besteldgerecht = new BesteldGerecht(gerecht, grootte, extras);
						}
						if(bestellingGegevens[2] != "")
						{
							string[] arrDranken = bestellingGegevens[2].Split('-');
							var drankNaam = (Enum.Drank)System.Enum.Parse(typeof(Enum.Drank), arrDranken[1]);
							if (arrDranken[0] == "F")
								drank = new Frisdrank(drankNaam);
							else
								drank = new Warmedrank(drankNaam);
						}

						if(bestellingGegevens[3] != "")
						{
							var dessertNaam = (Enum.Dessert)System.Enum.Parse(typeof(Enum.Dessert), bestellingGegevens[3]);
							dessert = new Dessert(dessertNaam);
						}

						bestelling = new Bestelling(besteldgerecht, drank, dessert, int.Parse(bestellingGegevens[4]), klant);
						bestellingen.Add(bestelling);	
					}
				}
				
				/*
				Console.WriteLine("Gerechten:\n");
				for (int i = 0; i < gerechten.Count; i++)
				{
					Console.WriteLine(gerechten[i]);
				}
				LijnTrekker.TrekLijn();
				*/
				/*
				Console.WriteLine("Klanten:\n");
				for (int i = 0; i < klanten.Count; i++)
				{
					Console.WriteLine(klanten[i]);
				}
				LijnTrekker.TrekLijn();
				*/

				
				for (int i = 0; i < bestellingen.Count; i++)
				{
					Console.WriteLine(bestellingen[i]);
					LijnTrekker.TrekLijn();
				}				
			}
			catch (IOException)
			{
				Console.WriteLine("Fout bij het lezen van het bestand");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		static void Clear(string tekst)
		{
			Console.WriteLine($"*Druk op enter om de {tekst} te bekijken*");
			Console.ReadLine();
			Console.Clear();
		}
	}
}
