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

        readonly Dictionary<string, string> states = new Dictionary<string, string>();
        private void InitStatesBrazil()
        {
            states.Add("AC", "Acre");
            states.Add("AL", "Alagoas");
            states.Add("AP", "Amap�");
            states.Add("AM", "Amazonas");
            states.Add("BA", "Bahia");
            states.Add("CE", "Cear�");
            states.Add("DF", "Distrito Federal");
            states.Add("ES", "Esp�rito Santo");
            states.Add("GO", "Goi�s");
            states.Add("MA", "Maranh�o");
            states.Add("MT", "Mato Grosso");
            states.Add("MS", "Mato Grosso do Sul");
            states.Add("MG", "Minas Gerais");
            states.Add("PA", "Par�");
            states.Add("PB", "Para�ba");
            states.Add("PR", "Paran�");
            states.Add("PE", "Pernambuco");
            states.Add("PI", "Piau�");
            states.Add("RJ", "Rio de Janeiro");
            states.Add("RN", "Rio Grande do Norte");
            states.Add("RS", "Rio Grande do Sul");
            states.Add("RO", "Rond�nia");
            states.Add("RR", "Roraima");
            states.Add("SC", "Santa Catarina");
            states.Add("SP", "S�o Paulo");
            states.Add("SE", "Sergipe");
            states.Add("TO", "Tocantins");
        }

        public State[] Top10StatesByArea()
        {
            State[] result = new State[10];
            State[] allStates = new State[27];
            int s = 0;

            InitStatesBrazil();

            foreach (KeyValuePair<string, string> state in states)
            {
                allStates[s] = new State(state.Value, state.Key);

                s++;
            }

            for (int i = 0; i < allStates.Length; i++)
            {
                State stateAux = allStates[i];
                int j = i + 1;

                while (j < allStates.Length)
                {
                    if (stateAux.Extension < allStates[j].Extension)
                    {
                        allStates[i] = allStates[j];
                        allStates[j] = stateAux;

                        stateAux = allStates[i];                        
                    }                    

                    j += 1;
                }

            }

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = allStates[i];
            }

            return result;
        }
  
    }
}
