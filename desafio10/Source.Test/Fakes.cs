using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Moq;
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

        public IMapper Mapper { get; }

        public Fakes()
        {
            DataFileNames.Add(typeof(User), @"TestData\users.json");
            DataFileNames.Add(typeof(UserDTO), @"TestData\users.json");
            DataFileNames.Add(typeof(Company), @"TestData\companies.json");
            DataFileNames.Add(typeof(CompanyDTO), @"TestData\companies.json");
            DataFileNames.Add(typeof(Models.Challenge), @"TestData\companies.json");
            DataFileNames.Add(typeof(ChallengeDTO), @"TestData\companies.json");
            DataFileNames.Add(typeof(Acceleration), @"TestData\accelerations.json");
            DataFileNames.Add(typeof(AccelerationDTO), @"TestData\accelerations.json");
            DataFileNames.Add(typeof(Submission), @"TestData\submissions.json");
            DataFileNames.Add(typeof(SubmissionDTO), @"TestData\submissions.json");
            DataFileNames.Add(typeof(Candidate), @"TestData\candidates.json");
            DataFileNames.Add(typeof(CandidateDTO), @"TestData\candidates.json");

            var configuration = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<User, UserDTO>().ReverseMap();
                cfg.CreateMap<Company, CompanyDTO>().ReverseMap();
                cfg.CreateMap<Models.Challenge, ChallengeDTO>().ReverseMap();
                cfg.CreateMap<Acceleration, AccelerationDTO>().ReverseMap();
                cfg.CreateMap<Submission, SubmissionDTO>().ReverseMap();
                cfg.CreateMap<Candidate, CandidateDTO>().ReverseMap();
            });

            this.Mapper = configuration.CreateMapper();
        }

        public List<T> Get<T>()
        {
            string content = File.ReadAllText(FileName<T>());
            return JsonConvert.DeserializeObject<List<T>>(content);
        }

        public Mock<IUserService> FakeUserService()
        {
            var service = new Mock<IUserService>();
            
            service.Setup(x => x.FindById(It.IsAny<int>())).
                Returns((int id) => Get<User>().FirstOrDefault(x => x.Id == id));

            service.Setup(x => x.Save(It.IsAny<User>())).
                Returns((User user) => {
                    if (user.Id == 0)
                        user.Id = 999;
                    return user;
                });

            return service;
        }

    }    
}
