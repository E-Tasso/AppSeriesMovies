using System;


namespace AppSeriesMovies
{
    public class Movies : BaseEntity
    {
        // Atributos
		private Gender Gender { get; set; }
		private string Title { get; set; }
		private string Description { get; set; }
		private int Year { get; set; }
        private bool Deleted {get; set;}

        // Métodos
		public Movies(int id, Gender gender, string title, string description, int year)
		{
			this.Id = id;
			this.Gender = gender;
			this.Title = title;
			this.Description = description;
			this.Year = year;
            this.Deleted = false;
		}

        public override string ToString()
		{
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string movies = "";
            movies += "Gender: " + this.Gender + Environment.NewLine;
            movies += "Title: " + this.Title + Environment.NewLine;
            movies += "Description: " + this.Description + Environment.NewLine;
            movies += "Year: " + this.Year + Environment.NewLine;
            movies += "Deleted: " + this.Deleted;
			return movies;
		}

        public string returnTitle()
		{
			return this.Title;
		}

		public int returnId()
		{
			return this.Id;
		}
        public bool returnDeleted()
		{
			return this.Deleted;
		}
        public void Delete() {
            this.Deleted = true;
        }
    }
}