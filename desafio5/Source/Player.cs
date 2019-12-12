using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation.Challenge
{
    public class Player
    {
        public string FullName { get; set; }
        public string Nationality { get; set; }
        public string Club { get; set; }
        public decimal ReleaseClause { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Wage { get; set; }
        public int Age { get; set; }

        public Player(string fullName, string nationality, string club, decimal releaseClause, DateTime birthDate, decimal wage, int age)
        {
            this.FullName = fullName;
            this.Nationality = nationality;
            this.Club = club;
            this.ReleaseClause = releaseClause;
            this.BirthDate = birthDate;
            this.Wage = wage;
            this.Age = age;
        }
    }
}
