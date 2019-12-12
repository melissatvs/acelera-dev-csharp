using System;
using System.Collections.Generic;
using Codenation.Challenge.DTOs;

namespace Codenation.Challenge
{
    public class SubmissionDTOIdComparer : IEqualityComparer<SubmissionDTO>
    {
        public bool Equals(SubmissionDTO x, SubmissionDTO y)
        {
            return x.UserId == y.UserId &&
                   x.ChallengeId == y.ChallengeId;
        }

        public int GetHashCode(SubmissionDTO obj)
        {
            return (obj.UserId, obj.ChallengeId).GetHashCode();
        }
    }
}