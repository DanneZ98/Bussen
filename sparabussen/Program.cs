/*Hjälpkod för att komma igång
 * Notera att båda klasserna är i samma fil för att det ska underlätta.
 * Om programmet blir större bör man ha klasserna i separata filer såsom jag går genom i filmen
 * Då kan det vara läge att ställa in startvärden som jag gjort.
 * Man kan också skriva ut saker i konsollen i konstruktorn för att se att den "vaknar
 * Denna kod hjälper mest om du siktar mot betyget E och C
 * För högre betyg krävs mer självständigt arbete
 */
using System;
namespace Bussen
{
	class Buss
	{

		Passenger passagerare = new Passenger();
		private int antal_passagerare = 0;

		
		public void Run()
		{
			//Skapar variabler för att kunna välja i menyn och för att kunna avsluta loopen.
			int choice = 0;
			bool menurun = true;
			//Skapar do-while loop för menyn.
			do
			{
				//Rensar konsollen för varje gång användaren återvänder till menyn och skriver ut alla valmöjligheter.
				Console.Clear();
				Console.WriteLine("Welcome to the awesome Buss-simulator");
				Console.WriteLine("[1] Add passenger");
				Console.WriteLine("[2] Print pasengers");
				Console.WriteLine("[3] Total age");
				Console.WriteLine("[4] Average age");
				Console.WriteLine("[5] Max age");
				Console.WriteLine("[6] Find age");
				Console.WriteLine("[7] Sort buss");
				Console.WriteLine("[8] Fill random");
				Console.WriteLine("[9] Remove passenger");
				Console.WriteLine("[0] Quit");

				//try-catch för att förhindra att programmet crashar vid felaktig inmatning.
				try
				{
					//Läser in användarens val, konverterar string till int och lagrar i variabeln choice.
					choice = Convert.ToInt32(Console.ReadLine());
				}
				catch
				{
					//Låter användaren veta att inmatning var felaktig.
					Console.WriteLine("Invalid");
				}
				//Skapar switch-case funktion för att anropa metoden som användaren vill åt.
				switch (choice)
				{
					case 1:
						add_passenger();
						break;
					case 2:
						print_buss();
						break;
					case 3:
						Console.WriteLine("The total age is: " + calc_total_age());
						Console.ReadKey();
						break;
					case 4:
						Console.WriteLine("The average age is: " + calc_average_age());
						Console.ReadKey();
						break;
					case 5:
						max_age();
						break;
					case 6:
						find_age();
						break;
					case 7:
						sort_buss();
						break;
					case 8:
						fill_random();
						break;
					case 9:
						getting_off();
						break;
					case 0:
						menurun = false;
						break;
					//Hindrar programmet från att krasha om användaren skriver in ett heltal som inte anropar en metod.
					default:
						Console.WriteLine("Invalid");
						break;
				}
			} while (menurun == true);
		}

		//Metoder för betyget E

		public void fill_random() //Fyller vektorn med slumptal.
		{
			//Skapar en slump variabel.
			Random slump = new Random();
			//Skapar for-loop som går igenom hela vektorn
			for (int i = 0; i < passagerare.age.Length; i++)
			{
				//If sats som kollar att vektorn är tom innan den lägger till ett slumptal mellan 1-100. Lägger till en person i antal_personer.
				if (passagerare.age[i] == 0)
				passagerare.name[i] = "Glenn";
				passagerare.age[i] = slump.Next(1, 100);
				passagerare.sex[i] = "male";
				antal_passagerare++;
			}
		}
		public void add_passenger() //Lägger till en person i vektorn.
		{
			//Kontrollerar om bussen är full. Om den är det skriver ut att den är full.
			if (antal_passagerare == passagerare.age.Length)
				Console.WriteLine("The bus is full");
			//Om bussen inte är full ökar antal passagerare med 1.
			else
				antal_passagerare++;
			//For-loop som går igenom antal passagerare.
			for (int i = 0; i < antal_passagerare; i++)
			{
				//Kontrollerar att positionen i vektorn är tom.
				if (passagerare.age[i] != 0)
				{
					continue;
				}
				else 
				{ 
					//Ber användaren skriva in ålder för positionen i vektorn.
					Console.WriteLine("Type in name, age and sex for position " + i);
					
					//Kontrollerar att användaren skriver in ett heltal, konverterar och lagrar svaret i vektorn.
					try
					{
						Console.WriteLine("Name: ");
						passagerare.name[i] = Console.ReadLine();
						Console.WriteLine("Age: ");
						passagerare.age[i] = Convert.ToInt32(Console.ReadLine());
						Console.WriteLine("Sex: ");
						passagerare.sex[i] = Console.ReadLine();

					}
					//Hindrar programmet från att krascha om användaren skriver in ett falaktigt värde och skriver ut att det blivit fel.
					catch
					{
						Console.WriteLine("Invalid input");
					}
				}
			}
			//Pausar programmet så att det inte rensar konsollen och går tillbaks till menyn direkt.
			Console.ReadKey();

			//Lägg till passagerare. Här skriver man då in ålder men eventuell annan information.
			//Om bussen är full kan inte någon passagerare stiga på
		}

