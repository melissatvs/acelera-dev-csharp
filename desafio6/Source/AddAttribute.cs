using System;

namespace Codenation.Challenge
{
    [AttributeUsage(AttributeTargets.Field)]
    public class AddAttribute : Attribute
    {
        [Add]
        private decimal item1 = -10;

        [Add]
        private decimal item2 = 20;
    }
}