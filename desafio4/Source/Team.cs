using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation.Challenge
{
    class Team
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public string MainShirtColor { get; set; }
        public string SecondaryShirtColor { get; set; }
        
        public Team(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {
            this.Id = id;
            this.Name = name;
            this.CreateDate = createDate;
            this.MainShirtColor = mainShirtColor;
            this.SecondaryShirtColor = secondaryShirtColor;
        }
    }
}
