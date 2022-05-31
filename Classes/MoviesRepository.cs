using System;
using System.Collections.Generic;
using AppSeriesMovies;

namespace AppSeriesMovies
{
	public class MoviesRepository : IRepository<Movies>
	{
        private List<Movies> listMovies = new List<Movies>();
		public void Update(int id, Movies item)
		{
			listMovies[id] = item;
		}

		public void Delete(int id)
		{
			listMovies[id].Delete();
		}

		public void Insert(Movies item)
		{
			listMovies.Add(item);
		}

		public List<Movies> List()
		{
			return listMovies;
		}

		public int NextId()
		{
			return listMovies.Count;
		}

		public Movies ReturnById(int id)
		{
			return listMovies[id];
		}
	}
}