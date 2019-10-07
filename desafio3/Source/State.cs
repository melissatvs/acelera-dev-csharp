using System;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    public class State
    {
        // criar const com "dicionário" das extensões territoriais
        // ao criar o state popular a extenção de acordo com essa const

        public string Name { get; set; }

        public string Acronym { get; set; }

        public double Extension 
        { 
            get
            {
                foreach (var item in extensionsBrazil)
                {
                    if (item.Key == Acronym)
                    {
                        return item.Value;
                    }
                }

                return 0;
            }
        }

        readonly Dictionary<string, double> extensionsBrazil = new Dictionary<string, double>();

        private void InitExtensionsBrazil()
        {
            extensionsBrazil.Add("AC", 164123.040);
            extensionsBrazil.Add("AL", 27778.506);
            extensionsBrazil.Add("AP", 142828.521);
            extensionsBrazil.Add("AM", 1559159.148);
            extensionsBrazil.Add("BA", 564733.177);
            extensionsBrazil.Add("CE", 148920.472);
            extensionsBrazil.Add("DF", 5779.999);
            extensionsBrazil.Add("ES", 46095.583);
            extensionsBrazil.Add("GO", 340111.783);
            extensionsBrazil.Add("MA", 331937.450);
            extensionsBrazil.Add("MT", 903366.192);
            extensionsBrazil.Add("MS", 357145.532);
            extensionsBrazil.Add("MG", 586522.122);
            extensionsBrazil.Add("PA", 1247954.666);
            extensionsBrazil.Add("PB", 56585.000);
            extensionsBrazil.Add("PR", 199307.922);
            extensionsBrazil.Add("PE", 98311.616);
            extensionsBrazil.Add("PI", 251577.738);
            extensionsBrazil.Add("RJ", 43780.172);
            extensionsBrazil.Add("RN", 52811.047);
            extensionsBrazil.Add("RS", 281730.223);
            extensionsBrazil.Add("RO", 237590.547);
            extensionsBrazil.Add("RR", 224300.506);
            extensionsBrazil.Add("SC", 95736.165);
            extensionsBrazil.Add("SP", 248222.362);
            extensionsBrazil.Add("SE", 21915.116);
            extensionsBrazil.Add("TO", 277720.520);
        }

        public State(string name, string acronym)
        {
            InitExtensionsBrazil();

            this.Name = name;
            this.Acronym = acronym;            
        }

    }

}
