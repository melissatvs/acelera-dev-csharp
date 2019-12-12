using System;
using System.Collections.Generic;
using Codenation.Challenge.DTOs;

namespace Codenation.Challenge
{
    public class AccelerationDTOIdComparer : IEqualityComparer<AccelerationDTO>
    {
        public bool Equals(AccelerationDTO x, AccelerationDTO y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(AccelerationDTO obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}