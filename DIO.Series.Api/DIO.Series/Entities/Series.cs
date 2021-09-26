using System;

namespace DIO.Series
{
    public class Series : BaseEntity
    {
        public Gender Gender { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Removed { get; set; }

        public Series(int id, Gender gender, string title, string description, int year)
        {
            base.Id = id;
            Gender = gender;
            Title = title;
            Description = description;
            Year = year;
            Removed = false;
        }

        public override string ToString()
        {
            string textString = "";
            textString += "Gênero: " + Gender + Environment.NewLine;
            textString += "Título: " + Title + Environment.NewLine;
            textString += "Descrição: " + Description + Environment.NewLine;
            textString += "Ano de Início: " + Year + Environment.NewLine;
            textString += "Excluído: " + Removed + Environment.NewLine;
            return textString;
        }

        public string returnTitle()
        {
            return Title;
        }

        public int returnId()
        {
            return Id;
        }

        public bool returnRemoved()
        {
            return Removed;
        }

        public Gender returnGender()
        {
            return Gender;
        }

        public string returnDescription()
        {
            return Description;
        }

        public int returnYear()
        {
            return Year;
        }

        public void SerieRemove()
        {
            Removed = true;
        }
    }
}
