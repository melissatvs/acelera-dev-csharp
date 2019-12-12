using System;
using System.Collections.Generic;
using Codenation.Challenge.DTOs;

namespace Codenation.Challenge
{
    public class CompanyDTOIdComparer : IEqualityComparer<CompanyDTO>
    {
        public bool Equals(CompanyDTO x, CompanyDTO y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(CompanyDTO obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}