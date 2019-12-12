using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Codenation.Challenge
{
    public class FIFACupStats
    {
        public string CSVFilePath { get; set; } = "data.csv";

        public Encoding CSVEncoding { get; set; } = Encoding.UTF8;

        private readonly int IdxID = 0;
        private readonly int IdxFullName = 2;
        private readonly int IdxClub = 3;
        private readonly int IdxAge = 6;
        private readonly int IdxBirthDate = 8;
        private readonly int IdxNacionality = 14;
        private readonly int IdxWage = 17;
        private readonly int IdxReleaseClause = 18;

        public List<Player> players = new List<Player>();

        public FIFACupStats()
        {
            StreamReader arquivo = new StreamReader(CSVFilePath);
            string linha;
            string[] camposCSV;

            while ((linha = arquivo.ReadLine()) != null)
            {
                camposCSV = linha.Split(',');

                if (camposCSV[IdxID] == "ID")
                {
                    continue;
                }


                int birthYear = Int32.Parse(camposCSV[IdxBirthDate].Split('-')[0]);
                int birthMonth = Int32.Parse(camposCSV[IdxBirthDate].Split('-')[1]);
                int birthDay = Int32.Parse(camposCSV[IdxBirthDate].Split('-')[2]);

                players.Add(new Player(
                    camposCSV[IdxFullName],
                    camposCSV[IdxNacionality],
                    camposCSV[IdxClub],
                    Decimal.Parse(prepareStrDecimal(camposCSV[IdxReleaseClause])),
                    new DateTime(birthYear, birthMonth, birthDay),
                    Decimal.Parse(prepareStrDecimal(camposCSV[IdxWage])),
                    Int32.Parse(camposCSV[IdxAge] == "" ? "0" : camposCSV[IdxAge])));
            }
        }

        private string prepareStrDecimal(string value)
        {
            string result = value.Replace('.', ',');
            result = result == "" ? "0" : result;
            return result;
        }

        public int NationalityDistinctCount()
        {
            return players.Where(p => !String.IsNullOrEmpty(p.Nationality)).GroupBy(p => p.Nationality).Count();
        }

        public int ClubDistinctCount()
        {
            return players
                .Where(p => !String.IsNullOrEmpty(p.Club))
                .GroupBy(p => p.Club)
                .Count();
        }

        public List<string> First20Players()
        {
            return players
                .Take(20)
                .Select(p => p.FullName)
                .ToList();
        }

        public List<string> Top10PlayersByReleaseClause()
        {
            return players
                .OrderByDescending(p => p.ReleaseClause)
                .Take(10)
                .Select(p => p.FullName)
                .ToList();
        }

        public List<string> Top10PlayersByAge()
        {
            return players
                .OrderBy(p => p.BirthDate)
                .ThenByDescending(p => p.Wage)
                .Take(10)
                .Select(p => p.FullName)
                .ToList();
        }

        public Dictionary<int, int> AgeCountMap()
        {
            return players
                .GroupBy(x => x.Age)
                .ToDictionary(x => x.Key, x => x.Count());
        }
    }
}
