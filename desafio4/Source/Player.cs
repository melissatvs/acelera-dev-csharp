using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation.Challenge
{
    class Player
    {
        public long Id { get; set; }
        public long TeamId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int SkillLevel { get; set; }
        public decimal Salary { get; set; }
        public bool Capitain { get; set; }
        
        public Player(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)
        {
            this.Id = id;
            this.TeamId = teamId;
            this.Name = name;
            this.BirthDate = birthDate;
            this.SkillLevel = skillLevel;
            this.Salary = salary;
        }
    }
}
