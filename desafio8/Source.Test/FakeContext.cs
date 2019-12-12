using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Codenation.Challenge
{
    /// Fake Data
    /// powered by https://mockaroo.com/
    ///
    public class FakeContext
    {
        public DbContextOptions<CodenationContext> FakeOptions { get; }

        private Dictionary<Type, string> DataFileNames { get; } = 
            new Dictionary<Type, string>();
        private string FileName<T>() { return DataFileNames[typeof(T)]; }

        public FakeContext(string testName)
        {
            FakeOptions = new DbContextOptionsBuilder<CodenationContext>()
                .UseInMemoryDatabase(databaseName: $"Codenation_{testName}")
                .Options;
            
            DataFileNames.Add(typeof(User), "FakeData\\users.json");
            DataFileNames.Add(typeof(Company), "FakeData\\companies.json");
            DataFileNames.Add(typeof(Models.Challenge), "FakeData\\companies.json");
            DataFileNames.Add(typeof(Acceleration), "FakeData\\accelerations.json");
            DataFileNames.Add(typeof(Submission),"FakeData\\submissions.json");
            DataFileNames.Add(typeof(Candidate), "FakeData\\candidates.json");

        }

        public void FillWithAll()
        {
            FillWith<User>();
            FillWith<Company>();
            FillWith<Models.Challenge>();
            FillWith<Acceleration>();
            FillWith<Submission>();
            FillWith<Candidate>();
        }

        public void FillWith<T>() where T: class
        {
            using (var context = new CodenationContext(FakeOptions))
            {
                if (context.Set<T>().Count() == 0)
                {
                    foreach (T item in GetFakeData<T>())
                        context.Set<T>().Add(item);
                    context.SaveChanges();
                }
            }
        }

        public List<T> GetFakeData<T>()
        {
            string content = File.ReadAllText(FileName<T>());
            return JsonConvert.DeserializeObject<List<T>>(content);
        }

    }
}
