using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class SeriesRepository : IRepository<Series>
    {
        private List<Series> listSeries = new List<Series>();

        public void Create(Series entity)
        {
            listSeries.Add(entity);
        }

        public void Delete(int id)
        {
            listSeries[id].Delete();
        }

        public Series GetById(int id)
        {
            return listSeries[id];
        }

        public List<Series> List()
        {
            return listSeries;
        }

        public int NextId()
        {
            return listSeries.Count;
        }

        public void Update(int id, Series entity)
        {
            listSeries[id] = entity;
        }
    }
}