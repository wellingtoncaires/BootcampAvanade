using DIO.Series.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DIO.Series
{
    class SerieRepository : IRepository<Series>
    {
        private List<Series> listSeries = new List<Series>();
        public void Update(int id, Series serie)
        {
            listSeries[id] = serie;
        }

        public void Delete(int id)
        {
            listSeries[id].SerieRemove();
        }

        public void Insert(Series serie)
        {
            listSeries.Add(serie);
        }

        public List<Series> Lista()
        {
            return listSeries;
        }

        public int NextId()
        {
            return listSeries.Count();
        }

        public Series ReturnById(int id)
        {
            return listSeries[id];
        }
    }
}
