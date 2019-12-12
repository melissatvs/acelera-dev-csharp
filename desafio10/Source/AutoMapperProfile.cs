using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Models;

namespace Codenation.Challenge
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Company, CompanyDTO>().ReverseMap();
            CreateMap<Models.Challenge, ChallengeDTO>().ReverseMap();
            CreateMap<Acceleration, AccelerationDTO>().ReverseMap();
            CreateMap<Submission, SubmissionDTO>().ReverseMap();
            CreateMap<Candidate, CandidateDTO>().ReverseMap();
        }
    }
}