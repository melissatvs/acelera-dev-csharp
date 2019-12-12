using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class CandidateService : ICandidateService
    {
        CodenationContext db;

        public CandidateService(CodenationContext context)
        {
            db = context;
        }

        public IList<Candidate> FindByAccelerationId(int accelerationId)
        {
            return db.Candidates.Where(x => x.AccelerationId == accelerationId).ToList();
        }

        public IList<Candidate> FindByCompanyId(int companyId)
        {
            return db.Candidates.Where(x => x.CompanyId == companyId).ToList();
        }

        public Candidate FindById(int userId, int accelerationId, int companyId)
        {
            return db.Candidates.FirstOrDefault(x => x.UserId == userId && x.AccelerationId == accelerationId && x.CompanyId == companyId);
        }

        public Candidate Save(Candidate candidate)
        {
            Candidate Result;
            Candidate candidateFind = FindById(candidate.UserId, candidate.AccelerationId, candidate.CompanyId);

            if (candidateFind == null)
            {
                db.Candidates.Add(candidate);

                Result = candidate;
            }
            else
            {
                Result = candidateFind;

                Result.Status = candidate.Status;
                Result.CreateAt = candidate.CreateAt;
            }

            db.SaveChanges();

            return Result;            
        }
    }
}
