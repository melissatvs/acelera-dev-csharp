using System.Collections.Generic;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public interface ISubmissionService    
    {
        decimal FindHigherScoreByChallengeId(int challengeId);
        IList<Submission> FindByChallengeIdAndAccelerationId(int challengeId, int accelerationId);
        Submission Save(Submission submission);
    }
}
