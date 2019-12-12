using System;

namespace Codenation.Challenge
{
    [AttributeUsage(AttributeTargets.Field)]
    public class SubtractAttribute: Attribute
    {
        [Subtract]
        private decimal item1 = 10;

        [Subtract]
        private decimal item2 = 20;
    }

}