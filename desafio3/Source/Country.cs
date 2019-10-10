using System;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    public class Country
    {
        /************************************************************************************
         * 1. Preciso entender onde esses dados fixos ficariam melhor: 
         *    - Na classe Country
         *    - Na classe State 
         *    - Em uma nova classe de acesso a uma fonte de dados (CountryData, StateData...)
         *
         *    E qual padrao que se segue para isso... ?
         *    
         * 2. Nesse desafio foi necessario retornar apenas estados brasileiros, porem a classe
         *    eh geral Country, o ideal seria criar uma Classe "filha" para o Brasil ou quem 
         *    deve cuidar disso eh quem vai usar (instanciar) a classe Country? 
         *    
         **/

        readonly State[] states = new State[27];

        private void InitStatesBrazil()
        {
            states[0] = new State("Acre", "AC", 164123.040);
            states[1] = new State("Alagoas", "AL", 27778.506);
            states[2] = new State("Amapá", "AP", 142828.521);
            states[3] = new State("Amazonas", "AM", 1559159.148);
            states[4] = new State("Bahia", "BA", 564733.177);
            states[5] = new State("Ceará", "CE", 148920.472);
            states[6] = new State("Distrito Federal", "DF", 5779.999);
            states[7] = new State("Espírito Santo", "ES", 46095.583);
            states[8] = new State("Goiás", "GO", 340111.783);
            states[9] = new State("Maranhão", "MA", 331937.450);
            states[10] = new State("Mato Grosso", "MT", 903366.192);
            states[11] = new State("Mato Grosso do Sul", "MS", 357145.532);
            states[12] = new State("Minas Gerais", "MG", 586522.122);
            states[13] = new State("Pará", "PA", 1247954.666);
            states[14] = new State("Paraíba", "PB", 56585.000);
            states[15] = new State("Paraná", "PR", 199307.922);
            states[16] = new State("Pernambuco", "PE", 98311.616);
            states[17] = new State("Piauí", "PI", 251577.738);
            states[18] = new State("Rio de Janeiro", "RJ", 43780.172);
            states[19] = new State("Rio Grande do Norte", "RN", 52811.047);
            states[20] = new State("Rio Grande do Sul", "RS", 281730.223);
            states[21] = new State("Rondônia", "RO", 237590.547);
            states[22] = new State("Roraima", "RR", 224300.506);
            states[23] = new State("Santa Catarina", "SC", 95736.165);
            states[24] = new State("São Paulo", "SP", 248222.362);
            states[25] = new State("Sergipe", "SE", 21915.116);
            states[26] = new State("Tocantins", "TO", 277720.520);
        }

        public State[] Top10StatesByArea()
        {           

            InitStatesBrazil();

            for (int i = 0; i < states.Length; i++)
            {
                State stateAux = states[i];
                int j = i + 1;

                while (j < states.Length)
                {
                    if (stateAux.Extension < states[j].Extension)
                    {
                        states[i] = states[j];
                        states[j] = stateAux;

                        stateAux = states[i];                        
                    }                    

                    j += 1;
                }

            }

            State[] result = new State[10];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = states[i];
            }

            return result;
        }
  
    }
}
