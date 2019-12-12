using System;
using System.Collections.Generic;
using System.IO;
using Codenation.Challenge.DTOs;
using Newtonsoft.Json;

namespace Codenation.Challenge
{
    /// Fake Data
    /// powered by https://mockaroo.com/
    ///
    public class Fakes
    {
        private Dictionary<Type, string> DataFileNames { get; } = 
            new Dictionary<Type, string>();
        private string FileName<T>() { return DataFileNames[typeof(T)]; }

        public Fakes()
        {
            DataFileNames.Add(typeof(UserDTO), @"TestData\users.json");
        }

        public List<T> Get<T>()
        {
            string content = File.ReadAllText(FileName<T>());
            return JsonConvert.DeserializeObject<List<T>>(content);
        }

    }    
}