		public void print_buss() //Skriver ut alla värden i vektorn och vilken position de har.
		{
			Console.WriteLine("Passengers:");
			//For-loop som går igenom hela vektorn.
			for (int i = 0; i < passagerare.age.Length; i++)
			{
				//Kontrollerar att positionen inte är tom och skriver ut värdet.
				if (passagerare.age[i] != 0)
					Console.WriteLine($"{i}: {passagerare.name[i]}, {passagerare.age[i]}, {passagerare.sex[i]}");
			}
			//Paus.
			Console.ReadKey();
		}

		public int calc_total_age() //Beräknar den totala åldern av alla passagerare.
		{
			//Skapar variabel för att lagra alla värden.
			int total = 0;

			//Går igenom antal passagerare.
			for (int i = 0; i < antal_passagerare; i++)
			{
				//Lägger till värdet ur vektorn i varibeln som lagrar det totala värdet.
				total += passagerare.age[i];
			}
			//Returnerar värdet. Hade även kunnat skriva ut värdet här.
			return total;
		}

		//Metoder för betyget C

		public double calc_average_age()
		{
			//Skapar variabler för att lagra det totala värdet och medelvärdet.
			double average_age;
			int total = 0;

			//Gör samma sak som loopen ovan.
			for (int i = 0; i < antal_passagerare; i++)
			{
				total += passagerare.age[i];
			}
			//Delar det totala värdet med antalet passagerare och konverterar det från int till double.
			average_age = (double)total / antal_passagerare;
			//Avrundar talet till 1 decimaltal.
			Math.Round(average_age, 1);
			//Returnerar värdet.
			return average_age;
			//Betyg C
			//Beräkna den genomsnittliga åldern. Kanske kan man tänka sig att denna metod ska returnera något annat värde än heltal?
		}

		public void max_age()
		{
			//Skapar variabel som lagrar det högsta värdet.
			int maxage = 0;

			//Går igenom vektorn och stannar efter antalet passagerare är uppnått. Skulle gå lika bra att gå igenom hela vektorn.
			for (int i = 0; i < antal_passagerare; i++)
			{
				//Kontrollerar om värdet i maxage är mindre än värdet i vektorn.
				if (maxage < passagerare.age[i])
				{
					//Om värdet i vektorn är större än maxage får maxage samma värde som positionen i vektorn.
					maxage = passagerare.age[i];
				}
			}
			//Skriver ut värdet.
			Console.WriteLine("The oldest person is " + maxage + " years old.");
			//Paus.
			Console.ReadKey();
			//Betyg C
			//ta fram den passagerare med högst ålder. Detta ska ske med egen kod och är rätt klurigt.
		}

