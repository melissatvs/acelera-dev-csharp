using System.Collections.Generic;

namespace Codenation.Challenge.Services
{
    public interface IChallengeService    
    {
        IList<Models.Challenge> FindByAccelerationIdAndUserId(int accelerationId, int userId);
        Models.Challenge Save(Models.Challenge challenge);
    }
}
