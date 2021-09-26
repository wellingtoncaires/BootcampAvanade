using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO.Series.Web
{
    public class SerieModel
    {
        public int Id { get; set; }
        public Gender Gender { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public bool Removed { get; set; }


        public SerieModel() { }


        public SerieModel(Series series)
        {
            Id = series.returnId();
            Gender = series.returnGender();
            Title = series.returnTitle();
            Description = series.returnDescription();
            Removed = series.returnRemoved();
            Year = series.returnYear();
        }

        public Series ToSerie()
        {
            return new Series(Id, Gender, Title, Description, Year);
        }

    }
}
