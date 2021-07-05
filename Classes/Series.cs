using System;
namespace DIO.Series
{
    public class Series : BaseEntity
    {
        // Atributos da série

        private Gender Gender { get; set; }

        private string Title { get; set; }

        private string Description { get; set; }

        private int Year { get; set; }
        private bool Deleted { get; set; }
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
            string toReturn = "";
            toReturn += "Gênero: " + this.Gender + Environment.NewLine;
            toReturn += "Título: " + this.Title + Environment.NewLine;
            toReturn += "Ano: " + this.Year + Environment.NewLine;
            toReturn += "Descrição: " + this.Description + Environment.NewLine;
            toReturn += "Ano de início: " + this.Year + Environment.NewLine;
            toReturn += "Excluído: " + this.Deleted;
            return toReturn;
        }

        public string getTitle()
        {
            return this.Title;
        }

        public int getId()
        {
            return this.Id;
        }

        public bool getDeleted()
        {
            return this.Deleted;
        }

        public void Delete()
        {
            this.Deleted = true;
        }
    }
}