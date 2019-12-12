using System;
using System.Collections.Generic;
using Codenation.Challenge.DTOs;

namespace Codenation.Challenge
{
    public class CandidateDTOIdComparer : IEqualityComparer<CandidateDTO>
    {
        public bool Equals(CandidateDTO x, CandidateDTO y)
        {
            return x.UserId == y.UserId &&
                   x.AccelerationId == y.AccelerationId &&
                   x.CompanyId == y.CompanyId;
        }

        public int GetHashCode(CandidateDTO obj)
        {
            return (obj.UserId, obj.AccelerationId, obj.CompanyId).GetHashCode();
        }
    }
}