		public void find_age()
		{
			//Skapar variabler för parametrarna.
			int parameter1 = 0;
			int parameter2 = 0;
			//Ber användaren skriva in parametrar.
			Console.WriteLine("Type in age parameters: ");
			//Skapar try-catch funktioner för att förhindra programmet från att krasha ifall användaren matar in ett ogiltigt värde.
			try
			{
				parameter1 = Convert.ToInt32(Console.ReadLine()); //lagrar användarens svar i parameter1.
			}
			catch
			{
				Console.WriteLine("Invalid"); //Skriver ut att användaren matat in fel svar.
			}
			try
			{
				parameter2 = Convert.ToInt32(Console.ReadLine()); //lagrar användarens svar i parameter2.
			}
			catch
			{
				Console.WriteLine("Invalid"); //Skriver ut att användaren matat in fel svar.
			}
			//For-loop som går igenom vektorn stannar när antalet passagerare är uppnått.
			for (int i = 0; i < antal_passagerare; i++)
			{
				//Kontrollerar om värdet i vektorn är större än parameter1.
				if (passagerare.age[i] >= parameter1)
				{
					//Kontrollerar om värdet i vektorn är mindre än parameter2.
					if (passagerare.age[i] <= parameter2)
					{
						//Om värdet ligger mellan parametrarna skrivs det ut samt positionen.
						Console.WriteLine("There is a " + passagerare.age[i] + " year old passenger on seat " + i + ".");
					}
				}
			}
			//Paus.
			Console.ReadKey();
		}
		public void sort_buss() //Sorterar bussen med bubble sort
		{
			//Skapar variabel som är 1 mindre än hela vektorn.
			int max = passagerare.age.Length - 1;

			//Yttre for-loop som går igenom hela vektorn -1 eftersom den kommer att få med det sista positionen i vektorn ändå genom [j + 1]
			for (int i = 0; i < max; i++)
			{
				//Inre loop som jämför alla värden med alla.
				for (int j = 0; j < max; j++)
				{
					//Jämför talen med varandra. Om talet till vänster är mindre än det till höger byter de plats.
					if (passagerare.age[j] < passagerare.age[j + 1])
					{
						//Det mindre värdet lagras temporärt i en variabel. Sedan tar det mindre värdet det större och det större det mindre som är lagrat i den temporära variabeln.
						int temp = passagerare.age[j];
						passagerare.age[j] = passagerare.age[j + 1];
						passagerare.age[j + 1] = temp;
					}
				}
			}
			//Skriver ut alla värden i vektorn så att användaren kan se att vektorn är sorterad.
			for (int i = 0; i < passagerare.age.Length; i++)
			{
				Console.WriteLine(passagerare.age[i]);
			}
			Console.ReadKey();
			//Sortera bussen efter ålder. Tänk på att du inte kan ha tomma positioner "mitt i" vektorn.
			//Beskrivs i läroboken på sidan 147 och framåt (kodexempel på sidan 159)
			//Man ska kunna sortera vektorn med bubble sort
		}
		//Metoder för betyget A
		public void print_gender()
		{
			for (int i = 0; i < passagerare.sex.Length; i++)
            {
                Console.WriteLine("On seat " + i + " there is a " + passagerare.sex[i]);
            }
			//Betyg A
			//Denna metod är nödvändigtvis inte svårare än andra metoder men kräver att man skapar en klass för passagerare.
			//Skriv ut vilka positioner som har manliga respektive kvinnliga passagerare.
		}
		public void poke()
		{
            Console.WriteLine("Vilken passagerare vill du peta på?");
			//Betyg A
			//Vilken passagerare ska vi peta på?
			//Denna metod är valfri om man vill skoja till det lite, men är också bra ur lärosynpunkt.
			//Denna metod ska anropa en passagerares metod för hur de reagerar om man petar på dom (eng: poke)
			//Som ni kan läsa i projektbeskrivningen så får detta beteende baseras på ålder och gender.
		}

		public void getting_off()
		{
			//Skapar variabel för att välja vilken position man vill ta bort från vektorn.
			int val = 0;

			//Ber användaren välja position.
			Console.Write("Type in the seat of the person getting off: ");
			try
			{
				//Konverterar värde
				val = Convert.ToInt32(Console.ReadLine());
			}
			catch
			{
				Console.WriteLine("Invalid");
			}
			Console.WriteLine("The " + passagerare.age[val] + " year old gets off the bus.");
			passagerare.age[val] = 0;
			antal_passagerare--;

			int max = passagerare.age.Length - 1;

			//Yttre for-loop som går igenom hela vektorn -1 eftersom den kommer att få med det sista positionen i vektorn ändå genom [j + 1]
			for (int i = 0; i < max; i++)
			{
				if (passagerare.age[i] == 0)
				{
					//Jämför talen med varandra. Om talet till vänster är mindre än det till höger byter de plats.
					if (passagerare.age[i] < passagerare.age[i + 1])
					{
						//Det mindre värdet lagras temporärt i en variabel. Sedan tar det mindre värdet det större och det större det mindre som är lagrat i den temporära variabeln.
						int temp = passagerare.age[i];
						passagerare.age[i] = passagerare.age[i + 1];
						passagerare.age[i + 1] = temp;
					}
				}
			}
			//Paus.
			Console.ReadKey();
		}
		//Betyg A
		//En passagerare kan stiga av
		//Detta gör det svårare vid inmatning av nya passagerare (som sätter sig på första lediga plats)
		//Sortering blir också klurigare
		//Den mest lämpliga lösningen (men kanske inte mest realistisk) är att passagerare bakom den plats..
		//.. som tillhörde den som lämnade bussen, får flytta fram en plats.
		//Då finns aldrig någon tom plats mellan passagerare.
	}

	class Passenger
	{
		public string[] name = new string[25];
		public int[] age = new int[25];
		public string[] sex = new string[25];
		
		/*public Passenger(string name, int age, string sex)
		{
			this.name = name;
			this.age = age;
			this.sex = sex;
		}
		*/
	}

	class Program
	{
		public static void Main(string[] args)
		{
			//Skapar ett objekt av klassen Buss som heter minbuss
			//Denna del av koden kan upplevas väldigt förvirrande. Men i sådana fall är det bara att "skriva av".
			var minbuss = new Buss();

			minbuss.Run();

			Console.Write("Exiting program . . . ");
			Console.ReadKey(true);
		}
	}
}
