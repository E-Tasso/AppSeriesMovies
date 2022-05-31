using System;
using System.Collections.Generic;
using AppSeriesMovies;

namespace AppSeriesMovies
{
	public class SeriesRepository : IRepository<Series>
	{
        private List<Series> listSeries = new List<Series>();
		public void Update(int id, Series item)
		{
			listSeries[id] = item;
		}

		public void Delete(int id)
		{
			listSeries[id].Delete();
		}

		public void Insert(Series item)
		{
			listSeries.Add(item);
		}

		public List<Series> List()
		{
			return listSeries;
		}

		public int NextId()
		{
			return listSeries.Count;
		}

		public Series ReturnById(int id)
		{
			return listSeries[id];
		}
	}
}