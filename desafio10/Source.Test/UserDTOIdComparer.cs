using System;
using System.Collections.Generic;
using Codenation.Challenge.DTOs;

namespace Codenation.Challenge
{
    public class UserDTOIdComparer : IEqualityComparer<UserDTO>
    {
        public bool Equals(UserDTO x, UserDTO y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(UserDTO obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}