using System;
using System.Collections.Generic;
using Codenation.Challenge.Models;

namespace Codenation.Challenge
{
    public class UserIdComparer : IEqualityComparer<User>
    {
        public bool Equals(User x, User y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(User obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}