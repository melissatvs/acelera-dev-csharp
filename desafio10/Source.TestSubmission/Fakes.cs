using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.EntityFrameworkCore;
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

            service.Setup(x => x.FindByCompanyId(It.IsAny<int>())).
                Returns((int companyId) => {
                    return Get<Company>().                
                        Where(company => company.Id == companyId).
                        Join(Get<Candidate>(), 
                            company => company.Id, 
                            candidate => candidate.CompanyId, 
                            (company, candidate) => candidate).                    
                        Join(Get<User>(),
                            candidate => candidate.UserId,
                            user => user.Id,
                            (candidate, user) => user).
                        Distinct().
                        ToList();
                });

            service.Setup(x => x.FindByAccelerationName(It.IsAny<string>())).
                Returns((string accelerationName) => {
                    return Get<Acceleration>().
                        Where(acceleration => acceleration.Name == accelerationName).
                        Join(Get<Candidate>(), 
                            acceleration => acceleration.Id, 
                            candidate => candidate.AccelerationId, 
                            (acceleration, candidate) => candidate).
                        Join(Get<User>(),
                            candidate => candidate.UserId,
                            user => user.Id,
                            (candidate, user) => user).
                        Distinct().
                        ToList();
                });

            service.Setup(x => x.Save(It.IsAny<User>())).
                Returns((User user) => {
                    if (user.Id == 0)
                        user.Id = 999;
                    return user;
                });

            return service;
        }

        public Mock<ICompanyService> FakeCompanyService()
        {
            var service = new Mock<ICompanyService>();

            service.Setup(x => x.FindById(It.IsAny<int>())).
                Returns((int id) => {
                    return Get<Company>().Find(x => x.Id == id);
                });

            service.Setup(x => x.FindByAccelerationId(It.IsAny<int>())).
                Returns((int accelerationId) => {
                    return Get<Acceleration>().
                        Where(acceleration => acceleration.Id == accelerationId).
                        Join(Get<Candidate>(), 
                            acceleration => acceleration.Id, 
                            candidate => candidate.AccelerationId, 
                            (acceleration, candidate) => candidate).
                        Join(Get<Company>(),
                            candidate => candidate.CompanyId,
                            company => company.Id,
                            (candidate, company) => company).
                        Distinct().
                        ToList();
                });

            service.Setup(x => x.FindByUserId(It.IsAny<int>())).
                Returns((int userId) => {
                    return Get<User>().
                        Where(user => user.Id == userId).
                        Join(Get<Candidate>(), 
                            user => user.Id, 
                            candidate => candidate.UserId, 
                            (user, candidate) => candidate).                    
                        Join(Get<Company>(),
                            candidate => candidate.CompanyId,
                            company => company.Id,
                            (candidate, company) => company).
                        Distinct().
                        ToList();
                });

            service.Setup(x => x.Save(It.IsAny<Company>())).
                Returns((Company company) => {
                    if (company.Id == 0)
                        company.Id = 999;
                    return company;
                });

            return service;
        }

        public Mock<IChallengeService> FakeChallengeService()
        {
            var service = new Mock<IChallengeService>();
            
            service.Setup(x => x.FindByAccelerationIdAndUserId(It.IsAny<int>(), It.IsAny<int>())).
                Returns((int accelerationId, int userId) => {
                    return Get<User>().
                        Where(user => user.Id == userId).
                        Join(Get<Candidate>(), 
                            user => user.Id, 
                            candidate => candidate.UserId, 
                            (user, candidate) => candidate).
                        Join(Get<Acceleration>(),
                            candidate => candidate.AccelerationId,
                            acceleration => acceleration.Id,
                            (candidate, acceleration) => acceleration).
                        Where(acceleration => acceleration.Id == accelerationId).
                        Join(Get<Models.Challenge>(),
                            acceleration => acceleration.ChallengeId,
                            challenge => challenge.Id,
                            (acceleration, challenge) => challenge).
                        Distinct().
                        ToList();
                });


            service.Setup(x => x.Save(It.IsAny<Models.Challenge>())).
                Returns((Models.Challenge challenge) => {
                    if (challenge.Id == 0)
                        challenge.Id = 999;
                    return challenge;
                });

            return service;
        }

        public Mock<IAccelerationService> FakeAccelerationService()
        {
            var service = new Mock<IAccelerationService>();

            service.Setup(x => x.FindById(It.IsAny<int>())).
                Returns((int id) => {
                    return Get<Acceleration>().Find(x => x.Id == id);
                });

            service.Setup(x => x.FindByCompanyId(It.IsAny<int>())).
                Returns((int companyId) => {
                    return Get<Company>().
                    Where(company => company.Id == companyId).
                    Join(Get<Candidate>(), 
                        company => company.Id, 
                        candidate => candidate.CompanyId, 
                        (company, candidate) => candidate).
                    Join(Get<Acceleration>(),
                        candidate => candidate.AccelerationId,
                        acceleration => acceleration.Id,
                        (candidate, acceleration) => acceleration).
                    Distinct().
                    ToList();
                });

            service.Setup(x => x.Save(It.IsAny<Acceleration>())).
                Returns((Acceleration acceleration) => {
                    if (acceleration.Id == 0)
                        acceleration.Id = 999;
                    return acceleration;
                });

            return service;
        }

        public Mock<ICandidateService> FakeCandidateService()
        {
            var service = new Mock<ICandidateService>();

            service.Setup(x => x.FindById(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).
                Returns((int userId, int accelerationId, int companyId) => {
                    return Get<Candidate>().Find(x => 
                        x.UserId == userId &&
                        x.AccelerationId == accelerationId &&
                        x.CompanyId == companyId);
                });

            service.Setup(x => x.FindByCompanyId(It.IsAny<int>())).
                Returns((int companyId) => {
                    return Get<Company>().                
                        Where(company => company.Id == companyId).
                        Join(Get<Candidate>(), 
                            company => company.Id, 
                            candidate => candidate.CompanyId, 
                            (company, candidate) => candidate).
                        ToList();
                    });

            service.Setup(x => x.FindByAccelerationId(It.IsAny<int>())).
                Returns((int accelerationId) => {
                    return Get<Acceleration>().
                        Where(acceleration => acceleration.Id == accelerationId).
                        Join(Get<Candidate>(), 
                            acceleration => acceleration.Id, 
                            candidate => candidate.AccelerationId, 
                            (acceleration, candidate) => candidate).
                        ToList();
                    });

            service.Setup(x => x.Save(It.IsAny<Candidate>())).
                Returns((Candidate candidate) => {
                    return candidate;
                });

            return service;

        }

        public Mock<ISubmissionService> FakeSubmissionService()
        {
            var service = new Mock<ISubmissionService>();

            service.Setup(x => x.FindHigherScoreByChallengeId(It.IsAny<int>())).
                Returns((int challengeId) => {
                    return Get<Submission>().
                        Where(challenge => challenge.ChallengeId == challengeId).
                        Max(challenge => challenge.Score);
                });

            service.Setup(x => x.FindByChallengeIdAndAccelerationId(It.IsAny<int>(), It.IsAny<int>())).
                Returns((int challengeId, int accelerationId) => {
                    return Get<Candidate>().
                        Where(candidate => candidate.AccelerationId == accelerationId).
                        Join(Get<User>(),
                            candidate => candidate.UserId,
                            user => user.Id,
                            (candidate, user) => user).
                        Join(Get<Submission>(),
                            user => user.Id,
                            submission => submission.UserId,
                            (user, submission) => submission).
                        Where(submission => submission.ChallengeId == challengeId).
                        Distinct().
                        ToList();
                    });

            service.Setup(x => x.Save(It.IsAny<Submission>())).
                Returns((Submission submission) => {
                    return submission;
                });

            return service;
        }
    }    
}
