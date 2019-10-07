using System;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    public class StateAcronymComparer : IEqualityComparer<State>
    {
        public bool Equals(State x, State y)
        {
            return x.Acronym == y.Acronym;
        }

        public int GetHashCode(State obj)
        {
            return obj.Acronym.GetHashCode();
        }
    }
}