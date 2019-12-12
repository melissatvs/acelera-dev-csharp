using System;
using Xunit;

namespace Codenation.Challenge
{
    public class FIFACupStatsTest
    {
        [Fact]
        public void Shoud_Return_20_Itens_When_Get_Top_Players()
        {
            var cup = new FIFACupStats();
            var topPlayers = cup.First20Players();
            Assert.NotNull(topPlayers);
            Assert.Equal(20, topPlayers.Count);
        }

        [Fact]
        public void Shoud_Return_10_Itens_When_Get_Top_Players_By_Release_Clause()
        {
            var cup = new FIFACupStats();
            var topPlayers = cup.Top10PlayersByReleaseClause();
            Assert.NotNull(topPlayers);
            Assert.Equal(10, topPlayers.Count);
        }

        [Fact]
        public void Shoud_Return_10_Itens_When_Get_Top_Players_By_Age()
        {
            var cup = new FIFACupStats();
            var topPlayers = cup.Top10PlayersByAge();
            Assert.NotNull(topPlayers);
            Assert.Equal(10, topPlayers.Count);
        }

        [Fact]
        public void Shoud_Return_NationalityDistinctCount()
        {
            var cup = new FIFACupStats();
            var nationalities = cup.NationalityDistinctCount();
            Assert.Equal(164, nationalities);
        }

        [Fact]
        public void Shoud_Return_ClubDistinctCount()
        {
            var cup = new FIFACupStats();
            var clubs = cup.ClubDistinctCount();
            Assert.Equal(647, clubs);
        }

        [Fact]
        public void Shoud_Return_AgeCountMap()
        {
            var cup = new FIFACupStats();
            var age = cup.AgeCountMap();

            Assert.True(age.ContainsKey(16));
            Assert.Equal(18, age[16]);
            Assert.Equal(270, age[17]);
            Assert.Equal(682, age[18]);
            Assert.Equal(1088, age[19]);
            Assert.Equal(1252, age[20]);
            Assert.Equal(1275, age[21]);
            Assert.Equal(1324, age[22]);
            Assert.Equal(1395, age[23]);
            Assert.Equal(1321, age[24]);
            Assert.Equal(1515, age[25]);
            Assert.Equal(1199, age[26]);
            Assert.Equal(1153, age[27]);
            Assert.Equal(1053, age[28]);
            Assert.Equal(1127, age[29]);
            Assert.Equal(807, age[30]);
            Assert.Equal(666, age[31]);
            Assert.Equal(506, age[32]);
            Assert.Equal(610, age[33]);
            Assert.Equal(271, age[34]);
            Assert.Equal(188, age[35]);
            Assert.Equal(137, age[36]);
            Assert.Equal(69, age[37]);
            Assert.Equal(38, age[38]);
            Assert.Equal(18, age[39]);
            Assert.Equal(4, age[40]);
            Assert.Equal(3, age[41]);
            Assert.Equal(2, age[43]);
            Assert.Equal(2, age[44]);
            Assert.Equal(1, age[47]);
        }

    }
}
