using System;

namespace AppSeriesMovies.Classes
{
    class Program
    {
        static SeriesRepository seriesRepo = new SeriesRepository();
		static MoviesRepository movieRepo = new MoviesRepository();
        static void Main(string[] args)
        {
            string userInput = takeUserInput();

			while (userInput.ToUpper() != "X")
			{
				switch (userInput)
				{
					case "1":
						ListSeries();
						break;
					case "2":
						InsertSeries();
						break;
					case "3":
						UpdateSeries();
						break;
					case "4":
						DeleteSeries();
						break;
					case "5":
						ShowSeries();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				userInput = takeUserInput();
			}

			Console.WriteLine("Thanks you");
			Console.ReadLine();
        }

        private static void DeleteSeries()
		{
			Console.Write("Insert series ID: ");
			int seriesID = int.Parse(Console.ReadLine());

			seriesRepo.Delete(seriesID);
		}

        private static void ShowSeries()
		{
			Console.Write("Insert series ID: ");
			int seriesID = int.Parse(Console.ReadLine());

			var series = seriesRepo.ReturnById(seriesID);

			Console.WriteLine(series);
		}

        private static void UpdateSeries()
		{
			Console.Write("Insert series ID: ");
			int seriesID = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Gender)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Gender), i));
			}
			Console.Write("Select the gender above ");
			int genderInput = int.Parse(Console.ReadLine());

			Console.Write("Type of the title: ");
			string titleInput = Console.ReadLine();

			Console.Write("Type of the year: ");
			int yearInput = int.Parse(Console.ReadLine());

			Console.Write("Description: ");
			string descriptionInput = Console.ReadLine();

			Series updateSeries = new Series(id: seriesID,
										gender: (Gender)genderInput,
										title: titleInput,
										year: yearInput,
										description: descriptionInput);

			seriesRepo.Update(seriesID, updateSeries);
		}
        private static void ListSeries()
		{
			Console.WriteLine("List series");

			var list = seriesRepo.List();

			if (list.Count == 0)
			{
				Console.WriteLine("Not found");
				return;
			}

			foreach (var series in list)
			{
                var deleted = series.returnDeleted();
                
				Console.WriteLine("#ID {0}: - {1} {2}", series.returnId(), series.returnTitle(), (deleted ? "*Deleted*" : ""));
			}
		}

        private static void InsertSeries()
		{
			Console.WriteLine("Insert new series");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Gender)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Gender), i));
			}
			Console.Write("Select the gender above ");
			int genderInput = int.Parse(Console.ReadLine());

			Console.Write("Title: ");
			string titleInput = Console.ReadLine();

			Console.Write("Year: ");
			int yearInput = int.Parse(Console.ReadLine());

			Console.Write("Description: ");
			string descriptionInput = Console.ReadLine();

			Series newSeries = new Series(id: seriesRepo.NextId(),
										gender: (Gender)genderInput,
										title: titleInput,
										year: yearInput,
										description: descriptionInput);

			seriesRepo.Insert(newSeries);
		}

        private static string takeUserInput()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Series & Movies");
			Console.WriteLine("Select an option");

			Console.WriteLine("1- List series");
			Console.WriteLine("2- Insert new");
			Console.WriteLine("3- Update");
			Console.WriteLine("4- Delete");
			Console.WriteLine("5- Show");
			Console.WriteLine("C- Clear");
			Console.WriteLine("X- Exit");
			Console.WriteLine();

			string userInput = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return userInput;
		}
    }
}
