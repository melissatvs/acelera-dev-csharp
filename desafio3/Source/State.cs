using System;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    public class State
    {
        public string Name { get; set; }

        public string Acronym { get; set; }

        public double Extension { get; set; }        

        public State(string name, string acronym, double extension)
        {
            this.Name = name;
            this.Acronym = acronym;
            this.Extension = extension;
        }

    }

}
