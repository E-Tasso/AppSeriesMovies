using System;
using AppSeriesMovies;

namespace AppSeriesMovies
{
    public class Series : BaseEntity
    {
        // Atributos
		private Gender Gender { get; set; }
		private string Title { get; set; }
		private string Description { get; set; }
		private int Year { get; set; }
        private bool Deleted {get; set;}

        // Métodos
		public Series(int id, Gender gender, string title, string description, int year)
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
            string series = "";
            series += "Gender: " + this.Gender + Environment.NewLine;
            series += "Title: " + this.Title + Environment.NewLine;
            series += "Description: " + this.Description + Environment.NewLine;
            series += "Year: " + this.Year + Environment.NewLine;
            series += "Deleted: " + this.Deleted;
			return series;
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