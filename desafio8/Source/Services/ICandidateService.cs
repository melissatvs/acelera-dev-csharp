using System.Collections.Generic;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public interface ICandidateService    
    {
        Candidate FindById(int userId, int accelerationId, int companyId);
        IList<Candidate> FindByCompanyId(int companyId);
        IList<Candidate> FindByAccelerationId(int accelerationId);
        Candidate Save(Candidate candidate);
    }
}
