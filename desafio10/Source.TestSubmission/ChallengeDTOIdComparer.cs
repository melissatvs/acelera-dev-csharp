using System;
using System.Collections.Generic;
using Codenation.Challenge.DTOs;

namespace Codenation.Challenge
{
    public class ChallengeDTOIdComparer : IEqualityComparer<ChallengeDTO>
    {
        public bool Equals(ChallengeDTO x, ChallengeDTO y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(ChallengeDTO obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}